/*---------------------------------------------------
 * 制作日 : 2018年11月10日
 * 制作者：シスワントレサ
 * 内容　：2D光を管理するマネージャー
 * 最後の更新：2018年11月12日
 * 
 * !!!! もう使わない !!!!
 * 
 * ----------------------------------------------- */
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class IlluminationManager : MonoBehaviour {

    // 黒いマップ
    public Tilemap darkMap;
    // グレーマップ
    public Tilemap blurredMap;
    // 背景のマップ
    public Tilemap backgroundMap;

    // 黒いタイル
    public Tile darkTile;
    // グレータイル（alpha < 255)
    public Tile blurredTile;

	// Use this for initialization
	void Start () {
        // 背景マップを全部隠れるため
        darkMap.origin = blurredMap.origin = backgroundMap.origin;
        darkMap.size = blurredMap.size = backgroundMap.size;

        // 黒いタイルを黒いマップに並び替える
        foreach(Vector3Int x in darkMap.cellBounds.allPositionsWithin)
        {
            darkMap.SetTile(x, darkTile);
        }
        
        // グレータイルをグレーマップに並び替える
        foreach (Vector3Int x in blurredMap.cellBounds.allPositionsWithin)
        {
            blurredMap.SetTile(x, blurredTile);
        }
    }
} // !_class
