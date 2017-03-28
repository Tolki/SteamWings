using UnityEngine;
using System.Collections;

public class WeaponDamage2 : MonoBehaviour {
	
	//Definicion publica para el daño del arma
	public float damage = 100.0f;
	//Asignacion del daño
	public float getDamage(){
		return damage;
	}
	//Metodo para que cuando impacte el proyectil, se destruya
	public void Hit(){
		Destroy(gameObject);
	}
	
}