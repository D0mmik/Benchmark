using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class AimTrainer : MonoBehaviour
{
    [SerializeField] private GameObject countSelector;
    [SerializeField] private int count = 30;
    [SerializeField] private GameObject target;
    private GameObject targetClone;
    private float minX = -9.5f;
    private float maxX = 9.5f;
    private float minY = -4.1f;
    private float maxY = 4.1f;
    private Vector3 spawnPosition;
    public static bool canSpawn = true;

    public static bool counting = false;

    public float time;
    public float startTime;

    public TMP_Text avgTime;
    public GameObject avgTimeGO;

    public GameObject restartButton;



    void Start()
    {
        countSelector.SetActive(true);
        SpawnTarget();
        canSpawn = false;
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SpawnTarget();
        }

        if(counting == true)
        {
            time = Time.time - startTime;
        }
        else if(counting == false)
        {
            avgTimeGO.SetActive(true);
            avgTime.text = ($"PRŮMĚRNÝ ČAS JE {(startTime / 30 )* 1000} ms");
            restartButton.SetActive(true);
        }
    }
    public void SpawnTarget()
    {
        if(canSpawn == true && count >= 1)
        {
            spawnPosition = new Vector3(Random.Range(minX,maxX),Random.Range(minY,maxY), 0);
            targetClone = Instantiate(target,spawnPosition,Quaternion.identity);
            canSpawn = false;
            count--;

            counting = true;
            startTime = Time.timeSinceLevelLoad;
        }
    }
    public void ResetButton()
    {
        SceneManager.LoadScene("AimTrainer");
    }
}
