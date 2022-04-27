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
    //public CameraPivot portraitMode;
    public bool menuUIShow;
    public bool controlUIShow;
    public int sceneToLoad;
    public GameObject menu;
    public GameObject controlsUI;

    public Button loadGamePortrait;

    public void PlayOnAwake()
    {
        tM = FindObjectOfType<TextManager>();
        controlUIShow = false;
        //CameraPivot portraitMode= FindObjectOfType<CameraPivot>(); 
    }

    private void Start()
    {
        loadGame.onClick.AddListener(LoadGame);
        loadGamePortrait.onClick.AddListener(LoadGame);
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
        if (Input.GetKeyDown(KeyCode.Escape) && !controlUIShow)
        {
            print(KeyCode.Return);
            menu.SetActive(false);
            menuUIShow = false;
        }

        //controls.onClick.AddListener(ShowControlMenu);

        japaneseToggleON.onClick.AddListener(Japanese);

        japaneseToggleOFF.onClick.AddListener(NoJapanese);

        controls.onClick.AddListener(ShowControlMenu);


    }
    public void ControlMenu()
    {
        controlsUI.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            controlsUI.SetActive(false);
            controlUIShow = false;
            menu.SetActive(true);
        }

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

}
