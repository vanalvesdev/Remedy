using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ze : MonoBehaviour {

    public Text texto;
    private int pontuacao;
    public float jumpSpeed;
    public LayerMask layerChao;
    private Rigidbody2D myBody;
    private Animator animator;
    public Controller controller;
    private int life;
    public Sprite life2;
    public Sprite life1;
    public Sprite life0;
    public Image hud;
    // Use this for initialization
    
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(GameObject.Find("Canvas"));
        controller = GameObject.Find("Controller").GetComponent<Controller>();
    }

    void Start () {
        myBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        life = 3;
	}
	
	// Update is called once per frame
	void Update () {
        bool tocandoChao = myBody.IsTouchingLayers(layerChao);
        if (Input.GetButtonDown("Jump") && tocandoChao)
        {
            myBody.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
        }
        animator.SetBool("tocandoChao", tocandoChao);
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        
        if (coll.gameObject.tag == "Remedio")
        {
            Destroy(coll.gameObject);
            pontuacao++;
            texto.text = "Pontuação: " + pontuacao;
        }
        else if(coll.gameObject.tag == "Cafe")
        {
            Destroy(coll.gameObject);
            life--;
            if (life == 2)
            {
                hud.sprite = life2;
            }
            if(life == 1)
            {
                hud.sprite = life1;
            }
            if (life == 0)
            {
                hud.sprite = life0;
                controller.SendMessage("GameOver");
                Destroy(this.gameObject);
            }
        }
        else if(coll.gameObject.tag == "Sofa")
        {
            controller.SendMessage("proximaFase");
        }
    }
}
