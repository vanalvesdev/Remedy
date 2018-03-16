using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviour {
    public bool gameOver;
    public GameObject textRestart;
    public GameObject textWin;
    private float faseAtual;
    public Text textoLevel;
	// Use this for initialization
	void Start () {
        faseAtual = 1;
        DontDestroyOnLoad(this.gameObject);
        textoLevel.text = "Level " + faseAtual;
    }
	
	// Update is called once per frame
	void Update () {
        if (gameOver  && Input.GetKeyDown(KeyCode.R)){
            Destroy(GameObject.Find("Canvas"));
            SceneManager.LoadScene("Menu");
        }
	}

    void GameOver()
    {
        gameOver = true;
        textRestart.SetActive(true);
    }

    void Vencer()
    {
        gameOver = true;
        textWin.SetActive(true);
    }

    void proximaFase()
    {
        faseAtual++;
        if (faseAtual < 4)
        {
            SceneManager.LoadScene("Fase " + faseAtual);
            textoLevel.text = "Level " + faseAtual;
        }else
        {
            Vencer();
        }
        
    }
}
