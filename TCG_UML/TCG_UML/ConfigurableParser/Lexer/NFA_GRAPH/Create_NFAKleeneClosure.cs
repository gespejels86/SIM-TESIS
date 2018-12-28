
namespace TCG_UML.ConfigurableParser.Lexer
{
    public partial class NFA_GRAPH
    {

        public static NFA_GRAPH Create_NFAKleeneClosure(NFA_GRAPH nfaGraph)
        {
            NFA_GRAPH newGraph = null;

            if (nfaGraph != null)
            {
                nfaGraph.startNode.nodeType = NODE_TYPE.TRANSITIONING;
                nfaGraph.endNode.nodeType = NODE_TYPE.TRANSITIONING;

                NODE startNode = NODE.CreateNode(NODE_TYPE.START);
                NODE endNode = NODE.CreateNode(NODE_TYPE.END);

                EDGE endEdge = new EDGE(CONSTANTS.EMPTY_SYMBOL, endNode);
                nfaGraph.endNode.edges.Add(endEdge);

                EDGE endToStartEdge = new EDGE(CONSTANTS.EMPTY_SYMBOL, nfaGraph.startNode);
                nfaGraph.endNode.edges.Add(endToStartEdge);

                EDGE newStartToStartEdge = new EDGE(CONSTANTS.EMPTY_SYMBOL, nfaGraph.startNode);
                startNode.edges.Add(newStartToStartEdge);

                EDGE newStartToNewEndEdge = new EDGE(CONSTANTS.EMPTY_SYMBOL, endNode);
                startNode.edges.Add(newStartToNewEndEdge);

                newGraph = new NFA_GRAPH(startNode, endNode);
            }

            return newGraph;
        }
    }
}
