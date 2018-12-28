using System.Collections.Generic;


namespace TCG_UML.ConfigurableParser.Lexer
{
    public partial class E_CLOSURE_GRAPH
    {
        private E_CLOSURE_NODE Perform_MoveToOperation(E_CLOSURE_NODE eClosureNode, Dictionary<char, Stack<NODE>> moveToDictionary)
        {
            E_CLOSURE_NODE eClosureNode_it = Find_EClosureNode(eClosureNode);
            E_CLOSURE_NODE return_eClosureNode;

            if (eClosureNode_it != null)
            {
                eClosureNode.Delete();

                return_eClosureNode = eClosureNode_it;
            }
            else
            {
                eClosureNodes.Add(eClosureNode.NodeID, eClosureNode);

                foreach (KeyValuePair<char, Stack<NODE>> moveTo in moveToDictionary)
                {
                    EDGE newEClosureEdge = new EDGE(moveTo.Key, Get_EClosureNode(moveTo.Value));
                    eClosureNode.edges.Add(newEClosureEdge);
                }

                return_eClosureNode = eClosureNode;
            }

            return return_eClosureNode;
        }

        private E_CLOSURE_NODE Find_EClosureNode(E_CLOSURE_NODE eClosureNode)
        {
            bool isEqual;
            foreach (KeyValuePair<int, E_CLOSURE_NODE> EClosureDicElement in eClosureNodes)
            {
                isEqual = true;

                if (EClosureDicElement.Value.NFANodes.Count == eClosureNode.NFANodes.Count)
                {
                    for (int i = 0; i < eClosureNode.NFANodes.Count; i++)
                    {
                        if (EClosureDicElement.Value.NFANodes[i].NodeID != eClosureNode.NFANodes[i].NodeID)
                        {
                            isEqual = false;
                        }
                    }
                }
                else
                {
                    isEqual = false;
                }
                if (isEqual)
                {
                    return EClosureDicElement.Value;
                }
            }

            return null;
        }
    }
}
