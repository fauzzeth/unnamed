using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private void OpenLevelChoose() 
    {
        SceneManager.LoadScene(1);
    }
    public void OpenLevel1()
    {
        SceneManager.LoadScene(2);
    }
    private void OpenLevel2()
    {
        SceneManager.LoadScene(3);
    }
    private void OpenLevel3()
    {
        SceneManager.LoadScene(4);
    }
    private void Back() 
    {
        SceneManager.LoadScene(1);
    }
}
