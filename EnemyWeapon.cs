using UnityEngine;
using System.Collections;

public class EnemyWeapon : MonoBehaviour {

	//Definicion publica para el daño del arma
	public float enemydamage = 25.0f;
	//Asignacion del daño
	public float getenemyDamage(){
		return enemydamage;
	}
	//Metodo para que cuando impacte el proyectil, se destruya
	public void Hit(){
		Destroy(gameObject);
	}
	
}