using System.Collections.Generic;
using System.Linq;

namespace TCG_UML.ConfigurableParser.Lexer
{
    public partial class DFA_GRAPH
    {
        private bool Perform_SetSplitting(NODES_SET set, List<NODES_SET> newNodeSets)
        {
            bool existedChange = false;
            HashSet<NODE> nodesToDelete = new HashSet<NODE>();

            if (set.nodesSet.Count > 1)
            {
                foreach (NODE nodesSet_it in set.nodesSet)
                {
                    if (nodesSet_it != set.nodesSet.First())
                    {
                        if (!AreNodesEquivalent(set.nodesSet.First(), nodesSet_it))
                        {
                            existedChange = true;

                            if (!IsNodeEquivalentToASet(nodesSet_it, newNodeSets))
                            {
                                NODES_SET newSet = NODES_SET.CreateNodesSet();
                                nodesSet_it.assignedSet = newSet;
                                newSet.nodesSet.Add(nodesSet_it);
                                newNodeSets.Add(newSet);
                            }

                            nodesToDelete.Add(nodesSet_it);
                        }
                    }
                }

                foreach (NODE nodeToDelete in nodesToDelete)
                {
                    set.nodesSet.Remove(nodeToDelete);

                }
            }
            return existedChange;
        }
    }
}
