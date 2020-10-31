using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game World");
    }

    public void Exit()
    {
        Debug.Log("Exiting Program");
        Application.Quit();
        
    }
}
