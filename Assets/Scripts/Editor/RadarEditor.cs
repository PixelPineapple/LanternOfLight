using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(CircleDetector))]
public class RadarEditor : Editor {

    private CircleDetector radar;

    public void OnSceneGUI()
    {
        radar = this.target as CircleDetector;

        Handles.color = Color.yellow;
        Handles.DrawWireDisc(radar.transform.position,
            radar.transform.forward,
            radar.Radius);
    }
}
