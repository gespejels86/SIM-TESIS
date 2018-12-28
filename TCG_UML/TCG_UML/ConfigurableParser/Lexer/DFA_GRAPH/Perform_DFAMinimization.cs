using System.Collections.Generic;

namespace TCG_UML.ConfigurableParser.Lexer
{
    public partial class DFA_GRAPH
    {
        private void Perform_DFAMinimization()
        {
            bool existedChange = true;

            SetInicialSetSplitting();

            if (DFASets.Count != 0)
            {
                while (existedChange)
                {
                    List<NODES_SET> newNodeSets = new List<NODES_SET>(); ;

                    existedChange = false;

                    foreach (NODES_SET dfaNodesSet in DFASets)
                    {
                        existedChange |= Perform_SetSplitting(dfaNodesSet, newNodeSets);
                    }

                    foreach (NODES_SET newDFANodesSet in newNodeSets)
                    {
                        DFASets.Add(newDFANodesSet);
                    }
                }

                Get_DFAFromDFASets();
            }
        }
    }
}
