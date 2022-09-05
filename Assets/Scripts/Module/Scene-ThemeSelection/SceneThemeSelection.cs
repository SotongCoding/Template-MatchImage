using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using TMPro;

public class SceneThemeSelection : MonoBehaviour
{
    [SerializeField] private ThemeShowController themeShowController;

    [Header("Other UI")]
    public TextMeshProUGUI currencyText;
    public UnityEngine.UI.Button backButton;


    private void Start()
    {
        themeShowController.ShowTheme();
        UpdateCurrency(SaveData.Instance.playerCoins);
        backButton.onClick.AddListener(ReturnMenu);
    }

    public void UpdateCurrency(int coinLeft)
    {
        currencyText.text = SaveData.Instance.playerCoins.ToString();
    }
    public void UpdateThemeSelected(int newThemeSelected)
    {
        themeShowController.ChangeThemeSelected(newThemeSelected);
    }
    void ReturnMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
