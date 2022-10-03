using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCG_UML.ConfigurableParser.SyntaxAnalyzer
{
    public class SYNTAX_TREE
    {
        public SYNTAX_TREE_NODE stNode;

        public SYNTAX_TREE(SYNTAX_TREE_NODE stNode)
        {
            this.stNode = stNode;
        }
    }
}
