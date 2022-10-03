using System.Windows.Forms;

namespace TCG_UML
{
    public partial class WorkspaceHandler
    {
        public bool CreateProject()
        {
            Project newProject = new Project("n/a", "new", WorkspaceTreeNode);

            NewProjectForm newProjectForm = new NewProjectForm(workspacePath, newProject);
            newProjectForm.ShowDialog();

            if (newProject.treeNode != null)
            {
                if (selectedProject != null)
                {
                    selectedProject.Form.Hide();
                }

                selectedProject = newProject;

                Projects.Add(newProject);

                selectedProject.Form.MdiParent = MainGUI.ActiveForm;
                selectedProject.Form.Dock = DockStyle.Fill;


                logViewForm.MdiParent = MainGUI.ActiveForm;
                logViewForm.Dock = DockStyle.Bottom;

                treeProjectViewForm.MdiParent = MainGUI.ActiveForm;
                treeProjectViewForm.Dock = DockStyle.Left;

                treeProjectViewForm.Show();
                logViewForm.Show();
                selectedProject.Form.Show();

                logViewForm.GetTextBox().Text += "Project " + newProject.GetName() + " created!!\n";

                return true;
            }
            else
            {
                logViewForm.GetTextBox().Text += "Project not created!!\n";

                return false;
            }
        }
    }
}
