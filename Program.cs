static DangerLevel Parse(string input) =>
    input switch
    {
        "Low" => DangerLevel.Low,
        "Medium" => DangerLevel.Medium,
        "High" => DangerLevel.High,
        _ => throw new InvalidDataException("Expected Low, Medium, or High, recieved => 'input'"),
    };

List<string> list = new(File.ReadAllLines("src.txt"));

Graph graph = new Graph();

foreach (var item in list)
{
    var temp = item.Split(",");
    graph.AddEge(temp[0], temp[1], int.Parse(temp[2]), Parse(temp[3]), int.Parse(temp[4]));
}

graph.Display();
Console.WriteLine("----------");
foreach (var node in graph.BFS("A", "E"))
{
    Console.WriteLine(node.Destination + "--> ");
}

public class Graph
{
    public Dictionary<string, List<Edge>> AdjacencyList { get; set; }

    public Graph()
    {
        AdjacencyList = new();
    }

    public void AddEge(string Src, string Destination, int Weight, DangerLevel Danger, int Energy)
    {
        if (!AdjacencyList.ContainsKey(Src))
            AdjacencyList[Src] = new();
        AdjacencyList[Src].Add(new Edge(Destination, Weight, Danger, Energy));
    }

    public void Display()
    {
        foreach (var node in AdjacencyList)
        {
            Console.WriteLine(node.Key + "-> ");
            foreach (var edge in node.Value)
            {
                Console.WriteLine(edge.Destination + " " + edge.Weight + " ");
            }
        }
    }

    public List<Edge> BFS(string start, string end)
    {
        List<Edge> path = new();

        foreach (var node in AdjacencyList)
        {
            if (path[path.Count()-1].Destination == end)
            {
                path.Add(node.Value[0]);
                break;
            }
            int min = 0;
            for (int i = 0; i < node.Value.Count(); i++)
            {
                // Loop through this current node's valus and check for something with a weight less than the current
                // If at the end break and add the smallest weight node to the
                if (i == node.Value.Count())
                {
                    path.Add(node.Value[min]);
                    break;
                }
                if (node.Value[i].Weight < min || min == 0)
                    min = node.Value[i].Weight;
            }
        }
        return path;
    }
    public List<Edge> EnergyPath(string start, string end)
    {
        List<Edge> path = new();

        foreach (var node in AdjacencyList)
        {
            if (node.Key == end)
            {
                path.Add(node.Value[-1]);
                break;
            }
            int min = 0;
            for (int i = 0; i < node.Value.Count(); i++)
            {
                // Loop through this current node's valus and check for something with a weight less than the current
                // If at the end break and add the smallest weight node to the
                if (i == node.Value.Count())
                {
                    path.Add(node.Value[min]);
                    break;
                }
                if (node.Value[i].Energy < min || min == 0)
                    min = node.Value[i].Weight;
            }
        }
        return path;
    }
}

    public class Edge
    {
        public string Destination { get; set; }
        public int Weight { get; set; }
        public DangerLevel Danger { get; set; }
        public int Energy { get; set; }
        public Edge(String Destination, int Weight, DangerLevel Danger, int Energy)
        {
            this.Destination = Destination;
            this.Weight = Weight;
            this.Danger = Danger;
            this.Energy = Energy;
        }
    }

    public enum DangerLevel
    {
        Low,
        Medium,
        High,
    }