using UnityEngine;
using System.Collections;

public class ItweenTry : MonoBehaviour {
	public float vel;

	// Use this for initialization
	void Start () {
		iTween.MoveTo(gameObject, iTween.Hash ("delay", 0,"position", new Vector3 (0,3.4f,-36.5f), "time", 5, "easetype", "easeInOutExpo"));

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
