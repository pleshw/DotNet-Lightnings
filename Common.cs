using System;


namespace Common
{
  /// Representa os possíveis estados de uma célula
  public enum CellState
  {
    None = 0, //!< No walls
    Top = 1, //!< Top wall open.
    Right = 2, //!< Right wall open.
    Bottom = 4, //!< Bottom wall open.
    Left = 8, //!< Left wall open.
    NotTested = 16, //!< Not tested by the solver.
    Checking = 32, //!< Being checked by the solver.
    Visited = 64, //!< Visited by the solver.
    Discarded = 128 //!< Discarded by the solver.
  };

  /// Usado para indicar direções
  public enum Direction : byte { Top = 1, Right = 2, Bottom = 4, Left = 8 }
  public static class InverseDirection
  {
    public static Direction Get(this Direction dir)
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



  /// Enumerador que representa uma célula. Cada flag significa que seu respectivo 'wall' está aberto
  [Flags]
  public enum cell_t : byte
  {
    None = 0,
    Top = 1,
    Right = 2,
    Bottom = 4,
    Left = 8,
    NotTested = 16,
    Checking = 32,
    Visited = 64,
    Discarded = 128
  }

  /// Instancias de celulas padrão
  public struct DefaultCell
  {
    public static cell_t GetOpen() => cell_t.Top | cell_t.Right | cell_t.Bottom | cell_t.Left;

    public static cell_t GetClosed() => cell_t.None;
  }
}