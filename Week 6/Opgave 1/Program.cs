using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDataStructures;

namespace Opgave_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<string> graph = new Graph<string>();

            Vertex<string> vertexV0 = graph.Add("V0");
            Vertex<string> vertexV1 = graph.Add("V1");
            Vertex<string> vertexV2 = graph.Add("V2");
            Vertex<string> vertexV3 = graph.Add("V3");
            Vertex<string> vertexV4 = graph.Add("V4");
            Vertex<string> vertexV5 = graph.Add("V5");
            Vertex<string> vertexV6 = graph.Add("V6");

            graph.AddEdge("V0", "V1", 2.0);
            graph.AddEdge("V0", "V3");
            graph.AddEdge("V1", "V3", 3);
            graph.AddEdge("V1", "V4", -10);
            graph.AddEdge("V2", "V0", 4);
            graph.AddEdge("V2", "V5", 5);
            graph.AddEdge("V3", "V2", 2);
            graph.AddEdge("V3", "V4", 2);
            graph.AddEdge("V3", "V5", 8);
            graph.AddEdge("V3", "V6", 4);
            graph.AddEdge("V4", "V6", 6);
            graph.AddEdge("V6", "V5", 1);

            graph.Unweighted("V2");            
            graph.PrintPath("V6");

            graph.Negative("V2");
            graph.PrintPath("V6");

            Console.WriteLine(graph);
        }
    }
}
