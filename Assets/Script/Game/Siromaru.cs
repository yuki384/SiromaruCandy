using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Siromaru : MonoBehaviour{
	GameObject m;
	Rigidbody2D rb2;
	private Animator animator;
	bool Jump=false;//In Jump
	bool onG=true;//On Ground
	bool Squat=false;
	public bool Game=true;//Game中
	private Vector3 touchStartPos;//Flick
	private Vector3 touchEndPos;//Flick
	public float flap=3000000;//jump
	double timer=0;//Timer

	// Use this for initialization
	void Start () {
	 	m = GameObject.Find ("machine");
		animator = GetComponent<Animator>();
		rb2 = GetComponent<Rigidbody2D>();
		this.transform.localScale = new Vector3(1, 1, 1);//大きさ初期化　Size initialization
		CapsuleCollider2D cc = gameObject.GetComponent(typeof(CapsuleCollider2D)) as CapsuleCollider2D;//Collider取得
		cc.size = new Vector2(80, 80);//Colliderの形初期化　Collider initialization
		animator.SetBool("Game", true);
	}

	// Update is called once per frame
	void Update () {
		if(m.transform.position.x==0){
			SceneManager.LoadScene("Clear");
			//Destroy(gameObject);
		}
		if(Game==false && transform.position.x<0){
			transform.rotation = Quaternion.Euler(0, 0, 0);
			transform.Translate(2, 0, 0);
		}
	}
	void Flick(){//フリック Flick
		if (Input.GetKeyDown(KeyCode.Mouse0)){//マウスが押される
      touchStartPos = new Vector2(Input.mousePosition.x,
                                  Input.mousePosition.y);//押されたときのマウス位置
    }
 		if (Input.GetKeyUp(KeyCode.Mouse0)){//マウスが押されていたのが離される
     touchEndPos = new Vector2(Input.mousePosition.x,
                               Input.mousePosition.y);//離れたときのマウス位置
     GetDirection();
    }
	}
	void GetDirection(){
		/*float directionX = touchEndPos.x - touchStartPos.x;*/
		float directionY = touchEndPos.y - touchStartPos.y;
		string Direction;
		if (100 < directionY){//Up Flick
			Direction = "up";
		}else if (-100 > directionY){//Down Flick
			Direction = "down";
		}else{
			Direction = "touch";
		}
		switch (Direction){
			case "up"://上フリックの処理 Processing of upper flick
				if(onG==true){//if on Ground
					Jump = true;//Jump
					onG=false;//not on Ground
				}
			break;
			case "down"://下フリックの処理 Processing of lower flick
				Squat=true;//しゃがむをtrueにする　change Squat to true
				//以下しゃがんだ時の処理
				float x = 0;
				this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, x);
				CapsuleCollider2D cc = gameObject.GetComponent(typeof(CapsuleCollider2D)) as CapsuleCollider2D;
				cc.size = new Vector2(80, 64);//Colliderの形変更 change shape of Collider
				this.transform.localScale = new Vector3(1, 0.8f, 1);//Siromaruの形変更 Change shape of Siromaru
				timer = 0;
			break;
			case "touch":
				　　　　　
			break;
		}
	}

	private void FixedUpdate(){
		timer += 0.1;//timerを0.1ずつかえる
		if (Jump){
			rb2.AddForce(Vector2.up * flap);//上方向に力を加える add force to upward
			Jump = false;//ジャンプ中をfalseにする change jump to false
		}
		if(Squat){//しゃがんでいる時の処理
			if(timer > 8){
				Squat=false;//しゃがむをfalseにする Change Squat to false
				float x = 0;
				transform.rotation = Quaternion.Euler(0.0f, 0.0f, x);//角度を戻し
				this.transform.localScale = new Vector3(1, 1, 1);//元の大きさに！
				CapsuleCollider2D cc = gameObject.GetComponent(typeof(CapsuleCollider2D)) as CapsuleCollider2D;//Collider取得
				cc.size = new Vector2(80, 80);//Colliderの形初期化　Collider initialization
			}
		}
		Flick();
		if(Squat==false && Game){
			transform.Rotate(new Vector3(0,0,-5));//回転 Rotate
		}
		if (transform.position.y < -260 ) {//GameOverの処理
			SceneManager.LoadScene("GameOver");//GameOverのシーンに切り替え switch to "GameOver"
		}
		float height = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
	}

	void OnCollisionEnter2D(Collision2D Collision){
		if (Collision.gameObject.tag == "Ground"){//Groundタグが付いているのに触れたら
			onG = true;
		}
		if (Collision.gameObject.tag == "Toge"){//Togeタグが付いているのに触れたら
			SceneManager.LoadScene("GameOver");
		}
	}
	public void Clear(){//clear
		Game =　false;
	}
}

/*Flick https://qiita.com/pilkul/items/e8864882b3f7e59b05e3*/
