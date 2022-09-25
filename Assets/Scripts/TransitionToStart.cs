using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TransitionToStart : MonoBehaviour
{
    // 時刻表示用UI
    [SerializeField]
    private TextMeshProUGUI textMeshProUGUI;
    // ゲーム内時間用のタイマー
    [SerializeField]
    private Timer timer;
    // ゲームがスタートしてから合図までの時間
    public float transitionTime;
    // 合図までの時間を分割する数
    public int divideNumber;
    // どの分割数を現在表示しているか
    private int dividedPointer = 0;
    // 現在の分割数をフェードアウトさせるタイミング
    private float fadeOutTimeRatio = 0.7f;

    void Update()
    {
        if (dividedPointer > divideNumber || transitionTime == 0)
        {
            return;
        }
        if (timer.getElapsedTime() >= transitionTime / divideNumber * (dividedPointer + 1))
        {
            Debug.Log("add pointer");
            dividedPointer++;
        }
        if (dividedPointer < divideNumber * fadeOutTimeRatio)
        {
            Debug.Log(divideNumber - dividedPointer);
            textMeshProUGUI.text = ( divideNumber - dividedPointer ).ToString();
        }
        else
        {
            textMeshProUGUI.text = "...";
        }
    }
}
