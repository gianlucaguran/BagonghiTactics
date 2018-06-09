using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBoard : MonoBehaviour
{
    [SerializeField]
    private SOLevelData m_LevelData;

    [SerializeField]
    private STileTypeToPrefab[] m_PrefabToTileType;

    /// <summary>
    ///  Structure where tiles references are kept. 
    ///  Uses points (coordinates) as keys.
    /// </summary>
    private Dictionary<SPoint, CTile> m_dBoardTiles;

    /// <summary>
    /// Board size stored as Vector2
    /// </summary>
    private Vector2 m_v2Size;

    private void Awake()
    {
        m_dBoardTiles = new Dictionary<SPoint, CTile>();

        m_v2Size = new Vector2(10f, 10f);  //DEBUG - TODO: Do proper logic with SOLevelData

        if (m_LevelData)
        {
            foreach (STileData tile in m_LevelData.m_lTiles)
            {
                bool bFound = false;
                foreach (STileTypeToPrefab mapping in m_PrefabToTileType)
                {
                    if (mapping.type == tile.eType)
                    {
                        GameObject tileObject =  GameObject.Instantiate(mapping.prefab, (Vector3) tile.position, Quaternion.identity);
                        CTile tileComponent = tileObject.GetComponent<CTile>();
                        tileComponent.Coordinates = tile.position;

                        AddTile(tileComponent);

                        bFound = true;
                    }

                }
                if (! bFound)
                {
                    Debug.LogWarning("Tile type not mapped found");
                }
            }
        }
    }

    void Start()
    {
        m_dBoardTiles = new Dictionary<SPoint, CTile>();
    }


    /// <summary>
    /// Adds one tile to the board: adds to dictionary , and positions the tile in the correct place in the scene
    /// If the tile is in invalid coordinates, logs error and exits.
    /// </summary>
    /// <param name="tile"></param>
    public void AddTile(CTile tile)
    {

        if (0 > tile.GetX || 0 > tile.GetY || m_v2Size.x < tile.GetX || m_v2Size.y < tile.GetY)
        {
            Debug.LogError("invalid point coordinates during Add tile : " + tile.Coordinates);
            return;
        }

        m_dBoardTiles.Add(tile.Coordinates, tile);
        tile.transform.parent = this.transform;
        //need to multiply for tile size in order to actually position them correctly in space
        tile.transform.localPosition = new Vector3(tile.GetX * Constants.TILESIZE, tile.GetY * Constants.TILESIZE, 0);
    }

    public void SetSize(Vector2 v2Size)
    {
        m_v2Size = v2Size;
    }



}

/// <summary>
/// Class used when loading level data from Scriptable Object.
/// Maps a tile type to a prefab
/// </summary>
[Serializable]
public struct STileTypeToPrefab
{
    public CTile.ETileType type;
    public GameObject prefab; 
}
