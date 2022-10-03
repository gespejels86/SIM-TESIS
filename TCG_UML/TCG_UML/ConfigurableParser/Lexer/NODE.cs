using System;
using System.Collections.Generic;

namespace TCG_UML.ConfigurableParser.Lexer
{
    public partial class NODE : IDisposable
    {
        public NODE_TYPE nodeType;
        public List<EDGE> edges;
        public Dictionary<char, NODE> edgesHash;
        public int NodeID = 0;
        protected static int NodesCounter = 0;
        public NODES_SET assignedSet;

        public NODE(NODE_TYPE type, int nodeID)
        {
            nodeType = type;
            NodeID = nodeID;
            edges = new List<EDGE>();
        }

        public static NODE CreateNode(NODE_TYPE type) {

            return new NODE(type, NodesCounter++);
        }

        protected NODE()
        {
        }

        public static NODE CreateNode(NODE_TYPE nodeType, int nodeID)
        {
            return new NODE(nodeType, nodeID);
        }

        public static void ClearCount()
        {
            NodesCounter = 0;
        }

        public void Get_EdgesHash()
        {

            edgesHash = new Dictionary<char, NODE>();

            foreach (EDGE edge in edges)
            {
                edgesHash.Add(edge.transitionCharacter, edge.nextNode);
            }
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
                foreach (EDGE edge in edges)
                {
                    edge.Dispose();
                }
            }
        }

        ~NODE()
        {
            Dispose(false);
        }
    }
}
