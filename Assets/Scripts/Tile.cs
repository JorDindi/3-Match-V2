using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class Tile : MonoBehaviour
{
    public int x;
    public int y;

    private Item _item; //Accessing the Item script

    public Item Item //Get and Set method to "attach" data on items.
    {
        get => _item; //Get current item properties and data

        set
        {
            if (_item == value) return; //Do not set nothing if item has a value and return

            _item = value; //add a value to the item

            icon.sprite = _item.sprite; //set the icon sprite.
        }
    }

    public Image icon;

    public Button button;


    public Tile Left => x > 0 ? Board.Instance.Tiles[x - 1,y] : null; //going through all the tiles from left
    public Tile Top => y < 0 ? Board.Instance.Tiles[x, y - 1] : null;//going through all the tiles from top


    public Tile Right => x < Board.Instance.Width - 1 ? Board.Instance.Tiles[x + 1, y] : null;//going through all the tiles from right
    public Tile Bottom => y < Board.Instance.Width - 1 ? Board.Instance.Tiles[x, y + 1] : null;//going through all the tiles from bottom

    public Tile[] Neighbours => new[] //Checking for neighbours tiles.
    {
        Left,
        Top,
        Right,
        Bottom,
    };



    private void Start() { button.onClick.AddListener(() => Board.Instance.Select(this));}


    public List<Tile> GetConnectedTiles(List<Tile> exclude = null) //Make a list to calculate all neighbours of current tile
    {

        //Checking if the tile next to the current is excluded or included (match or not)
        var result = new List<Tile> { this, };

        if(exclude == null)
        {
            exclude = new List<Tile> { this, };
        }
        else
        {
            exclude.Add(this);
        }

        //Going through all tiles NEAR and AROUND the current tile and excluding what is not a match
        foreach ( var neighbour in Neighbours)
        {
            if (neighbour == null || exclude.Contains(neighbour) || neighbour.Item != Item) continue;

            result.AddRange(neighbour.GetConnectedTiles(exclude));
        }

        return result;
    }
}
