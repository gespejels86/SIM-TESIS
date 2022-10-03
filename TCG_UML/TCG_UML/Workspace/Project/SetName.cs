

namespace TCG_UML
{
    public partial class Project
    {
        public void SetName(string Name)
        {
            this.name = Name;
            this.Form.Text = Name;
            treeNode.Tag = Name;
            treeNode.Name = Name;
            treeNode.Text = Name;
        }

        public string GetName()
        {
            return this.name;
        }
    }
}
