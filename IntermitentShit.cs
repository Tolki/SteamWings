using UnityEngine;
using System.Collections;

public class IntermitentShit : MonoBehaviour {
	//variables publicas para añadir objetos (prefabs) que requieran existir durante un tiempo determinado
	public GameObject shitPrefab;
	public GameObject shitPosition;
	public float time;
	public float time2;

	IEnumerator LightningMethod(){

		yield return new WaitForSeconds(time);
		foreach (Transform child in transform) {
			GameObject enemy = Instantiate (shitPrefab, child.transform.position, child.transform.rotation) as GameObject;
			enemy.transform.parent = child;
			yield return new WaitForSeconds(time2);
			Destroy (gameObject);
		}
	}
	
	// Use this for initialization
	void Start () {

	}
	void Update() {
		StartCoroutine(LightningMethod());
	}
}

