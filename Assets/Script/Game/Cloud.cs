using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {
	// Use this for initialization
	void Start () {
		this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (-3, 0, 0);
			if (transform.position.x < -410 ) {
				int yp =  UnityEngine.Random.Range (200, 300);//y座標をランダムに決める　y position
				int n = UnityEngine.Random.Range(1, 4);//反転
				float s = UnityEngine.Random.Range(0.5f, 1);//大きさ　Scale
				this.transform.localScale = new Vector3(s, s, s);
				if (n == 1){
					transform.localScale = new Vector3 ( transform.localScale.x  * -1, transform.localScale.y, transform.localScale.z);
				}
				transform.position = new Vector2 (410, yp);
			}
	}
}
