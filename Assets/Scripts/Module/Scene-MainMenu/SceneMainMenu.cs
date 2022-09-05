using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;
public class SceneMainMenu : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button ThemeSelectButton;


    private void Start() {
        playButton.onClick.AddListener(LoadGameplay);
        ThemeSelectButton.onClick.AddListener(LoadThemeSelect);
    }

    private void LoadGameplay()
    {
       SceneManager.LoadScene("Gameplay");
    }

    private void LoadThemeSelect()
    {
       SceneManager.LoadScene("Theme");
    }
}
