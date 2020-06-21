using System;

namespace maze
{
  class Program
  {
    static void Main()
    {
      Maze maze = Maze.Build(3, 3, BuildingMethod.Kruskal);
      for (int i = 0; i < maze.Width * maze.Height; i++)
      {
        Console.WriteLine(i + " " + maze.Cell(i));
      }
      // Maze.Solve(maze, SolvingMethod.AStar);
    }
  }
}
