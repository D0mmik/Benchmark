using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NumberMemory : MonoBehaviour
{
    [SerializeField] private int lvl = 1;
    public float minNumber;
    public float maxNumber;
    public ulong randomNumber;
    public TMP_Text randomNumberText;
    public GameObject randomNumberTextGO;
    public GameObject RestartButton;
    public GameObject checkButton;
    public TMP_Text randomNumberIP;
    public GameObject randomNumberIPGO;
    public bool areEqual;
    public bool countdown;
    public float timer;
    public float timerNumber;
    public Image timerBar;
    public Image timerBar2;
    public GameObject restartButton;
    public TMP_Text numbersNotEqual;
    public GameObject numbersNotEqualGO;

    void Start()
    {
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.001f);
        GenerateRandomNumber();
    }
    public void NextLevel()
    {
        lvl++;
        StartCoroutine(Wait());
        
    }
    void Update()
    {
        if(lvl == 1){minNumber = 1;maxNumber = 9;}
        if(lvl == 2){minNumber = 10;maxNumber = 99;}
        if(lvl == 3){minNumber = 100;maxNumber = 999;}
        if(lvl == 4){minNumber = 1000;maxNumber = 9999;}
        if(lvl == 5){minNumber = 10000;maxNumber = 99999;}
        if(lvl == 6){minNumber = 100000;maxNumber = 999999;}
        if(lvl == 7){minNumber = 1000000;maxNumber = 9999999;}
        if(lvl == 8){minNumber = 10000000;maxNumber = 99999999;}
        if(lvl == 9){minNumber = 100000000;maxNumber = 999999999;}
        if(lvl == 10){minNumber = 1000000000;maxNumber = 9999999999;}
        if(lvl == 11){minNumber = 10000000000;maxNumber = 99999999999;}
        if(lvl == 12){minNumber = 100000000000;maxNumber = 999999999999;}
        if(lvl == 13){minNumber = 1000000000000;maxNumber = 9999999999999;}
        if(lvl == 14){minNumber = 10000000000000;maxNumber = 99999999999999;}
        if(lvl == 15){minNumber = 100000000000000;maxNumber = 999999999999999;}
        if(lvl == 16){minNumber = 1000000000000000;maxNumber = 9999999999999999;}
        if(lvl == 17){minNumber = 10000000000000000;maxNumber = 99999999999999999;}
        if(lvl == 18){minNumber = 100000000000000000;maxNumber = 999999999999999999;}
        if(lvl == 20){minNumber = 1000000000000000000;maxNumber = 9999999999999999999;}


        if(countdown == true && timerNumber != 0)
        {
            timer += Time.deltaTime % 60;
            if(timer >= 1)
            {
                timerNumber--;
                timerBar.fillAmount = timerNumber / 5;
                timerBar2.fillAmount = timerNumber / 5;

                timer = 0;
            }

        }

    }
    void GenerateRandomNumber()
    {
        randomNumber = (ulong)Random.Range(minNumber,maxNumber);
        randomNumberTextGO.SetActive(true);
        randomNumberText.text = randomNumber.ToString();
        StartCoroutine(WaitTime());
        timerNumber = 5;
        countdown = true;
    }
    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(5f);
        randomNumberTextGO.SetActive(false);
        randomNumberIPGO.SetActive(true);
        checkButton.SetActive(true);
    }

    public void Check()
    {
        if(timerNumber == 0)
        {
            checkButton.SetActive(false);
            randomNumberIPGO.SetActive(false);
            
            if(randomNumber.ToString().Length != randomNumberIP.text.Length){areEqual = false;}else{areEqual = true;}
            for (int i = 0; i < randomNumber.ToString().Length; i++)
            {
                var c1 = randomNumber.ToString()[i];
                var c2 = randomNumberIP.text[i];
                if (c1 != c2){areEqual = false;}else{areEqual = true;}
            }
            if(areEqual)
            {
                NextLevel();
            }
            else if (areEqual == false)
            {
                Debug.Log(randomNumber);
                Debug.Log(randomNumberIP.text);
                numbersNotEqualGO.SetActive(true);
                numbersNotEqual.text = ($"{randomNumber} ≠ {randomNumberIP.text}");
                restartButton.SetActive(true);
            }
        }

    }
    public void ResetButton()
    {
        SceneManager.LoadScene("NumberMemory");
    }
}
