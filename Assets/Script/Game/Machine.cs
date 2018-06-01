using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour {
	public bool clearM = false;
	// Use this for initialization
	void Start () {

	}
	// Update is called once per frame
	void Update () {
		if(clearM && transform.position.x > 0){
				transform.Translate (-5, 0, 0);
		}
	}
	public void Clear(){
		clearM=true;

	}
}
