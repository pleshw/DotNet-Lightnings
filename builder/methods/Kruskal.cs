using System.Collections.Generic;
using Common;
namespace maze
{
  public class Kruskal : IBuilder
  {
    public List<Pair<int, HashSet<int>>> SetList = new List<Pair<int, HashSet<int>>>();
    public List<int> WallList = new List<int>();
    public List<Maze> Steps = new List<Maze>();


    public override Maze Build(Maze maze)
    {
      InitSetsAndWalls(in maze);
      ShuffleList.Shuffle(WallList);
      foreach (var wall in WallList)
      {
        int index = (wall / 4);

        BuildWall(maze, index, WallSide(wall % 4));
      }
      return maze;
    }

    /// Coloca uma parede entre a célula em 'index' e sua vizinha na direção 'dir'
    /// Somente se ambas pertencem a conjuntos diferentes e ambas existirem
    public void BuildWall(in Maze maze, int index, Direction dir)
    {
      int subIndex = maze.IndexAt(index, dir);

      if (subIndex == -1) return;
      if (object.ReferenceEquals(SetList[index].Item2, SetList[subIndex].Item2)) return;

      maze.Cell(index, (CellState)dir);
      maze.Cell(subIndex, (CellState)InverseDirection.Get(dir));

      MergeSets(index, subIndex);

      Save(maze);
    }

    /// Funde 2 conjuntos de diferentes células
    /// Faz com que todos os itens de ambos pertencerem ao mesmo objeto HashSet
    private void MergeSets(int mainIndex, int subIndex)
    {
      SetList[mainIndex].Item2.UnionWith(SetList[subIndex].Item2);

      var controller = new HashSet<int>(SetList[mainIndex].Item2);
      foreach (var i in SetList[mainIndex].Item2)
        SetList[i].Item2 = controller;
    }

    /// Retorna uma direção com base no valor que é passado pela função 'Build' 
    private Direction WallSide(int value)
    {
      switch (value)
      {
        case 0: return Direction.Top;
        case 1: return Direction.Right;
        case 2: return Direction.Bottom;
        default:
          return Direction.Left;
      }
    }

    /// Instancia o conjunto de cada célula e a lista de paredes
    private void InitSetsAndWalls(in Maze maze)
    {
      var area = maze.Height * maze.Width;

      for (int i = 0; i < area; i++)
      {
        SetList.Add(
          new Pair<int, HashSet<int>>(i, new HashSet<int>()));
        SetList[i].Item2.Add(i);
      }

      for (int i = 0; i < area * 4; i++)
        WallList.Add(i);

      Save(maze);
    }

    /// Guarda o processo de criação do 'maze'
    private void Save(in Maze maze) => Steps.Add(new Maze(maze));
  }
}
