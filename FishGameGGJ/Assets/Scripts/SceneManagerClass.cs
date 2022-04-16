using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerClass : MonoBehaviour
{
    public Button loadGame;
    public Button menuUI;
    public Button portraitToggleON;
    public Button portraitToggleOFF;
    //public CameraPivot portraitMode;
    public bool menuUIShow;
    public bool controlUIShow;
    public int sceneToLoad;
    public GameObject menu;
    public GameObject controls;

    public void PlayOnAwake()
    {
        controlUIShow = false;
        CameraPivot portraitMode= FindObjectOfType<CameraPivot>(); 
    }

    private void Start()
    {
        loadGame.onClick.AddListener(LoadGame);
        menuUI.onClick.AddListener(ShowControlMenu);
        SoundManager.Instance.PlayMusic(Music.UI_Game_Audio);
    }

    private void Update()
    {
        if(menuUIShow)
        {
            Menu();
            if (controlUIShow)
            {
                ControlMenu();
            }
            else
            {

            }
        }

        if(portraitMode.isPortrait)
        {
            //portraitToggleON.colors.normalColor = Color.green;
            //portraitToggleOFF.colors.normalColor = Color.red;
        }
        else
        {
            //portraitToggleON.colors.normalColor = Color.red;
            //portraitToggleOFF.colors.normalColor. = Color.green;
        }

    }

    public void LoadGame()
    {
        SoundManager.Instance.PlaySound(Sound.Button_Click);
        SceneManager.LoadScene(sceneToLoad);
    }

    public void ShowControlMenu()
    {
        SoundManager.Instance.PlaySound(Sound.Button_Click);
        controlUIShow = true;
    }

    public void Menu()
    {
        menu.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.SetActive(false);
            menuUIShow = false;
        }

        portraitToggleON.onClick.AddListener(Portrait);

        portraitToggleOFF.onClick.AddListener(NoPortrait);


    }
    public void ControlMenu()
    {
        controls.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            controls.SetActive(false);
            controlUIShow = false;
        }

    }

    public void Portrait()
    {
        portraitMode.isPortrait = true;
    }

    public void NoPortrait()
    {
        portraitMode.isPortrait = false;
    }

}
