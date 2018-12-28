using System.Collections.Generic;
using System.Linq;

namespace TCG_UML.ConfigurableParser.Lexer
{
    public partial class DFA_GRAPH
    {
        private void Get_DFAGraphFromEClosureGraph(E_CLOSURE_GRAPH eClosureGraph)
        {
            HashSet<E_CLOSURE_NODE> visitedNodes = new HashSet<E_CLOSURE_NODE>();
            Stack<E_CLOSURE_NODE> EClosureNodesToProcess = new Stack<E_CLOSURE_NODE>();
            Stack<NODE> NodesToProcess = new Stack<NODE>();

            E_CLOSURE_NODE eClosureNodeInProcess = null;
            NODE node = null;
            NODE newNode = null;

            EClosureNodesToProcess.Push(eClosureGraph.StartNode);

            startNode = NODE.CreateNode(eClosureGraph.StartNode.nodeType, eClosureGraph.StartNode.NodeID);
            NodesToProcess.Push(startNode);

            while (EClosureNodesToProcess.Count != 0)
            {
                eClosureNodeInProcess = EClosureNodesToProcess.Pop();
                node = NodesToProcess.Pop();
                visitedNodes.Add(eClosureNodeInProcess);
                DFANodes.Add(node);

                foreach (EDGE edge in eClosureNodeInProcess.edges)
                {

                    if (!visitedNodes.Contains((E_CLOSURE_NODE)edge.nextNode))
                    {
                        newNode = NODE.CreateNode(edge.nextNode.nodeType, edge.nextNode.NodeID);
                        
                    }
                    else
                    {
                        newNode = DFANodes.Find(findNode => findNode.NodeID == edge.nextNode.NodeID);
                    }
                    node.edges.Add(new EDGE(edge.transitionCharacter, newNode));

                    if (!visitedNodes.Contains((E_CLOSURE_NODE)edge.nextNode))
                    {
                        EClosureNodesToProcess.Push((E_CLOSURE_NODE)edge.nextNode);
                        NodesToProcess.Push(newNode);
                    }
                }

            }
        }
    }
}
