using System.IO;
using System.Windows.Forms;

namespace TCG_UML
{
    public partial class WorkspaceHandler
    {
        private void LoadWorkspace()
        {
            DirectoryInfo di = new DirectoryInfo(workspacePath);
            treeProjectViewForm = new TreeProjectViewForm();
            TreeNode tds = treeProjectViewForm.GetProjectTree().Nodes.Add(di.Name);
            tds.Tag = di.FullName;
            tds.StateImageIndex = 0;
            LoadFiles(workspacePath, tds);
            LoadSubdirectories(workspacePath, tds);
            WorkspaceTreeNode = tds;
        }

        private void LoadSubdirectories(string dir, TreeNode td)
        {
            string[] subdirectoryEntries = Directory.GetDirectories(dir);

            foreach (string subdirectory in subdirectoryEntries)
            {
                DirectoryInfo di = new DirectoryInfo(subdirectory);
                TreeNode tds = td.Nodes.Add(di.Name);
                tds.StateImageIndex = 0;
                tds.Tag = di.FullName;
                LoadFiles(subdirectory, tds);
                LoadSubdirectories(subdirectory, tds);
            }
        }

        private void LoadFiles(string dir, TreeNode td)
        {
            string[] Files = Directory.GetFiles(dir, "*.*");

            foreach (string file in Files)
            {
                FileInfo fi = new FileInfo(file);
                TreeNode tds = td.Nodes.Add(fi.Name);
                tds.Tag = fi.FullName;
                tds.StateImageIndex = 1;
            }

        }
    }
}
