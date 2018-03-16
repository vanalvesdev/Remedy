using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void iniciar()
    {
        GameObject controller = GameObject.Find("Controller");
        if(controller != null)
        {
            Destroy(controller);
        }
            SceneManager.LoadScene("Fase 1");
        
        
    }

    void sair()
    {
        Application.Quit();
    }
}
