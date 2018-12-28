
namespace TCG_UML.ConfigurableParser.Lexer
{
    public partial class NFA_GRAPH
    {

        public 
            NFA_GRAPH 
            Create_NFAOneChar
            ( char character )
        {
            NODE startNode = NODE.CreateNode(NODE_TYPE.START);
            NODE endNode = NODE.CreateNode(NODE_TYPE.END);

            EDGE edge = new EDGE(character, endNode);

            startNode.edges.Add(edge);

            NFA_GRAPH newGraph = new NFA_GRAPH(startNode, endNode);

            return newGraph;
        }
    }
}
