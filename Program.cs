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

      Canvas canvas = new Canvas(17, 17);
      canvas.Clear();


      canvas.Thickness = 1;
      canvas.VerticalParallel(0, 0, 3, 4, Color.White);
      canvas.HorizontalParallel(0, 5, 3, 4, Color.White);

      canvas.Square(8, 0, 5, Color.White);


      canvas.Thickness = 2;
      canvas.Square(8, 7, 5, Color.White);


      canvas.Pixel(16, 0, Color.White);
      canvas.Pixel(16, 2, Color.White);
      canvas.Pixel(16, 4, Color.White);
      canvas.Pixel(16, 6, Color.White);
      canvas.Pixel(16, 8, Color.White);
      canvas.Pixel(16, 10, Color.White);
      canvas.Pixel(16, 12, Color.White);
      canvas.Pixel(16, 14, Color.White);

      canvas.Pixel(0, 16, Color.White);
      canvas.Pixel(2, 16, Color.White);
      canvas.Pixel(4, 16, Color.White);
      canvas.Pixel(6, 16, Color.White);
      canvas.Pixel(8, 16, Color.White);
      canvas.Pixel(10, 16, Color.White);
      canvas.Pixel(12, 16, Color.White);
      canvas.Pixel(14, 16, Color.White);
      canvas.Pixel(16, 16, Color.White);

      canvas.SavePNG("test.png");
    }
  }
}
