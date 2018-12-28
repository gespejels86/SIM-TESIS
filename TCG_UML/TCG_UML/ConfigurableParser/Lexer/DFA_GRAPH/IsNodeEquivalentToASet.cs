using System.Collections.Generic;
using System.Linq;

namespace TCG_UML.ConfigurableParser.Lexer
{
    public partial class DFA_GRAPH
    {
        private bool IsNodeEquivalentToASet(NODE node, List<NODES_SET> sets)
        {
            bool isEquivalentToASet = false;

            foreach (NODES_SET set in sets)
            {
                if (AreNodesEquivalent(set.nodesSet.First(), node))
                {
                    set.nodesSet.Add(node);
                    node.assignedSet = set;
                    isEquivalentToASet = true;
                }
            }
            return isEquivalentToASet;
        }
    }
}
