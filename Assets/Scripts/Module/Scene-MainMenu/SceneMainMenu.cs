using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;
public class SceneMainMeni : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button ThemeSelectButton;


    private void Start() {
        playButton.onClick.AddListener(LoadGameplay);
        playButton.onClick.AddListener(LoadThemeSelect);
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
