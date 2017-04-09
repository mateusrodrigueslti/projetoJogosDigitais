using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour {

    public float velocidade = 1;
    public float forcaDoPulo = 1;
    public Vector3 axis;
    Rigidbody rigid;
	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(axis.x * horizontal , axis.y * vertical, velocidade));

        if (Input.GetButtonDown("Jump")) {
            rigid.AddForce(new Vector3(0,forcaDoPulo,0), ForceMode.Impulse);
        }
	}

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.name != "Plane")
        {
            this.velocidade = 0;
            Application.LoadLevel (0);

        }


    }
}
