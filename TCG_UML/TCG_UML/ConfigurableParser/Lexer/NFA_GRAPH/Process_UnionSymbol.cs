
namespace TCG_UML.ConfigurableParser.Lexer
{
    public partial class NFA_GRAPH
    {

        private 
            NFA_GRAPH 
            Process_UnionSymbol
            ( int regExp_itr, 
              int EndOfRegEx_itr,
              NFA_GRAPH nfaGraph )
        {
            return Create_NFAUnion(nfaGraph, Get_NFAFromRE(regExp_itr + 1, EndOfRegEx_itr, null));
        }
    }
}
