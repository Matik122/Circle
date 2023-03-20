using UnityEngine;

public static class Constants
{
   public static Vector3 RandomPosition() => new Vector3(Random.Range(-14, 14), Random.Range(-6, 7), 0);
   public static string HighScoreDefinition = "HighScore";
   public static string HighDistanceDefinition = "HighDistance";
   public static int CeilingDivideValue = 10000;
}

