using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearGround : MonoBehaviour {
	public GameObject mObj;
	public GameObject sObj;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(transform.position.x > 0){
			transform.Translate (-5, 0, 0);
		}else{
			transform.position = new Vector2(0,-360);
			mObj = GameObject.Find("machine");
			sObj = GameObject.Find("Siromaru");
			Machine M = mObj.GetComponent<Machine>();
			M.Clear();
			Siromaru S = sObj.GetComponent<Siromaru>();
			S.Clear();
		}
	}
}
