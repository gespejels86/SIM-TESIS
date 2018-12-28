
namespace TCG_UML.ConfigurableParser.Lexer
{
    public partial class NFA_GRAPH
    {

        private  
            NFA_GRAPH 
            Process_ConcatenationSymbol
            ( int regExp_itr,
              int EndOfRegEx_itr,
              NFA_GRAPH nfaGraph )
        {
            NFA_GRAPH newGraph = null;

            newGraph = Create_NFAOneChar(regExp[regExp_itr]);

            newGraph = Process_KleeneClosureSymbol(ref regExp_itr, EndOfRegEx_itr, newGraph);

            newGraph = Create_NFAConcatenation(nfaGraph, newGraph);

            newGraph = Get_NFAFromRE(regExp_itr + 1, EndOfRegEx_itr, newGraph);

            return newGraph;
        }
    }
}
