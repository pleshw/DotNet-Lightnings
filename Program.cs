using System;
using PleshwGraphics;
using System.Drawing;

namespace maze
{
  class Program
  {
    static void Main()
    {
      Maze maze = Maze.Build(3, 3, BuildingMethod.Kruskal);
      for (int i = 0; i < maze.Width * maze.Height; i++)
      {
        Console.WriteLine($"{i} Open at  {maze.Cell(i)}");
      }

      Canvas canvas = new Canvas(11, 11);
      canvas.Clear();

      canvas.Square(0, 0, 5, Color.White);

      canvas.Pixel(10, 0, Color.White);
      canvas.Pixel(10, 5, Color.White);

      canvas.Pixel(0, 10, Color.White);
      canvas.Pixel(5, 10, Color.White);
      canvas.Pixel(10, 10, Color.White);

      canvas.SavePNG("test.png");
    }
  }
}
