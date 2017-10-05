using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

	


public class GameScript : MonoBehaviour {

	// Use this for initialization
	public GameObject cross, nought; 
	public GameObject bgblock;
	public enum Seed { EMPTY, CROSS, NOUGHT};
	public Seed turn;
	public Text Instucture;	
	public Seed[] Cells;
	public int turns;
	public int rd;
	public bool hasWin;
	Vector3 tempcale;
	GameObject block;


	void Awake()
	{
		tempcale = transform.localScale;
		tempcale.x += -0.5f;
		tempcale.y += -0.5f;
		Debug.Log (tempcale);


		block = Instantiate (bgblock);
		block.transform.position = this.transform.position;
		block.transform.localScale = tempcale;
		//Debug.Log (block.transform.lossyScale);


		hasWin = false;
		Cells = new Seed[9];
		for(int i=0; i<Cells.Length; i++){
			Cells[i]=Seed.EMPTY;
		}
		turns = 1;
		rd = Random.Range (0,4	);
		if(rd >1){
			turn = Seed.CROSS;
		}else {
			turn = Seed.NOUGHT;
		}
		Instucture.text = "Turn: " + turn.ToString ();	
	
	}


	public void SpawnNew(GameObject obj,int idx)
	{
		if (hasWin == false) {
			if (turn == Seed.CROSS) {
				Instantiate (cross, obj.transform.position, Quaternion.identity); //clone Gameobject cross to obj.tranform.position
				turn = Seed.NOUGHT;	
				Cells [idx - 1] = Seed.CROSS;
				Destroy (obj.gameObject);
				//obj.gameObject.SetActive (false);
				Instucture.text = "Turn: " + turn.ToString ();
					
			} else {
				Instantiate (nought, obj.transform.position, Quaternion.identity);
				turn = Seed.CROSS;	
				Cells [idx - 1] = Seed.NOUGHT;
				//obj.gameObject.SetActive (false);
				Destroy (obj.gameObject);
				Instucture.text = "Turn: " + turn.ToString ();
			}	
			turns++;
			checkNew ();	
		}			
	}

	void Update(){


		if (Input.GetMouseButton (0)) {
			tempcale.x += 0.01f;
			tempcale.y += 0.01f;
			block.transform.localScale = tempcale;
		} else if (Input.GetMouseButton (1)) {
			tempcale.x += -0.01f;
			tempcale.y += -0.01f;
			block.transform.localScale = tempcale;
		}
	}

	void checkNew (){
		
	}

	/*void check(){
		//Cross
		if (turns > 2) {
			if (Cells [0] == Seed.CROSS && Cells [1] == Seed.CROSS && Cells [2] == Seed.CROSS) {
				Debug.Log ("Cross Win");
				Instucture.text = "Cross Win";
				hasWin = true;
			} else if (Cells [0] == Seed.CROSS && Cells [4] == Seed.CROSS && Cells [8] == Seed.CROSS) {
				Debug.Log ("Cross Win");
				Instucture.text = "Cross Win";
				hasWin = true;
			} else if (Cells [0] == Seed.CROSS && Cells [3] == Seed.CROSS && Cells [6] == Seed.CROSS) {
				Debug.Log ("Cross Win");
				Instucture.text = "Cross Win";
				hasWin = true;
			} else if (Cells [3] == Seed.CROSS && Cells [4] == Seed.CROSS && Cells [5] == Seed.CROSS) {
				Debug.Log ("Cross Win");
				Instucture.text = "Cross Win";
				hasWin = true;
			} else if (Cells [6] == Seed.CROSS && Cells [7] == Seed.CROSS && Cells [8] == Seed.CROSS) {
				Debug.Log ("Cross Win");
				Instucture.text = "Cross Win";
				hasWin = true;
			} else if (Cells [6] == Seed.CROSS && Cells [4] == Seed.CROSS && Cells [2] == Seed.CROSS) {
				Debug.Log ("Cross Win");
				Instucture.text = "Cross Win";
				hasWin = true;
			} else if (Cells [1] == Seed.CROSS && Cells [4] == Seed.CROSS && Cells [7] == Seed.CROSS) {
				Debug.Log ("Cross Win");
				Instucture.text = "Cross Win";
				hasWin = true;
			} else if (Cells [2] == Seed.CROSS && Cells [5] == Seed.CROSS && Cells [8] == Seed.CROSS) {
				Debug.Log ("Cross Win");
				Instucture.text = "Cross Win";
				hasWin = true;
			}

			//Nought
			if (Cells [0] == Seed.NOUGHT && Cells [1] == Seed.NOUGHT && Cells [2] == Seed.NOUGHT) {
				Debug.Log ("Nought Win");
				Instucture.text = "Nought Win";
				hasWin = true;
			} else if (Cells [0] == Seed.NOUGHT && Cells [4] == Seed.NOUGHT && Cells [8] == Seed.NOUGHT) {
				Debug.Log ("Nought Win");
				Instucture.text = "Nought Win";
				hasWin = true;
			} else if (Cells [0] == Seed.NOUGHT && Cells [3] == Seed.NOUGHT && Cells [6] == Seed.NOUGHT) {
				Debug.Log ("Nought Win");	
				Instucture.text = "Nought Win";
				hasWin = true;
			} else if (Cells [3] == Seed.NOUGHT && Cells [4] == Seed.NOUGHT && Cells [5] == Seed.NOUGHT) {
				Debug.Log ("Nought Win");
				Instucture.text = "Nought Win";
				hasWin = true;
			} else if (Cells [6] == Seed.NOUGHT && Cells [7] == Seed.NOUGHT && Cells [8] == Seed.NOUGHT) {
				Debug.Log ("Nought Win");
				Instucture.text = "Nought Win";
				hasWin = true;
			} else if (Cells [6] == Seed.NOUGHT && Cells [4] == Seed.NOUGHT && Cells [2] == Seed.NOUGHT) {
				Debug.Log ("Nought Win");
				Instucture.text = "Nought Win";
				hasWin = true;
			} else if (Cells [1] == Seed.NOUGHT && Cells [4] == Seed.NOUGHT && Cells [7] == Seed.NOUGHT) {
				Debug.Log ("Nought Win");
				Instucture.text = "Nought Win";
				hasWin = true;
			} else if (Cells [2] == Seed.NOUGHT && Cells [5] == Seed.NOUGHT && Cells [8] == Seed.NOUGHT) {
				Debug.Log ("Nought Win");
				Instucture.text = "Nought Win";
				hasWin = true;
			}
		} 

		//draw
		if (turns>9 && (!hasWin)) {
			Instucture.text = "Draw";
		}
		
	}*/
}
