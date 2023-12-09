using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OpenLevelChoose() 
    {
        SceneManager.LoadScene(1);
    }
    public void OpenLevel1()
    {
        SceneManager.LoadScene(2);
    }
    public void OpenLevel2()
    {
        SceneManager.LoadScene(3);
    }
    public void Back() 
    {
        SceneManager.LoadScene(0);
    }
}
