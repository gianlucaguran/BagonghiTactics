using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class CBoardImporter : MonoBehaviour
{
    [SerializeField]
    private Texture2D m_tMapData;

    [SerializeField]
    private SColorToPrefab[] m_aColorToPrefabs;

     

    // Use this for initialization
    void Awake()
    { 
    }

    private void Start()
    {
    }

    public void LoadMapFromTexture()
    {
        if ( null == m_tMapData )
        {
            return;
        }

        Clear();

        Transform tmpBoard = this.transform.GetChild(0);

        Vector2 v2Size = new Vector2(m_tMapData.width, m_tMapData.height);
         

        Color32[] aPixelData = m_tMapData.GetPixels32();
        for (int wLoop = 0; m_tMapData.width > wLoop ; wLoop++)
        {
            for (int hLoop = 0; m_tMapData.height > hLoop; hLoop++)
            {
                Color32 color = aPixelData[(hLoop * m_tMapData.width) + wLoop];
                foreach( SColorToPrefab cToPF in m_aColorToPrefabs )
                {
                    if ( cToPF.color.Equals(color))
                    {
                        GameObject tileObject = (GameObject) GameObject.Instantiate(cToPF.prefab);
                        CTile tile = tileObject.GetComponent<CTile>();
                        tile.Coordinates = new SPoint(wLoop, hLoop);

                        tileObject.transform.parent = tmpBoard;
                        tileObject.transform.localPosition = (Vector3)tile.Coordinates;
                    }
                }
            }
        }

    }

    /// <summary>
    /// Clears the board
    /// </summary>
    public void Clear()
    {
        Transform tFakeBoard = this.transform.GetChild(0);
        int iTileCount = tFakeBoard.childCount;
        //reverse iteration to destroy all the childs
        for (int iLoop = iTileCount-1; 0 <= iLoop; iLoop--)
        {
            GameObject.DestroyImmediate(tFakeBoard.GetChild(iLoop).gameObject);
        }
    }

    public void SaveToScriptableObject(string mapName)
    {
        SOLevelData soLevelData = ScriptableObject.CreateInstance<SOLevelData>();
        List<STileData> lLevelData = new List<STileData>();

        Transform tFakeBoard = this.transform.GetChild(0);
        int iTileCount = tFakeBoard.childCount;
         
        for (int iLoop = 0; iLoop < iTileCount; iLoop++)
        {
            STileData tileData = new STileData();
            CTile tile = tFakeBoard.GetChild(iLoop).GetComponent<CTile>();
            if ( tile )
            {
                tileData.position = tile.Coordinates;
                tileData.eType = tile.Type;

                lLevelData.Add(tileData);
            }
            
        }

        soLevelData.m_lTiles = lLevelData;


        string sPath = Application.dataPath + "/Resources/LevelsData";
        if (! Directory.Exists(sPath))
        {
            AssetDatabase.CreateFolder("Assets/Resources", "LevelsData");
        }

        AssetDatabase.CreateAsset(soLevelData, String.Format("Assets/Resources/LevelsData/{0}.asset", mapName));

    }
}

/// <summary>
/// Class used when loading level data from texture.
/// Maps a prefab to a color
/// </summary>
[Serializable]
public struct SColorToPrefab
{
    public Color32 color;
    public GameObject prefab;
}