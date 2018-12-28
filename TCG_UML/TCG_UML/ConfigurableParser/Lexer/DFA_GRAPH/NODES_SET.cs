using System;
using System.Collections.Generic;

namespace TCG_UML.ConfigurableParser.Lexer
{
    public class NODES_SET : IDisposable
    {
        public int id;
        public HashSet<NODE> nodesSet;
        private static int SetsCounter = 0;

        private NODES_SET(int assignedID)
        {
            this.id = assignedID;
            nodesSet = new HashSet<NODE>();
        }

        public static NODES_SET CreateNodesSet()
        {
            return new NODES_SET(SetsCounter++);
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
                foreach (NODE node in nodesSet)
                {
                    node.Dispose();                    
                }
                nodesSet.Clear();
            }
        }

        public static void ClearCount()
        {
            SetsCounter = 0;
        }

        ~NODES_SET()
        {
            Dispose(false);
        }
    }
}
