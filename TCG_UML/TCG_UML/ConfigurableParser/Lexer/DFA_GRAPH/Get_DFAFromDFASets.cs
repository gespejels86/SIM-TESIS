using System.Collections.Generic;

namespace TCG_UML.ConfigurableParser.Lexer
{
    public partial class DFA_GRAPH
    {
        private void Get_DFAFromDFASets()
        {
            List<NODE> localDFANodes = new List<NODE>();

            if (DFASets.Count < DFANodes.Count)
            {
                foreach (NODES_SET DFASets_it in DFASets)
                {
                    localDFANodes.Add(new NODE(NODE_TYPE.TRANSITIONING, DFASets_it.id));
                }

                foreach (NODES_SET DFASets_it in DFASets)
                {

                    foreach (NODE Nodes_it in DFASets_it.nodesSet)
                    {

                        foreach (EDGE edges_it in Nodes_it.edges)
                        {
                            EDGE newEdge = new EDGE(edges_it.transitionCharacter, localDFANodes[edges_it.nextNode.assignedSet.id]);

                            if (!ContainsEdge(localDFANodes[DFASets_it.id].edges, newEdge))
                            {
                                localDFANodes[DFASets_it.id].edges.Add(newEdge);
                            }
                        }

                        if (Nodes_it.nodeType == NODE_TYPE.START && localDFANodes[DFASets_it.id].nodeType != NODE_TYPE.END)
                        {
                            localDFANodes[DFASets_it.id].nodeType = NODE_TYPE.START;
                        }

                        if (Nodes_it.nodeType == NODE_TYPE.END)
                        {
                            localDFANodes[DFASets_it.id].nodeType = NODE_TYPE.END;
                        }
                    }
                }

                startNode = localDFANodes[startNode.assignedSet.id];
            }
        }
    }
}
