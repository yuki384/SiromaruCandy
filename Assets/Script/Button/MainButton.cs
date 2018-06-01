using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainButton : MonoBehaviour {
	public static int StageType;
	public static int Level;
	public static int Sweets;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	public void LS(){
		StageType = int.Parse(transform.name);
		SceneManager.LoadScene("LevelSelect");
	}
	public void GmStart(){//LSJPS.GameStartButton
		SceneManager.LoadScene("Game");
	}
	public void BacktoLS(){//GameOver.Back to LevelSelect Button
		SceneManager.LoadScene("LevelSelect");
	}
	public void L(){//Level
		Level = int.Parse(transform.name);
		SceneManager.LoadScene("Game");
	}
	public void Tut(){//Tutorial
		Level = 6;
		StageType = 0;
		SceneManager.LoadScene("Game");
	}
	public void Collect(){
		SceneManager.LoadScene("Collect");
	}
	public void detail(){
		var img = GameObject.Find(transform.name+"/Image").GetComponent<Image>();
		if(img.sprite.name!="none"){
			Sweets = int.Parse(transform.name);
			SceneManager.LoadScene("Clctdetail");
		}
	}
	public void main(){
		SceneManager.LoadScene("Main");
	}
	public static int getSw(){
		return Sweets;
	}
	public static int getL(){
		return Level;
	}
	public static int getS(){
		return StageType;
	}
}
