using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGameplay : MonoBehaviour
{
    [SerializeField] TileGroup tileGroup;
    [SerializeField] UI_GameplayScene gameplayUI;

    private void Start()
    {
        GameFlow.Instance._timer.OnChangeTime += gameplayUI.UpdateTimeUI;
        tileGroup.CreateTile();

      Invoke("StartGame",3);
    }

    void StartGame()
    {
        tileGroup.DisableLayout();
        GameFlow.Instance.StartGame();
    }
}
