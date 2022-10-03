using System;

namespace TCG_UML
{
    public partial class NewProjectForm
    {
        private void CancelButton_Click(object sender, EventArgs e)
        {
            newProject.SetName("new");
            newProject.directory = "n/a";

            if (newProject.treeNode != null)
            {
                newProject.treeNode.Remove();
            }
            newProject.treeNode = null;

            this.Close();
        }
    }
}
