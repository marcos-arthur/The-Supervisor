using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamesScore
{
    public static string openedGameScene { get; set; }

    public static int globalPoints {  get; set; }

    public static string gameName { get; set; }
    public static bool hasStolenAsset { get; set; }

    public static bool canOpenCheckWindow { get; set; }
}
