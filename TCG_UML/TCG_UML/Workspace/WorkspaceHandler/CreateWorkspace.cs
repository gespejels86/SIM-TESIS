using System.Windows.Forms;

namespace TCG_UML
{
    public partial class WorkspaceHandler
    {
        public void CreateWorkspace()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                fbd.Description = "Select Workspace...";

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    workspacePath = fbd.SelectedPath;
                }
            }
        }
    }
}
