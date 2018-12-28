using System.Collections.Generic;

namespace TCG_UML.ConfigurableParser.Lexer
{
    public partial class E_CLOSURE_GRAPH
    {
        public E_CLOSURE_NODE Get_EClosureNode(Stack<NODE> NFANodesStack)
        {
            E_CLOSURE_NODE eClosureNode = null;
            Dictionary<char, Stack<NODE>> moveToDictionary = new Dictionary<char, Stack<NODE>>();

            eClosureNode = Perform_EClosureOperation(NFANodesStack, moveToDictionary);
            eClosureNode = Perform_MoveToOperation(eClosureNode, moveToDictionary);

            return eClosureNode;
        }
    }
}
