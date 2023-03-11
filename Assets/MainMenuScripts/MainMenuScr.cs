using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScr : MonoBehaviour
{
    public void Znaminja()
    {
        SceneManager.LoadScene(1);
    }
    public void Zadaci()
    {
        SceneManager.LoadScene(2);
    }
    public void Slozuvalka()
    {
        SceneManager.LoadScene(5);
    }
    public void YesOrNo()
    {
        SceneManager.LoadScene(3);
    }
}
