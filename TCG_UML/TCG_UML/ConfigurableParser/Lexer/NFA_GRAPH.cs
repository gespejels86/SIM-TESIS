using System;

namespace TCG_UML.ConfigurableParser.Lexer
{
    public partial class NFA_GRAPH : IDisposable
    {
        public NODE startNode;
        public NODE endNode;
        private string regExp;

        public NFA_GRAPH(NODE assignedStartNode, NODE assignedEndNode)
        {
            this.startNode = assignedStartNode;
            this.endNode = assignedEndNode;
        }

        public NFA_GRAPH(string regExp_str)
        {
            regExp = regExp_str;
            NFA_GRAPH nfaGraph = null;

            nfaGraph = Get_NFAFromRE(0, this.regExp.Length, null);

            startNode = nfaGraph.startNode;
            endNode = nfaGraph.endNode;

            NODE.ClearCount();
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
                startNode.Dispose();
                endNode.Dispose();
            }
        }

        ~NFA_GRAPH()
        {
            Dispose(false);
        }
    }
}
