using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject games;
    public void Play()
    {
        games.SetActive(true);

    }
    public void ReactionTime()
    {
        SceneManager.LoadScene("ReactionTime");
    }
    public void NumberMemory()
    {
        SceneManager.LoadScene("NumberMemory");
    }
    public void AimTrainer()
    {
        SceneManager.LoadScene("AimTrainer");
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
