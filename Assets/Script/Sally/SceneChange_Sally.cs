using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange_Sally : MonoBehaviour
{
    public void StartScene()
    {
        SceneManager.LoadScene("StartScnen");
    }

    public void SecondScene()
    {
        SceneManager.LoadScene("Main_Sally");
    }
}
