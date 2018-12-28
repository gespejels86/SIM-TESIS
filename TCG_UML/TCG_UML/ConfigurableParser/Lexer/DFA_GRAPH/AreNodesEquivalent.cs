
namespace TCG_UML.ConfigurableParser.Lexer
{
    public partial class DFA_GRAPH
    {
        private bool AreNodesEquivalent(NODE nodeOne, NODE nodeTwo)
        {
            bool areEquivalent = true;

            if (nodeOne != null && nodeTwo != null)
            {
                if (AreEdgesEquivalent(nodeOne.edges, nodeTwo.edges))
                {
                    for (int i = 0; i < nodeOne.edges.Count; i++)
                    {
                        if (nodeOne.edges[i].nextNode != nodeTwo.edges[i].nextNode)
                        {
                            areEquivalent = false;
                        }
                    }
                }
                else
                {
                    areEquivalent = false;
                }
            }
            else
            {
                areEquivalent = false;
            }
            return areEquivalent;
        }
    }
}
