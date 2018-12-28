
namespace TCG_UML.ConfigurableParser.Lexer
{
    public partial class NFA_GRAPH
    {

        public 
            NFA_GRAPH 
            Create_NFAConcatenation
            ( NFA_GRAPH graphOne, 
              NFA_GRAPH graphTwo )
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
                graphOne.endNode.nodeType = NODE_TYPE.TRANSITIONING;
                graphTwo.startNode.nodeType = NODE_TYPE.TRANSITIONING;

                EDGE newEdge = new EDGE(CONSTANTS.EMPTY_SYMBOL, graphTwo.startNode);

                graphOne.endNode.edges.Add(newEdge);

                graphOne.endNode = graphTwo.endNode;

                newGraph = graphOne;
            }

            return newGraph;
        }
    }
}
