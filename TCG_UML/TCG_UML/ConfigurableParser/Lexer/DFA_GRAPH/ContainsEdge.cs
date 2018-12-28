using System.Collections.Generic;

namespace TCG_UML.ConfigurableParser.Lexer
{
    public partial class DFA_GRAPH
    {
        private bool ContainsEdge(List<EDGE> edges, EDGE newEdge)
        {
            bool isContained = false;

            foreach (EDGE edge in edges)
            {
                if (edge.transitionCharacter == newEdge.transitionCharacter)
                {
                    isContained = true;
                }
            }
            return isContained;
        }
    }
}
