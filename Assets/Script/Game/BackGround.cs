using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackGround : MonoBehaviour {
	GameObject Machine;
	Machine script;

	// Use this for initialization
	void Start () {
		Machine=GameObject.Find ("machine");
		script = Machine.GetComponent<Machine>();
	}

	// Update is called once per frame
	void Update () {
		bool clear=script.clearM;
		if(clear){
			
		}else{
			transform.Translate (-5, 0, 0);
			if (transform.position.x < -1530 ) {
				transform.position = new Vector2 (1350, 0);
			}
		}
	}
}
