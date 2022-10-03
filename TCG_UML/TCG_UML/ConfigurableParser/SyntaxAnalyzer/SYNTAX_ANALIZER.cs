using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Xml;
using TCG_UML.ConfigurableParser.Lexer;

namespace TCG_UML.ConfigurableParser.SyntaxAnalyzer
{
    public partial class SYNTAX_ANALIZER : IDisposable
    {
        private SYMBOL startSymbol;
        private CFG grammar;
        private HashSet<string> specialIdentifiers;
        List<TOKEN> tokensList;
        private int nextToken = 0;
        SYNTAX_TREE syntaxTree;

        public SYNTAX_ANALIZER(XmlDocument CFG_xml, List<TOKEN> tokens)
        {
            XmlNode startSybol_XML = CFG_xml.SelectSingleNode("/context_free_grammar/start_symbol");

            XmlNodeList specialIds = CFG_xml.SelectSingleNode("/context_free_grammar/special_identifiers").ChildNodes;

            XmlNodeList terminalSymbols = CFG_xml.SelectSingleNode("/context_free_grammar/terminal_symbols").ChildNodes;

            XmlNodeList productions = CFG_xml.SelectSingleNode("/context_free_grammar/productions").ChildNodes;

            startSymbol = new SYMBOL(startSybol_XML.InnerText, SYMBOL_TYPE.NON_TERMINAL);

            FillSpecialIdentifiers(specialIds);
            grammar = new CFG(terminalSymbols, productions);

            this.tokensList = tokens;

            SetSpecialIdentifiers();

        }

        private void FillSpecialIdentifiers(XmlNodeList specialIds_XmlList)
        {
            specialIdentifiers = new HashSet<string>();

            foreach (XmlNode specialId_XmlNode in specialIds_XmlList)
            {
                specialIdentifiers.Add(specialId_XmlNode.InnerText);
            }
        }

        private bool CheckTerminalMatch(SYMBOL terminalSymbol, SYNTAX_TREE_NODE stNode)
        {
            if (nextToken < tokensList.Count)
            {
                if (terminalSymbol.id == tokensList[nextToken].type)
                {
                    stNode.GetSymbolAttributes(terminalSymbol, tokensList[nextToken]);
                    nextToken++;
                    return true;
                }
                nextToken++;
            }

            stNode = null;
            return false;
        }

        public bool PerformSyntaxAnalysis()
        {
            SYNTAX_TREE_NODE stNode = new SYNTAX_TREE_NODE();

            if (CheckNonTerminal(startSymbol, stNode))
            {
                syntaxTree = new SYNTAX_TREE(stNode);

                return true;
            }

            return false;
        }

        private bool CheckNonTerminal(SYMBOL symbol, SYNTAX_TREE_NODE derivedSyntaxTree ) {

            int savedTokenIndex = nextToken;

            foreach (DERIVATION derivation in grammar.productions[symbol].derivations)
            {
                if (CheckDerivation(derivation, derivedSyntaxTree))
                {
                    derivedSyntaxTree.GetSymbolAttributes(symbol);
                    return true;
                }
                else
                {
                    nextToken = savedTokenIndex;
                    derivedSyntaxTree.Clear();
                }
            }

            derivedSyntaxTree.Clear();
            derivedSyntaxTree = null;

            return false;
        }

        private bool CheckDerivation(DERIVATION derivation, SYNTAX_TREE_NODE derivationNode)
        {
            List<SYNTAX_TREE_NODE> derivedNodes = new List<SYNTAX_TREE_NODE>();

            foreach (SYMBOL symbol in derivation.derivedSymbols)
            {
                SYNTAX_TREE_NODE newStNode = new SYNTAX_TREE_NODE();

                if (symbol.type == SYMBOL_TYPE.TERMINAL)
                {
                    if (!CheckTerminalMatch(symbol, newStNode))
                    {
                        derivationNode.Clear();
                        return false;
                    }
                }
                else if (symbol.type == SYMBOL_TYPE.NON_TERMINAL)
                {
                    if (!CheckNonTerminal(symbol, newStNode))
                    {
                        derivationNode.Clear();
                        return false;
                    }
                }

                derivationNode.AddDerivation(newStNode);
            }

            return true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool dispossing)
        {
            if (dispossing)
            {
                throw new NotImplementedException();
            }
        }

        public Image DrawSyntaxTree()
        {
            DOTFormat graphInDOT = new DOTFormat(syntaxTree);

            string executable = @"dot.exe";
            string output = @".\external\tempgraph";

            FileInfo file = new FileInfo(output);
            file.Directory.Create();

            File.WriteAllText(output, graphInDOT.getDOTString());

            Process process = new System.Diagnostics.Process();

            // Stop the process from opening a new window
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            // Setup executable and parameters
            process.StartInfo.FileName = executable;
            process.StartInfo.Arguments = string.Format(@"{0} -Tjpg -O", output);

            // Go
            process.Start();

            // and wait doe.exe to complete and exit
            process.WaitForExit();

            //Process.Start(output + ".jpg");

            Bitmap bitmap = null;

            using (Stream bmpStream = System.IO.File.Open(output + ".jpg", System.IO.FileMode.Open))
            {
                Image image = Image.FromStream(bmpStream);
                bitmap = new Bitmap(image);
                bitmap.Save("SyntaxTree.jpg");
            }

            File.Delete(output);
            File.Delete(output + ".jpg");
            return bitmap;
        }

        ~SYNTAX_ANALIZER()
        {
            Dispose(false);
        }

        public void SetSpecialIdentifiers()
        {
            List<int> indexesToRemove = new List<int>();

            foreach (TOKEN token in tokensList)
            {
                if (token.type == "identifier")
                {
                    if (specialIdentifiers.Contains(token.lexeme))
                    {
                        token.type = token.lexeme;
                    }
                }
            }
        }
    }
}