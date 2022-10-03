using System.Collections.Generic;
using System.Xml;

namespace TCG_UML.ConfigurableParser.SyntaxAnalyzer
{
    public partial class PRODUCTION
    {
        public SYMBOL nonTerminalToDerive;
        public List<DERIVATION> derivations;

        public PRODUCTION(XmlNode production_XML)
        {
            nonTerminalToDerive = new SYMBOL(production_XML.Name,SYMBOL_TYPE.NON_TERMINAL);
            derivations = new List<DERIVATION>();

            XmlNodeList derivations_XML = production_XML.ChildNodes;

            foreach (XmlNode derivation_XML in derivations_XML)
            {
                DERIVATION newDerivation = new DERIVATION(derivation_XML);
                derivations.Add(newDerivation);
            }
        }
    }
}