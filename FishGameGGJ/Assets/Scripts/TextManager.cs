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
        //upperBounds = japaneseBoxes.GetUpperBound(upperBounds);
    }

    // Update is called once per frame
    void Update()
    {
        if (isChanged)
        {
            isJapanese = true;
            print("isJapanese = " + isJapanese);
        }

        if (isJapanese)
        {
            for (int i = 0; i <= upperBounds - 1; i++)
            {
                print("i = " + i);
                japaneseBoxes[i].SetActive(true);
                englishBoxes[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i <= upperBounds; i++)
            {
                print("i = " + i);
                japaneseBoxes[i].SetActive(false);
                englishBoxes[i].SetActive(true);
            }
        }
    }
}
