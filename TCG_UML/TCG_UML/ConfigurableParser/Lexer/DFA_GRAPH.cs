using System;
using System.Collections.Generic;

namespace TCG_UML.ConfigurableParser.Lexer
{
    public partial class DFA_GRAPH : IDisposable
    {
        public NODE startNode;

        private List<NODES_SET> DFASets;
        private List<NODE> DFANodes;

        public DFA_GRAPH(E_CLOSURE_GRAPH eClosureGraph)
        {
            if (eClosureGraph != null)
            {
                DFASets = new List<NODES_SET>();
                DFANodes = new List<NODE>();

                Get_DFAGraphFromEClosureGraph(eClosureGraph);
                Perform_DFAMinimization();
                Perform_EdgesOptimization();
            }
            NODE.ClearCount();
            NODES_SET.ClearCount();
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
                foreach (NODES_SET set in DFASets)
                {
                    set.Dispose();
                }
            }

            foreach (NODE node in DFANodes)
            {
                node.Dispose();
            }

            DFASets.Clear();
            DFANodes.Clear();
        }

        ~DFA_GRAPH()
        {
            Dispose(false);
        }

    }
}
