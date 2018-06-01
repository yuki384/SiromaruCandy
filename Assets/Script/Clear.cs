using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class Clear : MonoBehaviour {
	private Text targetText;
	string candy;
	string[] List;
	string collect;
	int Okashi;
	TextAsset CandyList;
	TextAsset Collectlist;
	public Image Sweets;
	//public Sprite Sweets0,Sweets1,Sweets2;
	public Sprite[] Sweets2;
	void Start () {
		CandyList = Resources.Load ("CandyList") as TextAsset;
		Collectlist = Resources.Load ("CollectList") as TextAsset;
		Gacharu();
	}

	// Update is called once per frame

	void Update () {

	}
	void Gacharu(){
		//Kekka = GetComponentInChildren<Text>();
		int S = MainButton.getS ();//Stage取得
		if(S == 1){
			Okashi = Random.Range(0, 9);//0行目から8行目
		}else if(S == 2){
			Okashi = Random.Range(9, 15);//9行目から14行目
		}else if(S == 3){
			Okashi = Random.Range(15, 21);//15行目から20行目
		}
		candy = CandyList.text;
		List = candy.Split(char.Parse("\n"));
		this.targetText = this.GetComponent<Text>();//お菓子の名前表示する場所
		this.targetText.text = List[Okashi];//お菓子の名前
		/*Debug.Log(Okashi-1);
		Debug.Log(Sweets2);*/
		foreach(Sprite sp in Sweets2){
			if((Okashi).ToString() == sp.name){
				Sweets.preserveAspect = true;//比率を変えない
				Sweets.sprite = sp;
			}
		}
		collect = PlayerPrefs.GetString("CollectList","000000000000000000000");
		string bf;
		if(Okashi == 0){
			bf = "";
		}else{
			bf = collect.Substring(0,Okashi);
		}
		string af = collect.Substring(Okashi+1);
		collect = bf+1+af;
		PlayerPrefs.SetString("CollectList", collect);
		PlayerPrefs.Save();
	}
}
