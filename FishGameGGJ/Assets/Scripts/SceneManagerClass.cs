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
    public Button returnMenuButton;
    public Button returnControlButton;
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
        SoundManager.Instance.PlayMusic(Music.UI_Game_Audio);

    }

    private void OnEnable()
    {
        loadGame.onClick.AddListener(LoadGame);
        menuUI.onClick.AddListener(ShowMenu);
        japaneseToggleON.onClick.AddListener(Japanese);
        japaneseToggleOFF.onClick.AddListener(NoJapanese);

        if (controls != null)
        {
            controls.onClick.AddListener(ShowControlMenu);
        }

        returnMenuButton.onClick.AddListener(Return);
        returnControlButton.onClick.AddListener(Return);

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
    }

    public void NoJapanese()
    {
        SoundManager.Instance.PlaySound(Sound.Button_Click);
        tM.isChanged = false;
    }

    public void Return()
    {
        print(menuUIShow);
        print(controlUIShow);
        if (controlUIShow)
        {
            controlUIShow = false;
            controlsUI.SetActive(false);
        }
        else if (menuUIShow && !controlUIShow)
        {
            print("thoust mother");
            menuUIShow = false;
            menu.SetActive(false);
        }
    }
}
