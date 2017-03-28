using UnityEngine;
using System.Collections;

public class CamMovement : MonoBehaviour {
	
	public float vel;
	
	
	// Update is called once per frame
	void Start () {
		//iTween.MoveTo(gameObject, iTween.Hash ("delay", 0,"position", new Vector3 (0.0f,3.4f,-36.5f), "time", 30, "easetype", "easeInOutExpo"));
		//iTween.MoveTo(gameObject,iTween.Hash("x", 0.0f, "y", 3.4f, "z", -36.5f, "time", 30, "easeInOutExpo", "delay", 1));
		if (vel == 0) vel = 0.01f; 
		iTween.MoveTo(gameObject, iTween.Hash ("delay", 0,"position", new Vector3 (vel,3.4f,-36.5f), "time", 5, "easetype", "easeInOutExpo"));
	}

	
	
	void Update () {
		//iTween.MoveAdd(gameObject, iTween.Hash("x", 3));
		//iTween.ShakePosition(gameObject,new Vector3(10.02f,10.02f,10.02f),500);
		
		transform.Translate(Vector3.right*vel);
		//iTween.MoveBy(gameObject, iTween.Hash ("delay", 0,"position", new Vector3 (vel,3.4f,-36.5f), "time", 5, "easetype", "easeInOutExpo"));
		
		
	}
}
