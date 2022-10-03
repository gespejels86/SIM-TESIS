using System;
using System.Collections.Generic;

namespace TCG_UML.ConfigurableParser.Lexer
{
    partial class LEXER
    {
        public void Tokenaize(List<TOKEN> tokensList, string file)
        {
            int fileIterator = 0;
            int lexemeIterator = 0;
            bool matchFound = false;

            while (fileIterator < file.Length)
            {
                matchFound = false;
                foreach (KeyValuePair<string, REG_EXP> regExp in regularExpresions)
                {
                    if (!matchFound)
                    {
                            matchFound = match(regExp.Value.get_DFAGraph(), file, ref lexemeIterator);
                        if (matchFound)
                        {
                            if (!regExp.Value.GetIgnore())
                            {
                                TOKEN newToken = new TOKEN(regExp.Key, file.Substring(fileIterator, lexemeIterator - fileIterator));
                                tokensList.Add(newToken);
                            }
                            fileIterator = lexemeIterator;
                        }
                        else
                        {
                            lexemeIterator = fileIterator;
                        }
                    }
                }
                if (!matchFound)
                {
                    //error
                }
            }
        }

        private bool match(DFA_GRAPH DFA_GRAPH, string file, ref int lexemeIterator)
        {
            NODE nodeIterator = DFA_GRAPH.startNode;

            while (nodeIterator.edgesHash.ContainsKey(file[lexemeIterator]))
            {
                nodeIterator = nodeIterator.edgesHash[file[lexemeIterator]];
                nodeIterator.Get_EdgesHash();
                lexemeIterator++;

                if (lexemeIterator >= file.Length)
                {
                    break;
                }

            }

            if (nodeIterator.nodeType == NODE_TYPE.END)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
