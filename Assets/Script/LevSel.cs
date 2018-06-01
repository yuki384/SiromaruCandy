using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.UI;

public class LevSel : MonoBehaviour {
	public string[] StNm;
	public GameObject[] bg;

	// Use this for initialization
	void Start () {
		int S = MainButton.getS ();
		Text txt = transform.GetComponent<Text>();
		txt.text = StNm[S-1];
		Instantiate(bg[S-1], new Vector2(130,480), Quaternion.identity);
	}

	// Update is called once per frame
	void Update () {

	}
}
