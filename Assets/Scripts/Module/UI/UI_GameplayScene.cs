using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class UI_GameplayScene
{
    public TextMeshProUGUI timerText;

    public void UpdateTimeUI(int time)
    {
        timerText.text = time.ToString();
    }
}
