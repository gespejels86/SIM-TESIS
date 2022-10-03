using System;
using System.Collections.Generic;
using System.Xml;

namespace TCG_UML.ConfigurableParser.SyntaxAnalyzer
{
    public partial class CFG
    {
        public HashSet<SYMBOL> terminalSymbols;
        public Dictionary<SYMBOL, PRODUCTION> productions;

        public CFG(XmlNodeList terminalSymbols_XML, XmlNodeList productions_XML)
        {
            FillTerminalSymbols(terminalSymbols_XML);
            FillProductions(productions_XML);
        }

        private void FillProductions(XmlNodeList productions_XML)
        {
            productions = new Dictionary<SYMBOL, PRODUCTION>();

            foreach (XmlNode production_XML in productions_XML)
            {
                PRODUCTION newProduction = new PRODUCTION(production_XML);
                productions.Add(newProduction.nonTerminalToDerive, newProduction);
            }
        }

        private void FillTerminalSymbols(XmlNodeList terminalSymbols_XML)
        {
            terminalSymbols = new HashSet<SYMBOL>();

            foreach (XmlNode terminalSymbol_XML in terminalSymbols_XML)
            {
                terminalSymbols.Add(new SYMBOL(terminalSymbol_XML.InnerText,SYMBOL_TYPE.TERMINAL));
            }
        }
    }
}