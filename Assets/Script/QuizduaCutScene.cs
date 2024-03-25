using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizduaCutScene : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("quizdua", LoadSceneMode.Single);
    }
}

