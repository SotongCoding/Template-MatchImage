using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    #region  Constant save Name
    public const string PL_PREFS_USEDTHEME = "usedTheme";
    public const string PL_PREFS_PLAYERCOIN = "playerCoin";
    public const string PL_PREFS_UNLOCKTHEME = "unlockTheme";
    #endregion
    private static SaveData _instance;
    public static SaveData Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new SaveData();
                _instance.LoadData();
            }
            return _instance;
        }
    }

    public int usedThemeId { private set; get; } = 1;
    public int playerCoins { private set; get; } = 100;
    public UnlockThemeData unlockTheme { private set; get; } = new UnlockThemeData() { data = new List<int>() { 1 } };

    private void LoadData()
    {
        usedThemeId = PlayerPrefs.GetInt(PL_PREFS_USEDTHEME, 1);
        playerCoins = PlayerPrefs.GetInt(PL_PREFS_PLAYERCOIN, 100);


        string JSON = PlayerPrefs.GetString(PL_PREFS_UNLOCKTHEME,
        JsonUtility.ToJson(new UnlockThemeData() { data = new List<int>() { 1 } }));

        if (!string.IsNullOrEmpty(JSON))
        {
            unlockTheme = JsonUtility.FromJson<UnlockThemeData>(JSON);
        }
    }
    public void UpdateUseTheme(int newThemeId)
    {
        PlayerPrefs.SetInt(PL_PREFS_USEDTHEME, newThemeId);
        usedThemeId = newThemeId;
    }
    public void UpdatePlayerCoins(int amountAdd)
    {
        playerCoins += amountAdd;
        PlayerPrefs.SetInt(PL_PREFS_PLAYERCOIN, playerCoins);
    }
    public void UpdateUnlockTheme(int newThemeUnlock)
    {
        if (unlockTheme.AddTheme(newThemeUnlock))
        {
            PlayerPrefs.SetString(PL_PREFS_UNLOCKTHEME, JsonUtility.ToJson(unlockTheme));
            Debug.Log("new Theme Unlock " + JsonUtility.ToJson(unlockTheme));
        }
    }

    [System.Serializable]
    public struct UnlockThemeData
    {
        public List<int> data;
        public bool AddTheme(int themeId)
        {
            if (!data.Contains(themeId))
            {
                data.Add(themeId);
                return true;
            }
            return false;
        }
        public bool Contain(int checkId)
        {
            return data.Contains(checkId);
        }
    }

}
