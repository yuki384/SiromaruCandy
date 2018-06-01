using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toge : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(transform.position.x > -348){
			transform.Translate (-5, 0, 0);
		}else{
			Destroy(gameObject);
		}
	}
}
