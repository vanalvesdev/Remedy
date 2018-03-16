using UnityEngine;
using System.Collections;

public class MoveOffset : MonoBehaviour {
    public float movement;
    public Material material;
    private Controller controller;
    // Use this for initialization

    void Awake()
    {
        controller = GameObject.Find("Controller").GetComponent<Controller>();
    }
    // Use this for initialization
    void Start () {
        material = GetComponent<MeshRenderer>().material;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(!controller.gameOver)
            material.mainTextureOffset = new Vector2(material.mainTextureOffset.x + movement * Time.deltaTime, 0);
	}
}
