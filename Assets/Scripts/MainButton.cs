using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CargarUnaEscena()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void CargarNombreEscena(string nombreNivel)
    {
        SceneManager.LoadScene("nombreNivel");
    }
    
}
