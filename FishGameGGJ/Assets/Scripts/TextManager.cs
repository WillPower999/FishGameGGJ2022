using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    static public bool isJapanese;
    [HideInInspector] public bool isChanged;
    public GameObject[] englishBoxes;
    public GameObject[] japaneseBoxes;
    public int upperBounds;
    // Start is called before the first frame update
    void Start()
    {
        if (Application.systemLanguage == SystemLanguage.English)
        {

        }
        else
        {
            isJapanese = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isChanged)
        {
            isJapanese = true;
        }
        else
        {
            isJapanese = false;
        }

        if (isJapanese)
        {
            for (int i = 0; i <= upperBounds - 1; i++)
            {
                japaneseBoxes[i].SetActive(true);
                englishBoxes[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i <= upperBounds; i++)
            {
                japaneseBoxes[i].SetActive(false);
                englishBoxes[i].SetActive(true);
            }
        }
    }
}
