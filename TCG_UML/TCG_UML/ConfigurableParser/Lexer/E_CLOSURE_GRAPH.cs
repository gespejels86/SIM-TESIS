using System;
using System.Collections.Generic;

namespace TCG_UML.ConfigurableParser.Lexer
{
    public partial class E_CLOSURE_GRAPH : IDisposable
    {
        public E_CLOSURE_NODE StartNode;

        private Stack<NODE> nodesStack;
        private Dictionary<int, E_CLOSURE_NODE> eClosureNodes = new Dictionary<int, E_CLOSURE_NODE>();

        public E_CLOSURE_GRAPH(NFA_GRAPH nfaGraph)
        {
            if (nfaGraph != null)
            {
                nodesStack = new Stack<NODE>();
                nodesStack.Push(nfaGraph.startNode);

                StartNode = Get_EClosureNode(nodesStack);
            }

            E_CLOSURE_NODE.ClearCount();
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
                foreach (NODE node in nodesStack)
                {
                    node.Dispose();
                }
                foreach (KeyValuePair<int, E_CLOSURE_NODE> pair in eClosureNodes)
                {
                    pair.Value.Dispose();
                }
                nodesStack.Clear();
                eClosureNodes.Clear();
            }
        }

        ~E_CLOSURE_GRAPH()
        {
            Dispose(false);
        }
    }  
}
