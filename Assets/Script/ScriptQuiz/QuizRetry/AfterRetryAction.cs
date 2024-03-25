using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterRetryAction : MonoBehaviour
{
    public void GoBackToLevel(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 6);
        // movementChar.TakeDamage();

        // if(SceneManager.GetActiveScene().buildIndex == )
        
    }

    public void GoBackToLevel2(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
        // movementChar.TakeDamage();

        // if(SceneManager.GetActiveScene().buildIndex == )
        
    }

    public void GoBackToMainMenu(){

         SceneManager.LoadScene("SampleScene");

    }
}
