using UnityEngine;
using System.Collections;

public class Projeteis : MonoBehaviour {

    public float speed;
    private Controller controller;
	// Use this for initialization

    void Awake()
    {
        controller = GameObject.Find("Controller").GetComponent<Controller>();
    }

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(!controller.gameOver)
            transform.Translate(Vector3.left * speed * Time.deltaTime);
	}

    void OnBecameInvisible()
    {
        DestroyObject(this.gameObject);
    }
}
