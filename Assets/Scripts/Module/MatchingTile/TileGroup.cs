using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileGroup
{
    [Range(1, 6)]
    [SerializeField] private int matchVariation = 2;
    [Range(2, 30)]
    [SerializeField] private int TileCreated = 30;
    private int tileCreated => TileCreated % 2 == 1 ? TileCreated + 1 : TileCreated;
    private int currentTileCreated = 0;

    [SerializeField] Vector2Int areaSize = new Vector2Int(5, 6);
    [SerializeField] private TileObject tilePrefab;

    //If use GameObject
    // [SerializeField] private float tileScale = 1;
    // [SerializeField] private Vector2 padding = new Vector2(1, 1);
    // private Bounds allObjectArea;
    //If Use Canvas
    [SerializeField] Transform tileParent;

    private TileObject[,] createdTileObject;



    // Match data Handling
    private int matchAmount;
    private int currentMatchAmount;

    // [SerializeField] 
    private SelectTileData currentMatchTile = new SelectTileData(-1);

    public void CreateTile(System.Action onDoneCreate = null)
    {
        //Vector2 tilePos = new Vector2();
        createdTileObject = new TileObject[areaSize.x, areaSize.y];

        //Create Tile
        List<TileObject> createdTile = new List<TileObject>();
        for (int x = 0; x < areaSize.x; x++)
        {
            for (int y = 0; y < areaSize.y; y++)
            {
                if (currentTileCreated >= tileCreated) break;
                //tilePos.Set(x * tileScale, y * tileScale);
                var tile =
                MonoBehaviour.Instantiate(tilePrefab, tileParent);
                //Instantiate(tilePrefab, tilePos + (tilePos * padding), Quaternion.identity);
                //allObjectArea.Encapsulate(tile.bound);

                tile.SetLocation(new Vector2Int(x, y));

                createdTile.Add(tile);
                createdTileObject[x, y] = tile;
                currentTileCreated++;

            }
        }

        // DecideTile match
        int variationCount = 0;
        for (int i = 0; i < tileCreated;)
        {
            int id = variationCount < matchVariation ? variationCount :
            Random.Range(0, matchVariation);

            for (int ind = 0; ind < 2; ind++)
            {
                int select = Random.Range(0, createdTile.Count);

                createdTile[select].Initial(id, SetMatch);
                createdTile.RemoveAt(select);
                i++;
            }
            variationCount++;
        }

        matchAmount = variationCount;
        onDoneCreate?.Invoke();
    }

    public void DisableLayout()
    {
        tileParent.GetComponent<UnityEngine.UI.LayoutGroup>().enabled = false;
    }

    private void SetMatch(SelectTileData tileData)
    {
        if (currentMatchTile.tileId == -1)
        {
            currentMatchTile = new SelectTileData(tileData);
        }
        else
        {
            if (tileData.tileIndex == currentMatchTile.tileIndex) return;
            
            if (currentMatchTile.tileId == tileData.tileId)
            {
                currentMatchAmount++;
                Vector2Int lastTile = currentMatchTile.tileIndex;
                Vector2Int currentTile = tileData.tileIndex;

                createdTileObject[lastTile.x, lastTile.y].gameObject.SetActive(false);
                createdTileObject[currentTile.x, currentTile.y].gameObject.SetActive(false);

            }
            currentMatchTile = new SelectTileData(-1);
        }

        if (currentMatchAmount == matchAmount)
        {
            GameFlow.Instance.GameOver(true);
        }
    }

    [System.Serializable]
    public struct SelectTileData
    {
        public int tileId;
        public Vector2Int tileIndex;

        public SelectTileData(int tileId = -1, Vector2Int tileIndex = new())
        {
            this.tileId = tileId;
            this.tileIndex = tileIndex;
        }
        public SelectTileData(SelectTileData newData)
        {
            tileId = newData.tileId;
            tileIndex = newData.tileIndex;
        }
    }
}
