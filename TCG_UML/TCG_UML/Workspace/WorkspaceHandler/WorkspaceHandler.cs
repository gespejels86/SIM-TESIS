using System.Collections.Generic;
using System.Windows.Forms;

namespace TCG_UML
{
    public partial class WorkspaceHandler
    {
        private TreeProjectViewForm treeProjectViewForm = null;
        private LogViewForm logViewForm = null;
        private List<Project> Projects = new List<Project>();
        public Project selectedProject;
        private string workspacePath = null;
        public TreeNode WorkspaceTreeNode = null;
        public static WorkspaceHandler instance = null;


        private WorkspaceHandler()
        {
            treeProjectViewForm = new TreeProjectViewForm();

            logViewForm = new LogViewForm();

            GetWorkspaceContext();

            if (workspacePath == "notDefined")
            {
                CreateWorkspace();
                LoadWorkspace();
            }
            else
            {
                LoadWorkspace();
            }
        }

        public static WorkspaceHandler GetInstance()
        {
            if (instance == null)
            {
                instance = new WorkspaceHandler();
            }

            return instance;
        } 
    }
}
