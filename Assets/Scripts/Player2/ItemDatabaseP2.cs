using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabaseP2
{
  public static ItemP2[] Items { get; private set; }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)] private static void Initialize() => Items = Resources.LoadAll<ItemP2>("items/");
}
