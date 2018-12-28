using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCG_UML.ConfigurableParser.Lexer
{
    public class E_CLOSURE_NODE : NODE
    {
        public List<NODE> NFANodes;

        private E_CLOSURE_NODE(NODE_TYPE assignedType, int ID)
        {
            nodeType = assignedType;
            NodeID = ID;
            this.edges = new List<EDGE>();
            NFANodes = new List<NODE>();
        }

        public static E_CLOSURE_NODE Create_Node(NODE_TYPE nodeType)
        {
            return new E_CLOSURE_NODE(nodeType, NodesCounter++);
        }

        public void Delete()
        {
            Dispose();
        }

        public new void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected new virtual void Dispose(bool dispossing)
        {
            if (dispossing)
            {
                foreach (EDGE edge in this.edges)
                {
                    edge.Dispose();
                }
                foreach (NODE node in NFANodes)
                {
                    node.Dispose();
                }

                this.edges.Clear();
                NFANodes.Clear();
            }
        }

        ~E_CLOSURE_NODE()
        {
            Dispose(false);
        }
    }
}
