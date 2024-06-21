using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotónSalir : MonoBehaviour
{
    public void exit(string sceneName)
    {
        // Carga la escena especificada desde cero
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
