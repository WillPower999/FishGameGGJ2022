using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using UnityEngine.UI;

public class SceneManagerClass : MonoBehaviour
{
    public Button loadGame;
    public Button controlUI;
    public bool controlUIShow;
    public int sceneToLoad;
    public GameObject controls;

    public void PlayOnAwake()
    {
        controlUIShow = false;
    }

    private void Start()
    {
        loadGame.onClick.AddListener(LoadGame);
        controlUI.onClick.AddListener(ShowControlMenu);
    }

    private void Update()
    {
        if (controlUIShow)
        {
            ControlMenu();
        }
        else
        {

        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void ShowControlMenu()
    {
        controlUIShow = true;
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

}
