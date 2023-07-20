using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Scene_1");
        FindObjectOfType<AudioManager>().Play("clickPlay");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
