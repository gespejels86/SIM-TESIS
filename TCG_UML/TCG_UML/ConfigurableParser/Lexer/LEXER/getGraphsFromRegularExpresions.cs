using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Xml;

namespace TCG_UML.ConfigurableParser.Lexer
{
    public partial class LEXER
    {
        private void getGraphsFromRegularExpresions(XmlDocument regEx_Xml)
        {
            regularExpresions = new Dictionary<string, REG_EXP>();
            //Transform all the regular expressions to DFA regularExpresions
            XmlNodeList regExs = regEx_Xml.LastChild.ChildNodes;

            foreach (XmlNode regEx in regExs)
            {

                REG_EXP newRegExp = new REG_EXP(regEx.InnerText, regEx.Attributes["ignore"].Value);
                regularExpresions.Add(regEx.Name, newRegExp);

            }
        }

        public Image drawNFAGraph(int graph)
        {
            ArrayList arrayList = new ArrayList(regularExpresions.Values);
            return drawGraph(((REG_EXP)arrayList[graph]).get_NFAGraph().startNode);
        }

        public Image drawDFAGraph(int graph)
        {
            ArrayList arrayList = new ArrayList(regularExpresions.Values);
            return drawGraph(((REG_EXP)arrayList[graph]).get_DFAGraph().startNode); ;
        }

        public Image drawEClosureGraph(int graph)
        {
            ArrayList arrayList = new ArrayList(regularExpresions.Values);
            return drawGraph(((REG_EXP)arrayList[graph]).get_EClosureGraph().StartNode);
        }
    }
}
