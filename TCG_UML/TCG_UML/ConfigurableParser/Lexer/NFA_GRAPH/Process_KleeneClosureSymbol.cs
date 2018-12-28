
namespace TCG_UML.ConfigurableParser.Lexer
{
    public partial class NFA_GRAPH
    {

        private  
            NFA_GRAPH 
            Process_KleeneClosureSymbol
            ( ref int regExp_itr,
              int EndOfRegEx_itr,
              NFA_GRAPH nfaGraph)
        {
            NFA_GRAPH newGraph = nfaGraph;

            if (regExp_itr + 1 != EndOfRegEx_itr)
            {
                if (regExp[(regExp_itr + 1)].ToString() == CONSTANTS.KLEENE_STAR_SYMBOL)
                {
                    newGraph = Create_NFAKleeneClosure(nfaGraph);
                    regExp_itr++;
                }
            }

            return newGraph;
        }
    }
}
