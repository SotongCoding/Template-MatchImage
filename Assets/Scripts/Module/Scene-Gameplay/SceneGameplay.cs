using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class SceneGameplay : MonoBehaviour
{
    [SerializeField] private TileGroup tileGroup;
    [SerializeField] private UI_GameplayScene gameplayUI;
    [SerializeField] private Canvas gameOverCanvas;
    [SerializeField] private Canvas gameplayCanvas;

    [SerializeField] private TextMeshProUGUI endGameTextMessage;


    private void Start()
    {
        GameFlow.Instance._timer.OnChangeTime += gameplayUI.UpdateTimeUI;
        tileGroup.CreateTile();

        GameFlow.Instance.OnGameEnd += GameOver;
    }

    private void StartGame()
    {
        tileGroup.DisableLayout();
        GameFlow.Instance.StartGame();
    }

    private void GameOver(bool isMatchComplete)
    {
        gameplayCanvas.enabled = false;
        gameOverCanvas.enabled = true;

        if (isMatchComplete)
        {
            endGameTextMessage.text = "WELL DONE !!\n Gain 100";
            Currency.Instance.AddCoin(100);
        }
        else
        {
            endGameTextMessage.text = "Time UP";
        }
    }
}
