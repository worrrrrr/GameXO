using UnityEngine;
using System.Collections;

public class OnHit : MonoBehaviour {
    public int idx;
    
    public GameObject MainCamera;
	public GameScript Script;

    void Awake()
    {   
        Script = MainCamera.GetComponent<GameScript>();
    }

    void OnMouseDown()
    {
		Script.SpawnNew (this.gameObject,this.idx);
    }
		
}
