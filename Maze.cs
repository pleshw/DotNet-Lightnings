using Common;
namespace maze
{

  public class Maze : Index2D
  {
    private cell_t[] _cell;

    public Maze(int w, int h) : base(w, h) => (_cell) = (new cell_t[w * h]);
    public Maze(Maze clone) : base(clone.Width, clone.Height) => (_cell) = (clone._cell);

    public bool HasWall(int x, int y, Direction d) => (_cell[Index(x, y)] & (cell_t)d) != 0;


    public cell_t Cell(int index) => _cell[index];
    public void Cell(int index, CellState value) => _cell[index] = _cell[index] | (cell_t)value;
    public cell_t Cell(int x, int y) => _cell[Index(x, y)];
    public void Cell(int x, int y, CellState value) => _cell[Index(x, y)] = _cell[Index(x, y)] | (cell_t)value;

    public int Index(int x, int y) => base.Get(x, y);

    public static Maze Build(int w, int h, IBuilder builder) => builder.Build(w, h);
    public static Maze Solve(Maze maze, ISolver solver) => solver.Solve(maze);
  }
}