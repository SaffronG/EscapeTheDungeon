List<string> list = new (File.ReadAllLines("src.txt"));

Graph graph = new Graph();

foreach (var item in list) {
    var temp = item.Split(",");
    graph.AddEge(temp[0], temp[1], int.Parse(temp[2]));
}

public class Graph {
    public Dictionary<string, List<Edge>> AdjacencyList { get; set; }

    public Graph() {
        AdjacencyList = new();
    }

    public void AddEge(string Src, string Destination, int Weight = 1) {
        if (!AdjacencyList.ContainsKey(Src))
            AdjacencyList[Src] = new();
        AdjacencyList[Src].Add(new Edge(Destination, Weight));
    }
}

public class Edge {
    public string Destination { get; set; }
    public int Weight { get; set; }
    public Edge(String Destination, int Weight) {
        this.Destination = Destination;
        this.Weight = Weight;
    }
}