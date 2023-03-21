using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorUtils 
{
    public static Vector3 RandomPosition() => new Vector3(Random.Range(-14, 14), Random.Range(-6, 7), 0);
}