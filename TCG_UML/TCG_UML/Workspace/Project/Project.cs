using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using TCG_UML.ConfigurableParser.Lexer;

namespace TCG_UML
{
    public partial class Project
    {
        public ProjectForm Form = null;
        public string directory = null;
        private string name = null;
        private XmlNode xmlNode;
        public TreeNode treeNode;

        private LEXER lexer = null;
        private List<TOKEN> tokensList = null;

        public Project(XmlNode xmlNode)
        {
            this.xmlNode = xmlNode;
        }

        public Project(string directory, string name, TreeNode WorkspaceTreeNode)
        {
            Form = new ProjectForm();
            this.directory = directory;
            this.name = name;
            Form.Text = this.name;

            treeNode = WorkspaceTreeNode.Nodes.Add(name);
            treeNode.Tag = name;
            treeNode.StateImageIndex = 0;
        }

        public void GetLexer()
        {
            XmlDocument regEx_xml = new XmlDocument();

            regEx_xml.Load("C:\\Users\\Gustavo\\Desktop\\Maestria\\GItHubProject\\SIM-TESIS\\Architecture\\ConfigurableParser\\RegularExpressions.xml");

            lexer = new LEXER(regEx_xml);
            tokensList = new List<TOKEN>();

            string file = File.ReadAllText("C:\\Users\\Gustavo\\Desktop\\Maestria\\GItHubProject\\SIM-TESIS\\Architecture\\ConfigurableParser\\InputFile.txt");

            lexer.Tokenaize(tokensList, file);
        }
    }
}
