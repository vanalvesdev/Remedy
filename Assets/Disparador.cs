using UnityEngine;
using System.Collections;

public class Disparador : MonoBehaviour
{

    public GameObject remedio;
    public GameObject cafe;
    public GameObject sofa;
    public float tempoDisparar;
    private float tempoAtual;
    public float percentual;
    private Controller controller;
    public float tempoSofa;
    private float tempoAtualSofa;
    private bool sofaSpawned;
    public float speedProjeteis;
    // Use this for initialization

    void Awake()
    {
        controller = GameObject.Find("Controller").GetComponent<Controller>();
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!controller.gameOver && !sofaSpawned)
        {
            tempoAtual += Time.deltaTime;
            tempoAtualSofa += Time.deltaTime;
            if (tempoAtual >= tempoDisparar)
            {
                tempoAtual = 0;
                int opcao = Random.Range(1, 100);
                if (opcao <= percentual)
                {
                    GameObject temp = Instantiate(remedio);
                    temp.transform.position = transform.position;
                    temp.GetComponent<Projeteis>().speed = speedProjeteis;
                }
                else
                {
                    GameObject temp = Instantiate(cafe);
                    temp.transform.position = transform.position;
                    temp.GetComponent<Projeteis>().speed = speedProjeteis;
                }
            }

            if(tempoAtualSofa >= tempoSofa)
            {
                sofaSpawned = true;
                tempoAtualSofa = 0;
                GameObject tempSofa = Instantiate(sofa);
                tempSofa.transform.position = transform.position;                
            }
        }
    }
}
