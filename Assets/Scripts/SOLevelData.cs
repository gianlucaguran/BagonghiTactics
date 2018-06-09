using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOLevelData : ScriptableObject
{
    public List<STileData> m_lTiles;
 
}

//Struct - tile data 
[System.Serializable]
public struct STileData
{
    [SerializeField]
    public SPoint position;
    public CTile.ETileType eType;
}