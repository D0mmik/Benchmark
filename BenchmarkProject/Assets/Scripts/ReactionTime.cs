using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReactionTime : MonoBehaviour
{
    public float waitTime = 0;
    public GameObject green;
    public GameObject red;
    
    private float reactionTime = 0;
    private float startTime = 0;
    private float delay = 0;
    public bool countingTime = false;
    public bool canStop = true;

    public TMP_Text mainText;
    public GameObject mainTextGO;
    public GameObject tryAgain;
    public GameObject clickToStart;
    void Start()
    {
        clickToStart.SetActive(true);
        reactionTime = 0f;
        startTime = 0f;
        delay = 0f;
        countingTime = false;
        canStop = false;
        tryAgain.SetActive(false);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && PauseMenu.paused == false)
        {
            clickToStart.SetActive(false);
            if(countingTime == false)
            {
                StartCoroutine("StartCounting");
                red.SetActive(true);
                green.SetActive(false);
                countingTime = true;
                canStop = false;
                tryAgain.SetActive(false);
                mainTextGO.SetActive(false);
                
            }
            else if (countingTime && canStop)
            {
                StopCoroutine("StartCounting");
                reactionTime = Time.time - startTime;
                countingTime = false;
                mainTextGO.SetActive(true);
                mainText.text = (reactionTime * 1000).ToString();
                tryAgain.SetActive(true);
            }
            else if(countingTime && canStop == false)
            {
                StopCoroutine("StartCounting");
                reactionTime = 0f;
                countingTime = false;
                canStop = true;
                mainTextGO.SetActive(true);
                mainText.text = "TOO EARLY";
                tryAgain.SetActive(true);
            }
            if(countingTime ==  true)
            {
            mainTextGO.SetActive(false);
            }

        }

    }
    IEnumerator StartCounting()
    {
        delay = Random.Range(1f,5f);
        yield return new WaitForSeconds(delay);
        green.SetActive(true);
        red.SetActive(false);
        startTime = Time.time;
        countingTime = true;
        canStop = true;
    }
    

}
