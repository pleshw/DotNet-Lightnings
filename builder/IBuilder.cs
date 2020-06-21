namespace maze
{
  public abstract class IBuilder
  {
    public abstract Maze Build(Maze maze);

    public Maze Build(int w, int h) => Build(new Maze(w, h));
  }
}