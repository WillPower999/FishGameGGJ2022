using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerClass : MonoBehaviour
{
    public TextManager tM;
    public Button loadGame;
    public Button menuUI;
    public Button controls;
    public Button japaneseToggleON;
    public Button japaneseToggleOFF;
    public Button backControls;
    public Button backMenu;
    //public CameraPivot portraitMode;
    public bool menuUIShow;
    public bool controlUIShow;
    public int sceneToLoad;
    public GameObject menu;
    public GameObject controlsUI;

    public void PlayOnAwake()
    {
        tM = FindObjectOfType<TextManager>();
        controlUIShow = false;
        //CameraPivot portraitMode= FindObjectOfType<CameraPivot>(); 
    }

    private void Start()
    {
        loadGame.onClick.AddListener(LoadGame);
        menuUI.onClick.AddListener(ShowMenu);
        SoundManager.Instance.PlayMusic(Music.UI_Game_Audio);
    }

    private void Update()
    {
        if(menuUIShow)
        {
            Menu();
            if (controlUIShow)
            {
                menu.SetActive(false);
                ControlMenu();
            }
            else
            {

            }
        }

        if(tM.isChanged)
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
        //backMenu.onClick.RemoveListener(Return);
        controlUIShow = true;
    }

    public void ShowMenu()
    {
        SoundManager.Instance.PlaySound(Sound.Button_Click);
        menuUIShow = true;
    }
    
    public void Menu()
    {
        menu.SetActive(true);

        japaneseToggleON.onClick.AddListener(Japanese);

        japaneseToggleOFF.onClick.AddListener(NoJapanese);

        controls.onClick.AddListener(ShowControlMenu);
        controls.onClick.RemoveListener(Return);

        backMenu.onClick.AddListener(Return);


    }
    public void ControlMenu()
    {
        controlsUI.SetActive(true);

        backControls.onClick.AddListener(Return);
    }

    public void Japanese()
    {
        SoundManager.Instance.PlaySound(Sound.Button_Click);
        tM.isChanged = true;
        print("isChanged = " + tM.isChanged);
    }

    public void NoJapanese()
    {
        SoundManager.Instance.PlaySound(Sound.Button_Click);
        tM.isChanged = false;
        print("isChanged = " + tM.isChanged);
    }

    public void Return()
    {
        if(menuUIShow && !controlUIShow)
        {
            menu.SetActive(false);
            menuUIShow = false;
        }
        else if (controlUIShow)
        {
            controlsUI.SetActive(false);
            controlUIShow = false;
            menuUIShow = true;
            menu.SetActive(true);
        }
    }

}
