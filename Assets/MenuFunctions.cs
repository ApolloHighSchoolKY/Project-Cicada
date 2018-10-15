using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour
{
    public void QuitGame()
    {   //Lets player close application
        Debug.Log("This is working"); //Test message to make sure quit button is working
        Application.Quit();
    }

    public void PlayGame()
    {   //Moves from menu to game
        Debug.Log("This is working");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    public void Options()
    {
        //Currently does nothing
    }
}
