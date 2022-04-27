using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public GameObject upperLevel;
    public GameObject upperRocksParent;
    public GameObject upperWater;
    public GameObject lowerLevel;
    public GameObject FishOne;
    public GameObject FishTwo;
    public GameObject camPiv;

    CameraPivot shaker;

    public float defaultObjectTransparency = 1f;
    public float defaultWaterTransparency = 0.7f;
    public float fadeDuration = 0.5f;
    public float levelMoveSpeed = 1f;
    public float levelVerticalMovement = 0.6f;
    public bool DiveFailure = false;

    //false means the fish are on the surface of the water, true means they're deep in the water
    public bool DiveState = false;

    private bool LastDiveState = false;
    private bool timerStart = false;
    private float timerTarget = 1f;
    private Vector3 upperOriginalPosition;
    private Vector3 lowerOriginalPosition;
    private Vector3 upperMoveUp;
    private Vector3 lowerMoveUp;

    [SerializeField] Button diveButton;

    private void OnEnable()
    {
        diveButton.onClick.AddListener(HandleDivePressed);
    }

    private void OnDisable()
    {
        diveButton.onClick.RemoveListener(HandleDivePressed);
    }

    void Start()
    {
        shaker = camPiv.GetComponent<CameraPivot>();
        upperMoveUp = new Vector3(upperLevel.transform.position.x, (upperLevel.transform.position.y + levelVerticalMovement), upperLevel.transform.position.z);
        lowerMoveUp = new Vector3(lowerLevel.transform.position.x, (lowerLevel.transform.position.y + levelVerticalMovement), lowerLevel.transform.position.z);
        upperOriginalPosition = new Vector3(upperLevel.transform.position.x, upperLevel.transform.position.y, upperLevel.transform.position.z);
        lowerOriginalPosition = new Vector3(lowerLevel.transform.position.x, lowerLevel.transform.position.y, lowerLevel.transform.position.z);
    }

    void Update()
    {
        if (DiveFailure == true && FishOne.GetComponent<Fish>().LateralMoveAllowed == true && FishTwo.GetComponent<Fish>().LateralMoveAllowed)
        {
            Debug.Log("Dive Failure cleared");
            DiveFailure = false;
        }

        //User feedback would be ideal
        if (DiveState == true && !DiveFailure && FishOne.GetComponent<Fish>().LateralMoveAllowed == true && FishTwo.GetComponent<Fish>().LateralMoveAllowed == true)
        {
            if (LastDiveState != DiveState)
            {
                FishOne.GetComponent<Fish>().movementForce = 0;
                FishTwo.GetComponent<Fish>().movementForce = 0;
                timerStart = true;
                LastDiveState = true;
            }

            if (timerStart)
            {
                timerTarget -= Time.deltaTime;
            }

            if (timerTarget <= 0.0f)
            {
                FishOne.GetComponent<Fish>().movementForce = 7;
                FishTwo.GetComponent<Fish>().movementForce = 7;
                timerTarget = 1f;
            }

            Dive();

            //This for loop is meant to make the rocks turn transparent, but doesn't work due to gltiches when setting the rocks to a transparent object
            /*for (int i = 0; i < upperRocksParent.transform.childCount; i++)
            {
                Renderer objRender = upperRocksParent.transform.GetChild(i).GetComponent<Renderer>();
                Material objMat = objRender.material;
                changeAlpha(objMat);
            }*/

            Renderer waterRenderer = upperWater.GetComponent<Renderer>();
            Material watMat = waterRenderer.material;
            changeAlpha(watMat, .565f);
        }
        else if (DiveState == true && LastDiveState == false)
        {
            Debug.Log("Set dive state to true, can't dive here");
            //ADD USER FEEDBACK HERE (Screenshake & Audio Clip) Call Emily's camera shake function, then play audio
            shaker.StartShake(.5f, .3f);

            SoundManager.Instance.PlaySound(Sound.FailDive);

            DiveState = false;
            DiveFailure = true;
        }

        //User feedback would be ideal
        if (DiveState == false && !DiveFailure && FishOne.GetComponent<Fish>().LateralMoveAllowed == true && FishTwo.GetComponent<Fish>().LateralMoveAllowed == true)
        {
            if (LastDiveState != DiveState)
            {
                FishOne.GetComponent<Fish>().movementForce = 0;
                FishTwo.GetComponent<Fish>().movementForce = 0;
                timerStart = true;
                LastDiveState = false;
            }

            if (timerStart)
            {
                timerTarget -= Time.deltaTime;
            }

            if (timerTarget <= 0.0f)
            {
                FishOne.GetComponent<Fish>().movementForce = 7;
                FishTwo.GetComponent<Fish>().movementForce = 7;
                timerTarget = 1f;
            }

            Ascend();

            //This for loop is meant to make the rocks turn opaque, but doesn't work due to gltiches when setting the rocks to a transparent object
            /*for (int i = 0; i < upperRocksParent.transform.childCount; i++)
            {
                Renderer objrender = upperRocksParent.transform.GetChild(i).GetComponent<Renderer>();
                Material objmat = objrender.material;
                changeAlpha(objmat);
            }*/

            Renderer waterrenderer = upperWater.GetComponent<Renderer>();
            Material watmat = waterrenderer.material;
            changeAlpha(watmat, .565f);
        }
        else if (DiveState == false && LastDiveState == true)
        {
            Debug.Log("Set dive state to false, can't ascend here");
            //ADD USER FEEDBACK HERE (Screenshake & Audio Clip) Call Emily's camera shake function, then play audio
            shaker.StartShake(.5f, .3f);

            SoundManager.Instance.PlaySound(Sound.FailDive);

            DiveState = true;
            DiveFailure = true;
        }
    }

    private void Dive()
    {
        upperLevel.transform.position = Vector3.MoveTowards(upperLevel.transform.position, upperMoveUp, levelMoveSpeed * Time.deltaTime);
        lowerLevel.transform.position = Vector3.MoveTowards(lowerLevel.transform.position, lowerMoveUp, levelMoveSpeed * Time.deltaTime);

        DiveState = true;
    }

    private void Ascend()
    {
        upperLevel.transform.position = Vector3.MoveTowards(upperLevel.transform.position, upperOriginalPosition, levelMoveSpeed * Time.deltaTime);
        lowerLevel.transform.position = Vector3.MoveTowards(lowerLevel.transform.position, lowerOriginalPosition, levelMoveSpeed * Time.deltaTime);

        DiveState = false;
    }

    //This function used to break and cause some severe visual glitches, resolved by changing the calculations for newTransparency
    private void changeAlpha(Material mat, float maxAlpha = 1)
    {
        //sets the new transparency to the original color to start off
        float newTransparency = mat.color.a;

        if(DiveState == true)
        {
            if(mat.color.a > 0)
            {
                newTransparency -= mat.color.a / fadeDuration * Time.deltaTime;
                mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, newTransparency);
                //Debug.Log($"The current alpha value is: {mat.color.a}");
            }
        }
        else
        {
            if(mat.color.a < maxAlpha)
            {
                float tempDist = mat.color.a - defaultObjectTransparency;
                newTransparency -= tempDist / fadeDuration * Time.deltaTime;
                mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, newTransparency);
                //Debug.Log($"The current alpha value is: {mat.color.a}");
            }
        }
    }

    void HandleDivePressed()
    {
        DiveState = !DiveState;
        if (DiveState)
        {
            diveButton.transform.localScale = Vector3.one;
        }
        else
        {
            diveButton.transform.localScale = -Vector3.one;
        }
    }
}
