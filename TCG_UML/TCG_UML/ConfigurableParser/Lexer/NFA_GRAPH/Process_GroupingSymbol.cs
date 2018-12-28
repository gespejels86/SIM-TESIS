

namespace TCG_UML.ConfigurableParser.Lexer
{
    public partial class NFA_GRAPH
    {

        private  
            NFA_GRAPH 
            Process_GroupingSymbol
            ( int regExp_itr, 
              int EndOfRegEx_itr,
              NFA_GRAPH nfaGraph )
        {
            NFA_GRAPH newGraph = null;

            int startSubRE = regExp_itr + 1;
            int endSubRE = Get_IndexOfGroupClosingSybol(regExp_itr + 1, EndOfRegEx_itr);


            if (endSubRE != 0)
            {
                regExp_itr = endSubRE;

                newGraph = Get_NFAFromRE(startSubRE, endSubRE, null);

                newGraph = Process_KleeneClosureSymbol(ref regExp_itr, EndOfRegEx_itr, newGraph);

                newGraph = Create_NFAConcatenation(nfaGraph, newGraph);

                newGraph = Get_NFAFromRE(regExp_itr + 1, EndOfRegEx_itr, newGraph);

            }
            else
            {
                newGraph = null;
            }

            return newGraph;

        }

        private  
            int 
            Get_IndexOfGroupClosingSybol
            ( int regExp_itr,
              int EndOfRegEx_itr )
        {
            int openGroupingSymbolsCounter = 1;
            int endSubRE = regExp_itr;

            while (openGroupingSymbolsCounter != 0 && endSubRE != EndOfRegEx_itr)
            {
                if (regExp[endSubRE].ToString() == CONSTANTS.CLOSE_GROUPING_SYMBOL)
                {
                    openGroupingSymbolsCounter--;
                }
                if (regExp[endSubRE].ToString() == CONSTANTS.OPEN_GROUPING_SYMBOL)
                {
                    openGroupingSymbolsCounter++;
                }

                endSubRE++;
            }

            if (openGroupingSymbolsCounter == 0)
            {
                endSubRE--;
                return endSubRE;
            }
            else
            {
                return 0;
            }

        }
    }
}
