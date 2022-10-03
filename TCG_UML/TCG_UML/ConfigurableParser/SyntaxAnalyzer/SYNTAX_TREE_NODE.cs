using System;
using System.Collections.Generic;
using TCG_UML.ConfigurableParser.Lexer;

namespace TCG_UML.ConfigurableParser.SyntaxAnalyzer
{
    public partial class SYNTAX_TREE_NODE
    {
        public SYMBOL symbol;
        public TOKEN token;
        public List<SYNTAX_TREE_NODE> derivedNodes;


        public SYNTAX_TREE_NODE()
        {
            symbol = null;
            token = null;
            derivedNodes = null;
        }

        public void GetSymbolAttributes(SYMBOL symbol)
        {
            this.symbol = symbol;
        }

        public void GetSymbolAttributes(SYMBOL symbol, TOKEN token)
        {
            this.symbol = symbol;
            this.token = token;
        }

        public void Clear()
        {
            if (derivedNodes != null)
            {
                derivedNodes.Clear();
            }
        }

        internal void AddDerivation(SYNTAX_TREE_NODE derivedNode)
        {
            if (derivedNodes == null)
            {
                derivedNodes = new List<SYNTAX_TREE_NODE>();
            }

            derivedNodes.Add(derivedNode);
        }
    }
}
