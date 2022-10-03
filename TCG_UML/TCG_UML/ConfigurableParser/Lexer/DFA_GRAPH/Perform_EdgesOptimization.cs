
namespace TCG_UML.ConfigurableParser.Lexer
{
    public partial class DFA_GRAPH
    {
        private void Perform_EdgesOptimization()
        {
            foreach (NODE node in DFANodes)
            {
                node.Get_EdgesHash();
            }
            startNode.Get_EdgesHash();
        }
    }
}
