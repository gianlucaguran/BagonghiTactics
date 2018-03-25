using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOLevelData : ScriptableObject
{
    public List<STileData> m_lTiles;
 
}

//Struct - tile data 
public struct STileData
{
    public SPoint position;
    public CTile.ETileType eType;
}