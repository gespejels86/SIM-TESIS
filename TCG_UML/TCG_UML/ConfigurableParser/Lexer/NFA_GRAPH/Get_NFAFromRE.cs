
namespace TCG_UML.ConfigurableParser.Lexer
{
    public partial class NFA_GRAPH
    {
        private NFA_GRAPH Get_NFAFromRE
            ( int regExp_itr, 
              int EndOfRegEx_itr, 
              NFA_GRAPH nfaGraph )
        {
            NFA_GRAPH new_NFAGraph = null;

            if (regExp_itr != EndOfRegEx_itr)
            {
                switch (regExp[regExp_itr].ToString())
                {
                    case CONSTANTS.UNION_SYMBOL:

                        new_NFAGraph = Process_UnionSymbol(regExp_itr, EndOfRegEx_itr, nfaGraph);

                        break;

                    case CONSTANTS.OPEN_GROUPING_SYMBOL:

                        new_NFAGraph = Process_GroupingSymbol(regExp_itr, EndOfRegEx_itr, nfaGraph);

                        break;

                    case CONSTANTS.CLOSE_GROUPING_SYMBOL:

                        new_NFAGraph = null;
                        //ToDo: Log an Error

                        break;

                    case CONSTANTS.SKIPPING_SYMBOL:

                        new_NFAGraph = Process_SkippingSymbol(regExp_itr, EndOfRegEx_itr, nfaGraph);

                        break;

                    case CONSTANTS.KLEENE_STAR_SYMBOL:

                        new_NFAGraph = null;
                        regExp_itr++;
                        //ToDo: Log an Error

                        break;

                    case CONSTANTS.OPEN_SEQUENCING_SYMBOL:

                        new_NFAGraph = Process_SequencingSymbol(regExp_itr, EndOfRegEx_itr, nfaGraph );

                        break;

                    default:

                        new_NFAGraph = Process_ConcatenationSymbol(regExp_itr, EndOfRegEx_itr, nfaGraph);

                        break;
                }

            }

            if (new_NFAGraph == null)
                new_NFAGraph = nfaGraph;

            return new_NFAGraph;
        }

    }
}
