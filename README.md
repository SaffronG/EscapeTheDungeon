# EscapeTheDungeon

Implements a graph and a search algorithm using Dijkstra's algorithm or a Breadth-First-Search

```
Dictionary<string, List<Edge>> = new()
```

contains a blank graph dataset, this implements the folowing methods
- `Display()`
- `AddEdge(string Src, string Destination, int Weight)`

Node | Edge1 | Edge2 | Edge3 
-----------------------------
A    |   +1  |   +1  |   0  
B    |   -1  |   0   |   +1  
C    |   0   |  -1   |  -1  
