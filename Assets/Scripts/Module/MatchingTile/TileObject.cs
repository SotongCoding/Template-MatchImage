using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileObject : MonoBehaviour//, IRaycastReciver
{
    private System.Action<TileGroup.SelectTileData> OnSelectTile;
    [SerializeField] Button tileButton;
    private int tileId;
    private Vector2Int location;
    //public Bounds bound => objCollider.bounds;
    //[SerializeField] Collider2D objCollider;

    public void SetLocation(Vector2Int location)
    {
        this.location = location;
    }
    public void Initial(int id, System.Action<TileGroup.SelectTileData> onSelectTile)
    {
        tileId = id;

        name = id.ToString();
        OnSelectTile = onSelectTile;
        tileButton.onClick.AddListener(SelectTile);
    }

    void SelectTile()
    {
        if (GameFlow.Instance.isGameStart)
            OnSelectTile?.Invoke(new TileGroup.SelectTileData(tileId, location));
    }

    // public void OnGetRaycast()
    // {
    //     Debug.Log("GetRayCast");
    //     OnSelectTile?.Invoke(new TileGroup.SelectTileData(tileId, location));
    // }
}
