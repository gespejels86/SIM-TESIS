
using System;

namespace TCG_UML.ConfigurableParser.Lexer
{
    public partial class REG_EXP : IDisposable
    {
        private string regExp_str;
        private bool ignore;
        private DFA_GRAPH dfaGraph;
        private NFA_GRAPH nfaGraph;
        private E_CLOSURE_GRAPH eClosureGraph;

        public REG_EXP(string regExp_str, string ignore)
        {
            this.regExp_str = regExp_str;
            nfaGraph = new NFA_GRAPH(regExp_str);
            
            eClosureGraph = new E_CLOSURE_GRAPH(nfaGraph);
            
            dfaGraph = new DFA_GRAPH(eClosureGraph);

            if (ignore == "no")
            {
                this.ignore = false;
            }
            else
            {
                this.ignore = true;
            }
            
        }

        public NFA_GRAPH get_NFAGraph()
        {
            return nfaGraph;
        }

        public bool GetIgnore()
        {
            return ignore;
        }

        public E_CLOSURE_GRAPH get_EClosureGraph()
        {
            return eClosureGraph;
        }

        public DFA_GRAPH get_DFAGraph()
        {
            return dfaGraph;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool dispossing)
        {
            if (dispossing)
            {
                nfaGraph.Dispose();
                eClosureGraph.Dispose();
                dfaGraph.Dispose();
            }
        }

        ~REG_EXP()
        {
            Dispose(false);
        }
    }
}
