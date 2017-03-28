using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		Destroy (col.gameObject);
	}
}