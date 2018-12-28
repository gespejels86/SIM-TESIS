using System.Linq;

namespace TCG_UML.ConfigurableParser.Lexer
{
    public partial class DFA_GRAPH
    {
        private void SetInicialSetSplitting()
        {
            NODES_SET notEndDFANodes = NODES_SET.CreateNodesSet();
            NODES_SET endDFANodes = NODES_SET.CreateNodesSet();

            if (DFANodes.Count != 0)
            {
                foreach (NODE node in DFANodes)
                {
                    if (node.nodeType == NODE_TYPE.END)
                    {
                        endDFANodes.nodesSet.Add(node);
                        node.assignedSet = endDFANodes;
                    }
                    else
                    {
                        notEndDFANodes.nodesSet.Add(node);
                        node.assignedSet = notEndDFANodes;
                    }
                    node.edges.OrderBy(edge => edge.transitionCharacter);
                }
                DFASets.Add(notEndDFANodes);
                DFASets.Add(endDFANodes);
            }
        }
    }
}
