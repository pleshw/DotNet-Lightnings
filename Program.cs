using System;
using PleshwGraphics;
using System.Drawing;

namespace maze
{
  class Program
  {
    static void Main()
    {
      // Maze maze = Maze.Build(3, 3, BuildingMethod.Kruskal);
      // for (int i = 0; i < maze.Width * maze.Height; i++)
      // {
      //   Console.WriteLine($"{i} Open at  {maze.Cell(i)}");
      // }

      Canvas canvas = new Canvas(17, 17);


      canvas.MainColor = Color.Black;
      canvas.Clear();

      canvas.BorderWidth = 1;

      canvas.MainColor = Color.Black;
      canvas.BorderColor = Color.White;
      canvas.FillColor = Color.DarkBlue;

      canvas.VerticalParallel(0, 0, 3, 4);
      // canvas.HorizontalParallel(0, 5, 3, 4);

      canvas.EmptyRect(8, 0, 5, 5);

      canvas.FillRect(0, 7, 5, 5);


      canvas.BorderWidth = 2;
      canvas.Square(8, 7, 7, fill: true);

      canvas.Pixel(16, 0, Color.Red);
      canvas.Pixel(16, 2, Color.Red);
      canvas.Pixel(16, 4, Color.Red);
      canvas.Pixel(16, 6, Color.Red);
      canvas.Pixel(16, 8, Color.Red);
      canvas.Pixel(16, 10, Color.Red);
      canvas.Pixel(16, 12, Color.Red);
      canvas.Pixel(16, 14, Color.Red);

      canvas.Pixel(0, 16, Color.Red);
      canvas.Pixel(2, 16, Color.Red);
      canvas.Pixel(4, 16, Color.Red);
      canvas.Pixel(6, 16, Color.Red);
      canvas.Pixel(8, 16, Color.Red);
      canvas.Pixel(10, 16, Color.Red);
      canvas.Pixel(12, 16, Color.Red);
      canvas.Pixel(14, 16, Color.Red);
      canvas.Pixel(16, 16, Color.Red);

      canvas.SavePNG("test.png");
    }
  }
}
