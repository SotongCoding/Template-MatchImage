using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ThemeShowController
{
    [SerializeField] private ThemeDatabase dataBase;
    [SerializeField] private ThemeShowObject themePrefabs;
    public Transform parentPlace;

    Dictionary<int, ThemeShowObject> allCreatedTheme = new Dictionary<int, ThemeShowObject>();
    public void ShowTheme()
    {
        int usedThemeData = SaveData.Instance.usedThemeId;
        foreach (var item in dataBase.GetAllThemes())
        {
            var theme = MonoBehaviour.Instantiate(themePrefabs, parentPlace);
            theme.Initial(item.themeId, item.themeName, item.price,
            usedThemeData == item.themeId, SaveData.Instance.unlockTheme.Contain(item.themeId));

            allCreatedTheme.Add(item.themeId, theme);
        }

    }

    internal void ChangeThemeSelected(int newThemeSelected)
    {
        allCreatedTheme[SaveData.Instance.usedThemeId].SetActiveIndicator(false);
        allCreatedTheme[newThemeSelected].SetActiveIndicator(true);
    }
}
