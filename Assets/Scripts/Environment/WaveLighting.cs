/*---------------------------------------------------
 * 制作日 : 2018年09月26日
 * 制作者：シスワントレサ
 * 内容　：光の光ってるエフェクトを設定
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Light))]
public class WaveLighting : MonoBehaviour {

    public enum WaveForm
    {
        sine,               // サイン
        triangle,          // 三角形
        square,           // 四角形
        sawtooth,       // のこぎり
        inv,                // 逆のこぎり
        noise             // ランダム
    }

    public WaveForm waveform = WaveForm.sine;
    [SerializeField]
    private float baseStart = 0.0f; // Start
    [SerializeField]
    private float amplitude = 1.0f; // Amplitude of the wave
    [SerializeField]
    private float phase = 0.0f; // Start point on wave cycle
    [SerializeField]
    private float frequency = 0.5f; // Cycle frequency per second
    
    private Color originalColor;
    private new Light light;

	// Use this for initialization
	void Start () {
        light = GetComponent<Light>();
        originalColor = light.color;
	}
	
	// Update is called once per frame
	void Update () {
        light.color = originalColor * (EvalWave());
	}
    
    float EvalWave()
    {
        float x = (Time.time + phase) * frequency;
        float y;
        x = x - Mathf.Floor(x); // normalized value (0..1)

        // 選択されたイナムに基づく、ライトエフェクトが変わる。
        switch (waveform)
        {
            case WaveForm.sine:          // サイン
                y = Mathf.Sin(x * 2 * Mathf.PI);
                break;
            case WaveForm.triangle:     // 三角形のパタン
                if (x < 0.5f)
                    y = 4.0f * x - 1.0f;
                else
                    y = -4.0f * x + 3.0f;
                break;
            case WaveForm.square:      // 四角形のパタン
                if (x < 0.5f)
                    y = 1.0f;
                else
                    y = -1.0f;
                break;
            case WaveForm.sawtooth:   // のこぎりパタン
                y = x;
                break;
            case WaveForm.inv:           // のこぎりの逆パタン
                y = 1.0f - x;
                break;
            case WaveForm.noise:        // ランダムでフリッカー
                y = 1f - (Random.value * 2);
                break;
            default:
                y = 1.0f;
                break;
        }

        return (y * amplitude) + baseStart;
    }
}
