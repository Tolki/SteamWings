using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {
	//variables publicas para añadir objetos enemigos (prefabs)
	public GameObject enemyPrefab;
	public GameObject enemyPosition;

	// Use this for initialization
	void Start () {
		//instanciado de enemigos en cada posicion del child de "EnemyPosition"
		foreach (Transform child in transform) {
						GameObject enemy = Instantiate (enemyPrefab, child.transform.position, child.transform.rotation) as GameObject;
						enemy.transform.parent = child;
				}
	
	}
}
