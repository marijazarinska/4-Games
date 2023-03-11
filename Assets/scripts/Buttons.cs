using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);    //da otide od edna scena na druga
    }

 /* public void CloseApplication()
    {
        Application.Quit();
    }*/
}
