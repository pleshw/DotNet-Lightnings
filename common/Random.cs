using System;
using System.Security.Cryptography;
namespace Common
{
  public static class GetRandom
  {
    private static RNGCryptoServiceProvider Rand = new RNGCryptoServiceProvider();
    public static int Int(int max)
    {
      return Int(0, max);
    }

    public static int Int(int min = 0, int max = (int)UInt16.MaxValue)
    {
      uint scale = uint.MaxValue;
      while (scale == uint.MaxValue)
      {
        byte[] bytes = new byte[4];
        Rand.GetBytes(bytes);

        scale = BitConverter.ToUInt32(bytes, 0);
      }

      // Add min to the scaled difference between max and min.
      return (int)(min + (max - min) *
          (scale / (double)uint.MaxValue));
    }
  }
}