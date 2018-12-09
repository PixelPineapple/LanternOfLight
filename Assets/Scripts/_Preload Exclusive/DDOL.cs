/*---------------------------------------------------
 * 制作日 : 2018年10月05日
 * 制作者：シスワントレサ
 * 内容　：Don't destroy on load
 * 最後の更新：2018年10月05日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDOL : MonoBehaviour {

    // Use this for initialization
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}   // !_class
