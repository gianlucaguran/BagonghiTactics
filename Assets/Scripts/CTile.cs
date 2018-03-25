using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class representing a tile
/// </summary>
public class CTile : MonoBehaviour
{
    /// <summary>
    /// Tile types 
    /// </summary>
    public enum ETileType
    {
        eNormal,
        eDefensive,
        eForest,
        eFliable,
        eSolidObstacle,
        eSize,
    }

    /// <summary>
    /// This instance Tile Type
    /// </summary>
    [SerializeField]
    private ETileType m_eType;



    /// <summary>
    /// Coordinates of this tile in the map
    /// </summary>
    private SPoint m_Coordinates;

    /// <summary>
    /// What is currently on this tile?
    /// </summary>
    private GameObject m_goContent;

    public SPoint Coordinates { get { return m_Coordinates; } set { m_Coordinates = value; } }
    public GameObject Content { get { return m_goContent; } set { m_goContent = value; } }

    /// <summary>
    /// Some useful Getters
    /// </summary>
    public int GetX { get { return Coordinates.m_iX; } }
    public int GetY { get { return Coordinates.m_iY; } }
    public ETileType Type { get { return m_eType; } }


    public override string ToString()
    {
        return string.Format(" {0} , {1} ", m_Coordinates, System.Enum.GetName(typeof(ETileType), m_eType));
    }
}
