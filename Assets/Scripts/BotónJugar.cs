using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotónJugar : MonoBehaviour
{
    private bool primera = true;
    public void LoadSceneFromZero(string sceneName)
    {
        if (primera)
        {
            SceneManager.LoadScene(sceneName);
            primera = false;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        }

        Time.timeScale = 1.0f;
    }

    public void ExitApplication()
    {
        // Cierra la aplicación
        Application.Quit();
    }
}
