using System;
using System.Windows.Forms;
using System.Xml;
using TCG_UML.ConfigurableParser.Lexer;

namespace TCG_UML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument regEx_xml = new XmlDocument();

            regEx_xml.Load("C:\\Users\\Gustavo\\Desktop\\Maestria\\GItHubProject\\SIM-TESIS\\Architecture\\ConfigurableParser\\RegularExpressions.xml");

            //RE2DFA re2dfa = new RE2DFA(regEx_xml);
            LEXER lexer = new LEXER(regEx_xml);

            PictureBox.Image = lexer.drawNFAGraph(0);
            pictureBox1.Image = lexer.drawEClosureGraph(1);
            pictureBox2.Image = lexer.drawDFAGraph(2);
        }
    }
}
