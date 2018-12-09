/*---------------------------------------------------
 * 制作日 : 2018年09月26日
 * 制作者：シスワントレサ
 * 内容　：プレイヤを追いかけるカメラ
 * 
 * !!!! 使わない !!!!
 * 
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);	
	}
}
