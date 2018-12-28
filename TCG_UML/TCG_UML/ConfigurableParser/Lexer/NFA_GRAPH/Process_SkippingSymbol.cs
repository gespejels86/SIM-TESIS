
namespace TCG_UML.ConfigurableParser.Lexer
{
    public partial class NFA_GRAPH
    {

        private  
            NFA_GRAPH 
            Process_SkippingSymbol
            ( int regExp_itr,
              int EndOfRegEx_itr,
              NFA_GRAPH nfaGraph )
        {
            NFA_GRAPH newGraph = null;

            if (regExp_itr + 1 < EndOfRegEx_itr)
                newGraph = Process_ConcatenationSymbol(regExp_itr + 1, EndOfRegEx_itr, null);

            return newGraph;
        }
    }
}
