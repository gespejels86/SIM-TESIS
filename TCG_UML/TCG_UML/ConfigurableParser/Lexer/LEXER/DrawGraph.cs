using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using TCG_UML.ConfigurableParser.SyntaxAnalyzer;

namespace TCG_UML.ConfigurableParser.Lexer
{
    partial class LEXER
    {

        public Image drawGraph(NODE startNode)
        {

            DOTFormat graphInDOT = new DOTFormat(startNode);

            string executable = @"dot.exe";
            string output = @".\external\tempgraph";

            FileInfo file = new FileInfo(output);
            file.Directory.Create();

            File.WriteAllText(output, graphInDOT.getDOTString());

            Process process = new System.Diagnostics.Process();

            // Stop the process from opening a new window
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            // Setup executable and parameters
            process.StartInfo.FileName = executable;
            process.StartInfo.Arguments = string.Format(@"{0} -Tjpg -O", output);

            // Go
            process.Start();

            // and wait doe.exe to complete and exit
            process.WaitForExit();

            //Process.Start(output + ".jpg");

            Bitmap bitmap = null;

            using (Stream bmpStream = System.IO.File.Open(output + ".jpg", System.IO.FileMode.Open))
            {
                Image image = Image.FromStream(bmpStream);
                bitmap = new Bitmap(image);
            }

            File.Delete(output);
            File.Delete(output + ".jpg");
            return bitmap;
        }

        
    }

    public class DOTFormat
    {
        private StringBuilder DOTString;

        public DOTFormat(NODE startNode)
        {

            DOTString = new StringBuilder();

            DOTString.AppendLine("digraph G {");

            getGraphInDOT(startNode);

            DOTString.AppendLine("}");

        }

        public DOTFormat(SYNTAX_TREE syntaxTree)
        {
            DOTString = new StringBuilder();
            DOTString.AppendLine("digraph G {");
            getGraphInDOT(syntaxTree.stNode);

            DOTString.AppendLine("}");
        }

        private void getGraphInDOT(SYNTAX_TREE_NODE startNode)
        {
            SYNTAX_TREE_NODE processingNode;

            int nodeID = 1;
            int nodeIDInProcess;

            Queue<SYNTAX_TREE_NODE> nodesToProcess = new Queue<SYNTAX_TREE_NODE>();

            Queue<int> nodeIDToProcess = new Queue<int>();

            StringBuilder GraphInDOT = new StringBuilder();
            StringBuilder NodesDefinition = new StringBuilder();

            nodesToProcess.Enqueue(startNode);
            nodeIDToProcess.Enqueue(nodeID);

            while (nodesToProcess.Count != 0)
            {
                processingNode = nodesToProcess.Dequeue();
                nodeIDInProcess = nodeIDToProcess.Dequeue();

                if (processingNode.symbol.type == SYMBOL_TYPE.TERMINAL)
                {
                    if (processingNode.token.lexeme != processingNode.token.type)
                    {
                        NodesDefinition.AppendLine( "node" +
                                                    nodeIDInProcess +
                                                    "[label=\"" +
                                                    processingNode.token.lexeme +
                                                    "\"];");
                    }
                    else
                    {
                        NodesDefinition.AppendLine( "node" +
                                                    nodeIDInProcess +
                                                    "[label=\"" +
                                                    processingNode.symbol.id +
                                                    "\"];");
                    }
                }
                else
                {
                    NodesDefinition.AppendLine( "node" +
                                                nodeIDInProcess +
                                                "[label=\"" +
                                                processingNode.symbol.id +
                                                "\"];");
                }

                if (processingNode.symbol.type == SYMBOL_TYPE.NON_TERMINAL)
                {
                    foreach (SYNTAX_TREE_NODE derivedNode in processingNode.derivedNodes)
                    {
                        nodeID++;
                                GraphInDOT.AppendLine(  "node" +
                                                        nodeIDInProcess +
                                                        " -> " +
                                                        "node" +
                                                        nodeID );

                        nodesToProcess.Enqueue(derivedNode);
                        nodeIDToProcess.Enqueue(nodeID);

                    }
                }
            }

            DOTString.Append(NodesDefinition);
            DOTString.Append(GraphInDOT);
            NodesDefinition.Clear();
            GraphInDOT.Clear();
        }

        public string getDOTString() {

            string DOTFormat = DOTString.ToString();
            DOTString.Clear();

            return DOTFormat;

        }

        private void getGraphInDOT(NODE startNode)
        {
            NODE processingNode;

            HashSet<NODE> visitedNodes = new HashSet<NODE>();
            Queue<NODE> nodesToProcess = new Queue<NODE>();

            StringBuilder GraphInDOT = new StringBuilder();
            StringBuilder EndNodes = new StringBuilder();

            nodesToProcess.Enqueue(startNode);

            while (nodesToProcess.Count != 0)
            {
                processingNode = nodesToProcess.Dequeue();
                visitedNodes.Add(processingNode);
                if (processingNode.nodeType == NODE_TYPE.END)
                {
                    EndNodes.AppendLine(processingNode.NodeID + " [shape = doublecircle];");
                }
                else if (processingNode.nodeType == NODE_TYPE.START)
                {
                    EndNodes.AppendLine(processingNode.NodeID + " [shape = invtriangle];");
                }

                foreach (EDGE edge in processingNode.edges)
                {
                    if (edge.transitionCharacter != CONSTANTS.EMPTY_SYMBOL)
                    {
                        GraphInDOT.AppendLine(processingNode.NodeID + " -> " + edge.nextNode.NodeID + "[label=\"" + edge.transitionCharacter.ToString() + "\"];");
                    }
                    else
                    {
                        GraphInDOT.AppendLine(processingNode.NodeID + " -> " + edge.nextNode.NodeID + "[label=\"empty\"];");
                    }

                    if (!visitedNodes.Contains(edge.nextNode))
                    {
                        nodesToProcess.Enqueue(edge.nextNode);
                    }
                }
            }
            DOTString.Append(EndNodes);
            DOTString.Append(GraphInDOT);
            EndNodes.Clear();
            GraphInDOT.Clear();
        }
    }
}
