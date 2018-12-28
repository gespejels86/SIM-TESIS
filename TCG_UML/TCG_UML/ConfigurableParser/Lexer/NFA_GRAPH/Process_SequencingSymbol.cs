
namespace TCG_UML.ConfigurableParser.Lexer
{
    public partial class NFA_GRAPH
    {

        private  
            NFA_GRAPH 
            Process_SequencingSymbol
            ( int regExp_itr,
              int EndOfRegEx_itr,
              NFA_GRAPH nfaGraph)
        {
            NFA_GRAPH newGraph = null;

            char sequenceIterator = (char)0;

            int startSubRE = regExp_itr + 1;
            int endSubRE = Get_IndexOfSequenceClosingSybol(regExp_itr + 1, EndOfRegEx_itr);


            if (endSubRE != 0)
            {

                regExp_itr = endSubRE;

                if (regExp[endSubRE - 1] > regExp[startSubRE])
                {


                    while ((regExp[startSubRE] + sequenceIterator) <= regExp[(endSubRE - 1)])
                    {
                        newGraph = Create_NFAUnion(Create_NFAOneChar((char)(regExp[startSubRE] + sequenceIterator)), newGraph);
                        sequenceIterator++;
                    }

                    newGraph = Process_KleeneClosureSymbol(ref regExp_itr, EndOfRegEx_itr, newGraph);

                    newGraph = Create_NFAConcatenation(nfaGraph, newGraph);

                    newGraph = Get_NFAFromRE(regExp_itr + 1, EndOfRegEx_itr, newGraph);
                }
                else
                {
                    newGraph = null;
                    //TODO: Log an Error
                }
            }
            else
            {
                newGraph = null;
                //TODO: Log an Error
            }

            return newGraph;
        }

        private 
           int
           Get_IndexOfSequenceClosingSybol
           ( int regExp_itr,
             int EndOfRegEx_itr)
        {
            int openSequencingSymbolsCounter = 1;
            int endSubRE = regExp_itr;

            while (openSequencingSymbolsCounter != 0 && endSubRE != EndOfRegEx_itr)
            {
                if (regExp[endSubRE].ToString() == CONSTANTS.CLOSE_SEQUENCING_SYMBOL)
                {
                    openSequencingSymbolsCounter--;
                }
                if (regExp[endSubRE].ToString() == CONSTANTS.OPEN_SEQUENCING_SYMBOL)
                {
                    openSequencingSymbolsCounter++;
                }

                endSubRE++;
            }

            if (openSequencingSymbolsCounter == 0)
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
