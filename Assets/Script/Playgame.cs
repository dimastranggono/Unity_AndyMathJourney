using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playgame : MonoBehaviour
{
    public void PlayGame()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);// this can load the scene number 1 (game)//SceneManager.GetActiveScene().buildIndex +1

    }

    public void GoSettingMenu(){
        SceneManager.LoadScene("Soundsetting");
    }

    public void GoMainMenu(){
        SceneManager.LoadScene("mainmenu");
    }

    public void QuitGame()
    {

        Application.Quit();
    }
}