/// Implementação de um 'Pair' simples 
public class Pair<T1, T2>
{
  public Pair(T1 i1, T2 i2) => (Item1, Item2) = (i1, i2);
  public T1 Item1 { get; set; }
  public T2 Item2 { get; set; }
}