using System.Drawing;
using System.Drawing.Imaging;


namespace PleshwGraphics
{

  public class Canvas
  {
    public readonly int Width;
    public readonly int Height;

    public static Color DefaultPaintColor = Color.FromArgb(0, 0, 0);

    private Bitmap _bitmap;

    private PixelFormat _pixelFormat;

    public int Thickness = 1;

    public Canvas(int w, int h, PixelFormat p)
      => (Width, Height, _pixelFormat, _bitmap) = (w, h, p, new Bitmap(w, h, p));
    public Canvas(int w, int h) : this(w, h, PixelFormat.Format32bppPArgb)
    { }
    public Canvas(int w, int h, bool transparency) : this(w, h, PixelFormat.Format32bppPArgb)
    {
      if (transparency)
        _bitmap.MakeTransparent();
    }

    public Color Pixel(Point p) => _bitmap.GetPixel(p.X, p.Y);
    public void Pixel(int x, int y, Color color) => _bitmap.SetPixel(x, y, color);
    public void Pixel(Point p, Color color) => Pixel(p.X, p.Y, color);

    public void Clear() => Clear(DefaultPaintColor);
    public void Clear(Color c)
    {
      for (int y = 0; y < Height; y++)
        for (int x = 0; x < Width; x++)
          Pixel(x, y, c);
    }


    public void VerticalLine(Point p, int size) => VerticalLine(p, size, DefaultPaintColor);
    public void VerticalLine(Point p, int size, Color c) => VerticalLine(p.X, p.Y, size, c);
    public void VerticalLine(int x, int y, int size) => VerticalLine(x, y, size, DefaultPaintColor);
    public void VerticalLine(int x, int y, int size, Color c)
    {
      for (int thick = 0; thick < Thickness; thick++)
        for (int i = 0; i <= size; i++)
          Pixel(x + thick, y + i, c);
    }

    public void HorizontalLine(Point p, int size) => HorizontalLine(p, size, DefaultPaintColor);
    public void HorizontalLine(Point p, int size, Color c) => HorizontalLine(p.X, p.Y, size, c);
    public void HorizontalLine(int x, int y, int size) => HorizontalLine(x, y, size, DefaultPaintColor);
    public void HorizontalLine(int x, int y, int size, Color c)
    {
      for (int thick = 0; thick < Thickness; thick++)
        for (int i = 0; i <= size; i++)
          Pixel(x + i, y + thick, c);
    }


    public void HorizontalParallel(Point p, int length, int distance) => HorizontalParallel(p, length, distance, DefaultPaintColor);
    public void HorizontalParallel(Point p, int length, int distance, Color c) => HorizontalParallel(p.X, p.Y, length, distance, c);
    public void HorizontalParallel(int x, int y, int length, int distance) => HorizontalParallel(x, y, length, distance, DefaultPaintColor);
    public void HorizontalParallel(int x, int y, int length, int distance, Color c)
    {
      HorizontalLine(x, y, length, c);
      HorizontalLine(x, y + distance, length, c);
    }

    public void VerticalParallel(Point p, int length, int distance) => VerticalParallel(p, length, distance, DefaultPaintColor);
    public void VerticalParallel(Point p, int length, int distance, Color c) => VerticalParallel(p.X, p.Y, length, distance, c);
    public void VerticalParallel(int x, int y, int length, int distance) => VerticalParallel(x, y, length, distance, DefaultPaintColor);
    public void VerticalParallel(int x, int y, int length, int distance, Color c)
    {
      VerticalLine(x, y, length, c);
      VerticalLine(x + distance, y, length, c);
    }

    public void Rectangle(Point p, int w, int h) => Rectangle(p, w, h, DefaultPaintColor);
    public void Rectangle(Point p, int w, int h, Color c) => Rectangle(p.X, p.Y, w, h, c);
    public void Rectangle(int x, int y, int w, int h) => Rectangle(x, y, w, h, DefaultPaintColor);
    public void Rectangle(int x, int y, int width, int height, Color c)
    {
      int offset = Thickness - 1;
      HorizontalParallel(x + Thickness, y, width - Thickness, height - offset, c);
      VerticalParallel(x, y, height, width - offset, c);
    }

    public void Square(Point p, int size) => Rectangle(p, size, size);
    public void Square(Point p, int size, Color c) => Rectangle(p, size, size, c);
    public void Square(int x, int y, int size) => Rectangle(x, y, size, size);
    public void Square(int x, int y, int size, Color c) => Rectangle(x, y, size, size, c);

    public void SavePNG(string src)
    {
      _bitmap.Save($@"{src}", ImageFormat.Png);
    }
  }
}
