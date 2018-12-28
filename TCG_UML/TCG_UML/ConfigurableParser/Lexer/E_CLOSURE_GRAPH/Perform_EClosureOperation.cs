using System.Collections.Generic;
using System.Linq;

namespace TCG_UML.ConfigurableParser.Lexer
{
    public partial class E_CLOSURE_GRAPH
    {

        private E_CLOSURE_NODE Perform_EClosureOperation(Stack<NODE> NFANodesStack, Dictionary<char, Stack<NODE>> moveToDictionary)
        {
            HashSet<NODE> visitedNodes = new HashSet<NODE>();
            NODE nodeUnderProcess = null;
            E_CLOSURE_NODE eClosureNode = null;

            if (NFANodesStack.Count() != 0)
            {
                eClosureNode = E_CLOSURE_NODE.Create_Node(NODE_TYPE.TRANSITIONING);

                while (NFANodesStack.Count() != 0)
                {
                    nodeUnderProcess = NFANodesStack.Pop();

                    eClosureNode.NFANodes.Add(nodeUnderProcess);

                    if (nodeUnderProcess.nodeType == NODE_TYPE.END)
                        eClosureNode.nodeType = NODE_TYPE.END;

                    if (nodeUnderProcess.nodeType == NODE_TYPE.START)
                        eClosureNode.nodeType = NODE_TYPE.START;

                    foreach (EDGE edge in nodeUnderProcess.edges)
                    {

                        if (!visitedNodes.Contains(edge.nextNode))
                        {
                            visitedNodes.Add(edge.nextNode);

                            if (edge.transitionCharacter == CONSTANTS.EMPTY_SYMBOL)
                                NFANodesStack.Push(edge.nextNode);
                            else
                            {
                                if (!moveToDictionary.ContainsKey(edge.transitionCharacter))
                                {
                                    moveToDictionary.Add(edge.transitionCharacter, new Stack<NODE>());
                                }
                                moveToDictionary[edge.transitionCharacter].Push(edge.nextNode);
                            }
                        }
                    }
                }

                eClosureNode.NFANodes.OrderBy(NFANode => NFANode.NodeID);
            }

            return eClosureNode;
        }
    }
}
