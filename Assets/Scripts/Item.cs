using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SCRIPT FOR DATA USES ONLY

[CreateAssetMenu(menuName = "Amit-Match/Item")] //Create the "Item" option from the "Add Assets" menu under Amit-Match namespace.
public class Item : ScriptableObject //Deleted MonoBehavior because we need ONLY DATA, ScriptableObject just HOLDS data.
{
    public int value; //Data for score value

    public Sprite sprite; //Data for the icon shown
}
