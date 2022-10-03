using System.Windows.Forms;

namespace TCG_UML
{
    public partial class NewProjectForm : Form
    {
        private Project newProject = null;

        public NewProjectForm(string workspacePath, Project project)
        {
            newProject = project;

            InitializeComponent();

            LocationTextBox.Text = workspacePath + "\\";
        }
    }
}
