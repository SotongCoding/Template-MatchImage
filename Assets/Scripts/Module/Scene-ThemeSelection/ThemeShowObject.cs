using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;
using System;

public class ThemeShowObject : MonoBehaviour
{
    public TextMeshProUGUI themeName_text;
    public TextMeshProUGUI price_text;
    public Image themeUseIndicator;
    public Image baseImage;
    public Button actionButton;

    private bool isUnlock;
    private int themeId;
    private int price;
    SceneThemeSelection themeScene;

    internal void Initial(int themeId, string themeName, int price, bool onUse, bool isUnlock)
    {
        this.isUnlock = isUnlock;
        this.themeId = themeId;
        this.price = price;

        themeName_text.text = themeName;
        price_text.text = price.ToString();
        themeUseIndicator.enabled = onUse;

        baseImage.color = isUnlock ? Color.black : new Color(0, 0, 0, 0.3f);
        price_text.enabled = !isUnlock;

        actionButton.onClick.AddListener(ButtonEvent);
        themeScene = FindObjectOfType<SceneThemeSelection>();
    }

    public void SetActiveIndicator(bool isActive)
    {
        themeUseIndicator.enabled = isActive;
    }

    void ButtonEvent()
    {
        if (!isUnlock)
        {
            if (Currency.Instance.TrySpeendMoney(price, out var moneyLeft))
            {
                isUnlock = true;
                baseImage.color = Color.black;
                themeScene.UpdateCurrency(moneyLeft);
                SaveData.Instance.UpdateUnlockTheme(themeId);
                price_text.enabled = false;
            }
        }
        else
        {
            Debug.Log("set Theme : " + themeId);
            themeScene.UpdateThemeSelected(themeId);

            SaveData.Instance.UpdateUseTheme(themeId);

        }
    }
}
