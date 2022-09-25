using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    // ゲームSceneが始まってからの経過時間
    private float startTime;
    // 合図が出現した時刻
    private float signalTime;
    public void startTimer()
    {
        startTime = Time.time;
    }

    public void setSignalTime()
    {
        signalTime = Time.time - startTime;
    }

    public float getElapsedTime()
    {
        return Time.time - startTime;
    }

    public float getDeltaTime()
    {
        return Time.time - startTime - signalTime;
    }

}
