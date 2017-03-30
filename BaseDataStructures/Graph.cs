using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDataStructures
{
    public class Graph<T> where T : IComparable<T>
    {
        private ArrayList<Vertex<T>> Vertices { get; set; }

        public Graph()
        {
            Vertices = new ArrayList<Vertex<T>>();
        }

        public Vertex<T> Add(T data)
        {
            Vertex<T> vertex = new Vertex<T>(data);
            Vertices.Add(vertex);
            return vertex;
        }
        public void Add(Vertex<T> vertex)
        {
            Vertices.Add(vertex);
        }

        public void AddEdge(T source, T destination, double cost = 1.0)
        {
            Vertex<T> sourceVertex = Find(source) ?? new Vertex<T>(source);
            Vertex<T> desitnationVertex = Find(destination) ?? new Vertex<T>(destination);
            AddEdge(sourceVertex, desitnationVertex, cost);
        }
        public void AddEdge(Vertex<T> source, Vertex<T> destination, double cost = 1.0)
        {
            source.AddEdge(destination, cost);
        }

        private Vertex<T> Find(T data)
        {
            for (int i = 0; i <= Vertices.CurrentIndex; i++)
            {
                Vertex<T> vertex = Vertices.Get(i);
                if (vertex.Data.Equals(data)) return vertex;
            }
            return null;
        }

        public void ClearAll()
        {
            for (int i = 0; i <= Vertices.CurrentIndex; i++)
            {
                Vertices.Get(i).Reset();
            }
        }

        public void Unweighted(T start)
        {
            ClearAll();

            Vertex<T> startVertex = Find(start);
            if (startVertex == null)
                throw new ArgumentOutOfRangeException(nameof(start));
            startVertex.Distance = 0;

            Queue<Vertex<T>> queue = new Queue<Vertex<T>>();
            queue.Enqueue(startVertex);

            while (queue.Peek() != null)
            {
                Vertex<T> vertex = queue.Dequeue();

                for (int i = 0; i <= vertex.Edges.CurrentIndex; i++)
                {
                    Vertex<T> w = vertex.Edges.Get(i).Destination;
                    if (!w.Distance.HasValue)
                    {
                        w.Distance = vertex.Distance + 1;
                        w.PreviousVertex = vertex;
                        queue.Enqueue(w);
                    }
                }
            }
        }

        public void Dijkstra(T start)
        {
            PriorityQueue<Path<T>> queue = new PriorityQueue<Path<T>>(12);

            Vertex<T> startVertex = Find(start);
            if (startVertex == null)
                throw new ArgumentOutOfRangeException(nameof(start));

            ClearAll();

            queue.Add(new Path<T>(startVertex, 0.0));
            startVertex.Distance = 0;

            int nodesSeen = 0;
            while (queue.Size > 0 && nodesSeen <= Vertices.CurrentIndex)
            {
                Path<T> vrec = queue.Remove();
                Vertex<T> v = vrec.Destination;

                if (v.Scratch > 0) //already processed
                    continue;

                v.Scratch = 1;
                nodesSeen++;

                for (int i = 0; i <= v.Edges.CurrentIndex; i++)
                {
                    Edge<T> edge = v.Edges.Get(i);
                    Vertex<T> w = edge.Destination;
                    double cvw = edge.Cost;

                    if (cvw < 0)
                        throw new Exception("Graph has negative edges");

                    if (!w.Distance.HasValue || w.Distance > v.Distance + cvw)
                    {
                        w.Distance = v.Distance + cvw;
                        w.PreviousVertex = v;
                        queue.Add(new Path<T>(w, w.Distance.Value));
                    }
                }
            }
        }

        public void Negative(T start)
        {
            Vertex<T> startVertex = Find(start);
            if (startVertex == null)
                throw new ArgumentOutOfRangeException(nameof(start));

            ClearAll();

            Queue<Vertex<T>> queue = new Queue<Vertex<T>>();
            queue.Enqueue(startVertex);
            startVertex.Distance = 0;
            startVertex.Scratch++;

            while (queue.Peek() != null)
            {
                Vertex<T> v = queue.Dequeue();
                if (v.Scratch++ > 2 * Vertices.CurrentIndex + 1)
                {
                    throw new Exception("Negative cycle detected");
                }

                for (int i = 0; i <= v.Edges.CurrentIndex; i++)
                {
                    Edge<T> edge = v.Edges.Get(i);
                    Vertex<T> w = edge.Destination;
                    double cvw = edge.Cost;

                    if (w.Distance == null || w.Distance > v.Distance + cvw)
                    {
                        w.Distance = v.Distance + cvw;
                        w.PreviousVertex = v;

                        //Enqueue only if not already on the queue
                        if (w.Scratch++ % 2 == 0)
                        {
                            queue.Enqueue(w);
                        }
                        else
                        {
                            w.Scratch--;
                        }

                    }
                }
            }


        }

        private void PrintPath(Vertex<T> destination)
        {
            if (destination.PreviousVertex != null)
            {
                PrintPath(destination.PreviousVertex);
                Console.Write(" to ");
            }
            Console.Write(destination.Data);
        }
        public void PrintPath(T destination)
        {
            Vertex<T> w = Find(destination);
            if (w == null)
            {
                throw new ArgumentOutOfRangeException(nameof(destination));
            }
            else if (!w.Distance.HasValue)
            {
                Console.WriteLine($"{w.Data} is unreachable");
            }
            else
            {
                Console.WriteLine($"Cost is: {w.Distance}");
                PrintPath(w);
                Console.WriteLine();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= Vertices.CurrentIndex; i++)
            {
                sb.Append(Vertices.Get(i).ToString());
            }
            return sb.ToString();
        }
    }

    public class Vertex<T>
    {
        public T Data { get; private set; }
        public ArrayList<Edge<T>> Edges { get; private set; }

        public double? Distance { get; set; }
        public Vertex<T> PreviousVertex { get; set; }
        public int Scratch { get; set; }

        public Vertex(T data)
        {
            Data = data;
            Edges = new ArrayList<Edge<T>>();
            Distance = null;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (Edges.CurrentIndex < 0)
            {
                sb.AppendLine(Data.ToString());
            }
            for (int i = 0; i <= Edges.CurrentIndex; i++)
            {
                sb.Append($"{Data} ->{Edges.Get(i)}");
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public Edge<T> AddEdge(Vertex<T> destination, double cost = 1.0)
        {
            Edge<T> edge = new Edge<T>(destination, cost);
            Edges.Add(edge);
            return edge;
        }

        public void Reset()
        {
            Distance = null;
            PreviousVertex = null;
            Scratch = 0;
        }
    }

    public class Edge<T>
    {
        public Vertex<T> Destination { get; private set; }
        public double Cost { get; private set; }


        public Edge(Vertex<T> destination, double cost = 1.0)
        {
            Destination = destination;
            Cost = cost;
        }

        public override string ToString()
        {
            return $" {Cost} -> {Destination.Data}";
        }
    }

    public class Path<T> : IComparable<Path<T>>, IComparable
    {
        public Vertex<T> Destination { get; private set; }
        public double Cost { get; private set; }

        public Path(Vertex<T> destination, double cost)
        {
            Destination = destination;
            Cost = cost;
        }

        public int CompareTo(Path<T> obj)
        {
            double otherCost = obj.Cost;
            return Cost.CompareTo(otherCost); //Cost < otherCost ? -1 : Cost > otherCost ? 1 : 0
        }

        public int CompareTo(object obj)
        {
            if (obj is Path<T>)
            {
                return CompareTo((Path<T>)obj);
            }

            return this.CompareTo(obj);
        }
    }
}

