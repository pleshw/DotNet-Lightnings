namespace Common
{
  /// Classe que lida com indices em uma estrutura 2D
  public class Index2D
  {
    public readonly int Width;
    public readonly int Height;
    public Index2D(int w, int h) => (Width, Height) = (w, h);

    public int Get(int x, int y) => x + Width * y;

    public int Top(int index) => HasTop(index) ? index - Width : -1;
    public int Right(int index) => HasRight(index) ? index + 1 : -1;
    public int Bottom(int index) => HasBottom(index) ? index + Width : -1;
    public int Left(int index) => HasLeft(index) ? index - 1 : -1;

    public bool HasTop(int index) => index >= Width;
    public bool HasRight(int index) => index % Width != Width - 1;
    public bool HasBottom(int index) => index < Width * (Height - 1);
    public bool HasLeft(int index) => index % Width != 0;

    public int IndexAt(int index, Direction dir)
    {
      switch (dir)
      {
        case Direction.Top: return Top(index);
        case Direction.Right: return Right(index);
        case Direction.Bottom: return Bottom(index);
        default:
          return Left(index);
      }
    }

    public static Direction Inverse(Direction dir)
    {
      switch (dir)
      {
        case Direction.Top: return Direction.Bottom;
        case Direction.Right: return Direction.Left;
        case Direction.Bottom: return Direction.Top;
        default:
          return Direction.Right;
      }
    }
  }
}