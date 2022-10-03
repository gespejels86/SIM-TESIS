using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using TCG_UML.ConfigurableParser.Lexer;
using TCG_UML.ConfigurableParser.SyntaxAnalyzer;

namespace TCG_UML
{
    public partial class MainGUI : Form
    {
        private WorkspaceHandler workspaceHandler = null;
        

        public MainGUI()
        {
            if (workspaceHandler == null)
            {
                workspaceHandler = WorkspaceHandler.GetInstance();
            }

            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument regEx_xml = new XmlDocument();
            XmlDocument CFG_xml = new XmlDocument();

            List<TOKEN> tokensList = new List<TOKEN>();

            regEx_xml.Load("D:\\vsWorkspace\\SIM-TESIS\\Architecture\\ConfigurableParser\\RegularExpressions.xml");

            CFG_xml.Load("D:\\vsWorkspace\\SIM-TESIS\\Architecture\\ConfigurableParser\\PlantUML_AC_Grammar.xml");

            string file = File.ReadAllText("D:\\vsWorkspace\\SIM-TESIS\\Architecture\\ConfigurableParser\\InputFile.txt");
            
            LEXER lexer = new LEXER(regEx_xml);

            lexer.Tokenaize(tokensList, file);

            SYNTAX_ANALIZER syntaxer = new SYNTAX_ANALIZER(CFG_xml, tokensList);

            if (syntaxer.PerformSyntaxAnalysis())
            {
                PictureBox.Image = syntaxer.DrawSyntaxTree();
            }
        }

        private void FileNewProjectMenu_Click(object sender, EventArgs e)
        {

            if (workspaceHandler.CreateProject())
            {

            }
            
        }
    }
}
