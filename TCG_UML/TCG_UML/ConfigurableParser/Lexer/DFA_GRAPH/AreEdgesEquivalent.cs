using System.Collections.Generic;

namespace TCG_UML.ConfigurableParser.Lexer
{
    public partial class DFA_GRAPH
    {
        private bool AreEdgesEquivalent(List<EDGE> edgeOne, List<EDGE> edgeTwo)
        {
            bool areEquivalent = true;

            if (edgeOne.Count == edgeTwo.Count)
            {

                for (int i = 0; i < edgeOne.Count; i++)
                {
                    if (edgeOne[i].transitionCharacter != edgeTwo[i].transitionCharacter)
                    {
                        areEquivalent = false;
                    }
                }
            }
            else
            {
                areEquivalent = false;
            }

            return areEquivalent;
        }
    }
}
