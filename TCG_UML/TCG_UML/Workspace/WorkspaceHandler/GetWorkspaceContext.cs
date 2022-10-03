using System.Xml;

namespace TCG_UML
{
    public partial class WorkspaceHandler
    {
        private void GetWorkspaceContext()
        {
            XmlDocument configurationXML = new XmlDocument();
            XmlNode workspaceNode = null;

            configurationXML.Load("D:\\vsWorkspace\\SIM-TESIS\\Architecture\\ConfigurableParser\\TCG_UML_Configuration.xml");

            workspaceNode = configurationXML.SelectSingleNode("/tcg_uml_configuration/workspace");

            if (workspaceNode != null)
            {
                workspacePath = workspaceNode.Attributes["path"].Value;

                if (workspaceNode.HasChildNodes)
                {
                    foreach (XmlNode xmlNode in workspaceNode.ChildNodes)
                    {
                        Project newProject = new Project(xmlNode);
                    }
                }
            }
        }
    }
}
