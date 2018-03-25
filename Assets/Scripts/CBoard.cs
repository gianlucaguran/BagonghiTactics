using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBoard : MonoBehaviour
{
    [SerializeField]
    private SOLevelData m_LevelData;


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
        if (m_LevelData)
        {
            foreach (STileData tile in m_LevelData.m_lTiles)
            {

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
