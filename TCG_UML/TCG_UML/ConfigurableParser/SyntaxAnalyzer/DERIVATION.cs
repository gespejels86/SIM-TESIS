using System.Collections.Generic;
using System.Xml;

namespace TCG_UML.ConfigurableParser.SyntaxAnalyzer
{
    public class DERIVATION
    {
        public List<SYMBOL> derivedSymbols;

        public DERIVATION(XmlNode derivation_XML)
        {
            derivedSymbols = new List<SYMBOL>();

            XmlNodeList derivedSymbols_XML = derivation_XML.ChildNodes;

            foreach (XmlNode derivedSymbol_XML in derivedSymbols_XML)
            {
                SYMBOL newSymbol;

                if (derivedSymbol_XML.Name == "terminal")
                {
                    newSymbol = new SYMBOL(derivedSymbol_XML.InnerText, SYMBOL_TYPE.TERMINAL);
                    derivedSymbols.Add(newSymbol);
                }
                else if (derivedSymbol_XML.Name == "noterminal")
                {
                    newSymbol = new SYMBOL(derivedSymbol_XML.InnerText, SYMBOL_TYPE.NON_TERMINAL);
                    derivedSymbols.Add(newSymbol);
                }
                
            }
        }
    }
}