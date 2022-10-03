using System;
using System.Windows.Forms;

namespace TCG_UML
{
    public partial class NewProjectForm
    {
        private void SearchButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    newProject.directory = fbd.SelectedPath;
                }
            }
        }
    }
}
