using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cltdetail : MonoBehaviour {
	private Text targetText;
	GameObject Text;
	TextAsset dscs;
	string[] List;
	string txt;
	public Sprite[] imgs;
	// Use this for initialization
	void Start () {
		dsc();
		name();
		img();
	}

	// Update is called once per frame
	void Update () {

	}
	void dsc(){
		dscs = Resources.Load ("Dsc2") as TextAsset;//説明を書いておいたtxtファイル読み込み
		txt = dscs.text;//txtファイルのtextをstringに
		List = txt.Split(char.Parse("\n"));//改行できる
		Text = GameObject.Find("dsc");//説明をいれるテキストボックスを取得
		int S = MainButton.getSw();
		targetText = Text.GetComponent<Text>();//textコンポーネント取得
		targetText.text = List[S];//ListのS番目の説明を表示

	}
	void name(){
		dscs = Resources.Load ("CandyList") as TextAsset;//名前を書いておいたtxtファイル読み込み
		txt = dscs.text;//txtファイルのtextをstringに
		List = txt.Split(char.Parse("\n"));//改行できる
		Text = GameObject.Find("SweetsName");//説明をいれるテキストボックスを取得
		int S = MainButton.getSw();
		targetText = Text.GetComponent<Text>();//textコンポーネント取得
		targetText.text = List[S];//ListのS番目の説明を表示
	}
	void img(){
		Image imgplase = GameObject.Find("Image").GetComponent<Image>();
		imgplase.preserveAspect = true;//比率を変えない
		int S = MainButton.getSw();
		imgplase.sprite = imgs[S];
	}
}
