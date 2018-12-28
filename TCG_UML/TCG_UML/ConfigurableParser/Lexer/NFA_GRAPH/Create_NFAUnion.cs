
namespace TCG_UML.ConfigurableParser.Lexer
{
    public partial class NFA_GRAPH
    {

        public static NFA_GRAPH Create_NFAUnion(NFA_GRAPH graphOne, NFA_GRAPH graphTwo)
        {
            NFA_GRAPH newGraph = null;

            if (graphOne == null && graphTwo != null)
            {
                newGraph = graphTwo;
            }
            else if (graphOne != null && graphTwo == null)
            {
                newGraph = graphOne;
            }
            else if (graphOne != null && graphTwo != null)
            {
                NODE startNode = NODE.CreateNode(NODE_TYPE.START);
                NODE endNode = NODE.CreateNode(NODE_TYPE.END);

                graphOne.startNode.nodeType = NODE_TYPE.TRANSITIONING;
                graphTwo.startNode.nodeType = NODE_TYPE.TRANSITIONING;
                graphOne.endNode.nodeType = NODE_TYPE.TRANSITIONING;
                graphTwo.endNode.nodeType = NODE_TYPE.TRANSITIONING;

                EDGE startOneEdge = new EDGE(CONSTANTS.EMPTY_SYMBOL, graphOne.startNode);
                EDGE startTwoEdge = new EDGE(CONSTANTS.EMPTY_SYMBOL, graphTwo.startNode);

                startNode.edges.Add(startOneEdge);
                startNode.edges.Add(startTwoEdge);

                EDGE endOneEdge = new EDGE(CONSTANTS.EMPTY_SYMBOL, endNode);
                EDGE endTwoEdge = new EDGE(CONSTANTS.EMPTY_SYMBOL, endNode);

                graphOne.endNode.edges.Add(endOneEdge);
                graphTwo.endNode.edges.Add(endTwoEdge);

                newGraph = new NFA_GRAPH(startNode, endNode);
            }

            return newGraph;
        }
    }
}
