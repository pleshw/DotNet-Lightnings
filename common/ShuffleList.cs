using System;
using System.Collections.Generic;
public static class ShuffleList
{
  public static void Shuffle<T>(this IList<T> list)
  {
    Random rng = new Random(); //DevSkim: ignore DS148264 
    int n = list.Count;
    while (n > 1)
    {
      n--;
      int k = rng.Next(n + 1);
      T value = list[k];
      list[k] = list[n];
      list[n] = value;
    }
  }
}