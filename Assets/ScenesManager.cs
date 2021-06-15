using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    string activeScene;
    // Start is called before the first frame update
    void Start()
    {
        activeScene = SceneManager.GetActiveScene().name;
    }

    public void RecargarEscena()
    {
        CargarEscena(activeScene);
    }

    public void CargarEscena(string name)
    {
        LeanTween.cancelAll();
        SceneManager.LoadScene(name);
    }


}
