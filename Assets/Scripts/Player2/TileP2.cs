using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileP2 : MonoBehaviour
{
    public int x;
    public int y;

    private ItemP2 _item;

    public ItemP2 ItemP2
    {
        get => _item;

        set
        {
            if (_item == value) return;

            _item = value;

            icon.sprite = _item.sprite;
        }
    }

    public Image icon;

    public Button button;

    public TileP2 Left => x > 0 ? BoardP2.Instance.Tiles[x - 1, y] : null;
    public TileP2 Top => y < 0 ? BoardP2.Instance.Tiles[x, y - 1] : null;


    public TileP2 Right => x < BoardP2.Instance.Width - 1 ? BoardP2.Instance.Tiles[x + 1, y] : null;
    public TileP2 Bottom => y < BoardP2.Instance.Width - 1 ? BoardP2.Instance.Tiles[x, y + 1] : null;

    public TileP2[] Neighbours => new[]
    {
        Left,
        Top,
        Right,
        Bottom,
    };

    private void Start()
    {
        button.onClick.AddListener(() => BoardP2.Instance.Select(this));
    }

    public List<TileP2> GetConnectedTiles(List<TileP2> exclude = null) //Make a list to calculate all neighbours of current tile
    {

        //Checking if the tile next to the current is excluded or included (match or not)
        var result = new List<TileP2> { this, };

        if (exclude == null)
        {
            exclude = new List<TileP2> { this, };
        }
        else
        {
            exclude.Add(this);
        }

        //Going through all tiles NEAR and AROUND the current tile and excluding what is not a match
        foreach (var neighbour in Neighbours)
        {
            if (neighbour == null || exclude.Contains(neighbour) || neighbour.ItemP2 != ItemP2) continue;

            result.AddRange(neighbour.GetConnectedTiles(exclude));
        }

        return result;
    }
}
