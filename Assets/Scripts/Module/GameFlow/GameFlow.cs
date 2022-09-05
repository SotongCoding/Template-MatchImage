using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public static GameFlow Instance;
    public GameTimer _timer { private set; get; }

    public bool isGameStart = false;
    public System.Action OnGameStart;
    public System.Action<bool> OnGameEnd;

    private void Awake()
    {
        Instance = this;
        _timer = new GameTimer(300,
        () => { GameOver(false); });

        OnGameStart += () => { isGameStart = true; };
        OnGameStart += () => { StartCoroutine(_timer.StartCount()); };

    }

    public void StartGame()
    {
        OnGameStart?.Invoke();
    }
    public void GameOver(bool isMatchComplete)
    {
        OnGameEnd?.Invoke(isMatchComplete);
    }
}
