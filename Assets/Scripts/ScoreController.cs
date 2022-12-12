using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private const int RewardPerCheck = 1;
    private const float RewardPeriodSec = 0.1f;

    public int Score;

    private float _nextCheckTime;

    private void Update()
    {
        if (!IsTimeToCheck())
        {
            return;
        }

        SetNextCheckTime();

        Score += GetReward();

        UnityEngine.Debug.Log($"Reward is now {Score} points!");
    }

    private int GetReward()
    {
        return RewardPerCheck;
    }

    private float CurrentTimeProvider()
    {
        return Time.time;
    }

    private bool IsTimeToCheck()
    {
        var currentTime = CurrentTimeProvider();

        return _nextCheckTime < currentTime;
    }

    private void SetNextCheckTime()
    {
        _nextCheckTime = CurrentTimeProvider() + RewardPeriodSec;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 100), "Score: " + Score);
    }
}
