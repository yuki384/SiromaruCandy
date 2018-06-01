using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.UI;

public class CreateGround : MonoBehaviour {
	public GameObject[] Gr;
	public GameObject[] BG;
	public GameObject Toge;
	GameObject obj;
	public TextAsset StageData;
	public TextAsset TogeData;
	string StrData;
	string[] StgData;
	string StrDatat;
	string[] StgDatat;
	public Sprite[] togeimg;

	void Start () {
		StageData = Resources.Load ("stagedata") as TextAsset;
		TogeData = Resources.Load ("togedata") as TextAsset;
		CreateGr();
		CreateBG();
		CreateToge();
	}
	void StringSplit(){

	}
	// Update is called once per frame
	void Update () {

	}
	void CreateGr(){
		int S = MainButton.getS ();
		int L = MainButton.getL();
		int Stage = 3*(S-1)+1+L;
		if(Stage == -5){
			Stage = 1;
		}
		StrData = StageData.text;
		StgData = StrData.Split(char.Parse("\n"));
		int len = StgData[Stage-1].Length;//lenをステージデータのStage-1行目の長さにする
		for(int i = 0; i < len-1; i++){//len回繰り返す
			//string c= StgData[Stage-1];//cをステージ-1行目のn番目の文字にする
			int Ch = int.Parse(StgData[Stage-1].Substring(i,1));
			obj = Gr[Ch];
			Instantiate(obj,new Vector3((540*i)-270, -360, 0), Quaternion.identity);
		}
	}
	void CreateBG(){
		int S = MainButton.getS ();
		if(S == 0){
			Instantiate(BG[0], new Vector3(1350, 0, 0),Quaternion.identity);
			Instantiate(BG[0], new Vector3(-810, 0, 0),Quaternion.identity);
		}else{
			obj = BG[S-1];
			Instantiate(obj, new Vector3(1350, 0, 0),Quaternion.identity);
			Instantiate(obj, new Vector3(-810, 0, 0),Quaternion.identity);
		}
	}
	void CreateToge(){
		int S = MainButton.getS ();
		int L = MainButton.getL();
		int Stage = 3*(S-1)+1+L;
		StrDatat = TogeData.text;
		StgDatat = StrDatat.Split(char.Parse("\n"));
		int len = StgDatat[Stage-1].Length;//lenをステージデータのStage-1行目の長さにする
		int n = 0;
		for(int i = 0; i < len-1; i++){//len回繰り返す
			int Ch = int.Parse(StgDatat[Stage-1].Substring(i,1));
			if(Ch==1){
				n++;
				var toge = Instantiate(Toge,new Vector3((540*i)-270, -213, 0), Quaternion.identity);
				toge.name = "Toge"+n;
				SpriteRenderer img = toge.GetComponent<SpriteRenderer>();
				img.sprite = togeimg[S-1];
			}else if(Ch==2){
				n++;
				var toge = Instantiate(Toge,new Vector3((540*i)-270+40, -213, 0), Quaternion.identity);
				var toge2 =Instantiate(Toge,new Vector3((540*i)-270-40, -213, 0), Quaternion.identity);
				toge.name = "Toge"+n;
				n++;
				toge2.name ="Toge"+n;
				SpriteRenderer img = toge.GetComponent<SpriteRenderer>();
				img.sprite = togeimg[S-1];
				SpriteRenderer img2 = toge2.GetComponent<SpriteRenderer>();
				img2.sprite = togeimg[S-1];
			}
		}
	}
}
//参考https://gametukurikata.com/program/textfile,http://himitsukichilv2.hatenablog.com/entry/2014/04/09/004255,http://jeanne.wankuma.com/tips/csharp/string/split.html
