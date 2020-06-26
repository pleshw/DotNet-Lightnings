using System.Drawing;
using System.Drawing.Imaging;


namespace PleshwGraphics
{

  public class Canvas
  {
    public readonly int Width;
    public readonly int Height;

    public Color BorderColor = Color.Transparent;
    public Color FillColor = Color.Transparent;
    public Color MainColor = Color.Black;

    private Bitmap _bitmap;

    private PixelFormat _pixelFormat;

    public int BorderWidth = 1;

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

    public void Clear() => Clear(MainColor);
    public void Clear(Color c)
    {
      for (int y = 0; y < Height; y++)
        for (int x = 0; x < Width; x++)
          Pixel(x, y, c);
    }


    public void VerticalLine(Point p, int length) => VerticalLine(p, length, MainColor);
    public void VerticalLine(Point p, int length, Color c) => VerticalLine(p.X, p.Y, length, c);
    public void VerticalLine(int x, int y, int length) => VerticalLine(x, y, length, MainColor);
    public void VerticalLine(int x, int y, int length, Color c)
    {
      for (int i = 0; i < length; i++)
        Pixel(x, y + i, c);
    }


    public void HorizontalLine(Point p, int length) => HorizontalLine(p.X, p.Y, length, MainColor);
    public void HorizontalLine(Point p, int length, Color c) => HorizontalLine(p.X, p.Y, length, c);
    public void HorizontalLine(int x, int y, int length) => HorizontalLine(x, y, length, MainColor);
    public void HorizontalLine(int x, int y, int length, Color c)
    {
      for (int i = 0; i < length; i++)
        Pixel(x + i, y, c);
    }


    public void HorizontalParallel(Point p, int length, int offset) => HorizontalParallel(p, length, offset, MainColor);
    public void HorizontalParallel(Point p, int length, int offset, Color c) => HorizontalParallel(p.X, p.Y, length, offset, c);
    public void HorizontalParallel(int x, int y, int length, int offset) => HorizontalParallel(x, y, length, offset, MainColor);
    public void HorizontalParallel(int x, int y, int length, int offset, Color c)
    {
      HorizontalLine(x, y, length, c);
      HorizontalLine(x, y + (offset + 1), length, c);
    }

    public void VerticalParallel(Point p, int length, int offset) => VerticalParallel(p, length, offset, BorderColor);
    public void VerticalParallel(Point p, int length, int offset, Color c) => VerticalParallel(p.X, p.Y, length, offset, c);
    public void VerticalParallel(int x, int y, int length, int offset) => VerticalParallel(x, y, length, offset, BorderColor);
    public void VerticalParallel(int x, int y, int length, int offset, Color c)
    {
      VerticalLine(x, y, length, c);
      VerticalLine(x + (offset + 1), y, length, c);
    }

    public void Rectangle(Point p, int w, int h, bool fill = false) => Rectangle(p.X, p.Y, w, h, fill);
    public void Rectangle(int x, int y, int width, int height, bool fill = false)
    {
      for (int thick = 0; thick < BorderWidth; thick++)
        EmptyRect(x + thick, y + thick, width - (thick * 2), height - (thick * 2));

      if (fill)
      {
        int margin = BorderWidth * 2;
        FillRect(x + BorderWidth, y + BorderWidth, (width - margin), (height - margin));
      }
    }

    public void FillRect(Point p, int w, int h) => FillRect(p.X, p.Y, w, h);
    public void FillRect(int x, int y, int w, int h)
    {
      for (int i = 0; i < h; i++)
        HorizontalLine(x, y + i, w, FillColor);
    }

    public void EmptyRect(Point p, int w, int h) => EmptyRect(p.X, p.Y, w, h);
    public void EmptyRect(int x, int y, int w, int h)
    {
      VerticalParallel(x, y, h, w - 2, BorderColor);
      HorizontalParallel(x + 1, y, (w - 2), (h - 2), BorderColor);
    }

    public void Square(Point p, int size, bool fill = false) => Square(p.X, p.Y, size, fill);
    public void Square(int x, int y, int size, bool fill = false) => Rectangle(x, y, size, size, fill);

    public void SavePNG(string src)
    {
      _bitmap.Save($@"{src}", ImageFormat.Png);
    }
  }
}
