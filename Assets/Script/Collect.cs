using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Collect : MonoBehaviour {
	public GameObject Sweets;
	public GameObject Sweetsbox;
	public GameObject Scroll;
	GameObject parentObj;
	public Sprite[] swtsimg;
	Canvas canvas;
	//Image clt;
	//TextAsset CollectList;
	string candy;
	// Use this for initialization
	void Start () {
		CrContent();
	}

	// Update is called once per frame
	void Update () {

	}
	void CrContent(){

		for(int i=0; i<7; i++){
			Transform parent = Scroll.transform;
			var SweBox = Instantiate(Sweetsbox, new Vector2 (-60,180-i*80), Quaternion.identity, parent);//親を作る
			SweBox.name="SweetsBox"+i;//名前を設定
			for(int i2=0; i2<3; i2++){
				parentObj = GameObject.Find("SweetsBox"+i);//親として設定
				//Debug.Log(parentObj);
				parent = parentObj.transform;
				var sweetscol = Instantiate(Sweets, new Vector2(0,0), Quaternion.identity, parent);//子どもをつくる
				int name =(i2+i*3);
				sweetscol.name = name.ToString();//名前を設定
				GameObject.Find(name.ToString()).transform.localPosition = new Vector2((i2-1)*130,parentObj.transform.position.y);
			}
		}
		candy = PlayerPrefs.GetString("CollectList","000000000000000000000");
		/*FileInfo fi = new FileInfo("Assets/Resources/CollectList.txt");
		StreamReader sr = new StreamReader(fi.OpenRead());
		//CollectList = Resources.Load ("CollectList") as TextAsset;
		candy = sr.ReadToEnd();//CollectList.text;*/
		for(int n=0;n<21;n++){//長さに応じて変えること
			if(int.Parse(candy.Substring(n,1)) == 1){
				Image clt = GameObject.Find(n+"/Image").GetComponent<Image>();
				RectTransform rt = GameObject.Find(n+"/Image").GetComponent<RectTransform>();
				clt.preserveAspect = true;//比率を変えない
				clt.sprite = swtsimg[n];
				rt.sizeDelta = new Vector2 (100, 100);
			}

		}
	}
}
