using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour
{

	//Variable de vida del enemigo
	public float health = 350;

	//variables para asignar: balas, casquillos y velocidad de ambos
	public GameObject enemybullet;
	public GameObject enemyshell;
	public float enemybulletSpeed;
	public float enemyforce;
	public float enemybulletRepeatRate;
	public float shotsPerSecond;
	public AudioClip enemyShotSound;

	//metodo de colision del collider con el proyectil y el daño del arma (añadir armas), restar vida
	void OnTriggerEnter (Collider collider)
	{
		WeaponDamage bulletsprite = collider.gameObject.GetComponent<WeaponDamage> ();
		WeaponDamage2 bulletsprite2 = collider.gameObject.GetComponent<WeaponDamage2> ();
		if (bulletsprite) {
			health -= bulletsprite.getDamage ();
			bulletsprite.Hit ();
			iTween.ShakePosition(gameObject,new Vector3(0.5f,0.5f,0),2);
			//si la vida es igual o menor a cero, se destruye el objeto enemigo
			if (health <= 0) {
				Destroy (gameObject);
			}
			Debug.Log ("hit");
		}
		if (bulletsprite2) {
			health -= bulletsprite2.getDamage ();
			bulletsprite2.Hit ();
			//si la vida es igual o menor a cero, se destruye el objeto enemigo
			if (health <= 0) {
				Destroy (gameObject);
			}
			Debug.Log ("hit2");
		}
	}

	void EnemyFire ()
	{
		Vector3 startPosition = transform.position + new Vector3 (-1, 0, 0);
		GameObject enemyshot = Instantiate (enemybullet, startPosition, Quaternion.identity) as GameObject;
		enemyshot.GetComponent<Rigidbody>().velocity = new Vector3(-enemybulletSpeed,0,0);
		AudioSource.PlayClipAtPoint (enemyShotSound, transform.position);
		//enemyshot.GetComponent<Rigidbody>().velocity = new Vector3 (-enemybulletSpeed, 0, 0);
	}

	void Update ()
	{
		float probability = Time.deltaTime * shotsPerSecond;
		if (Random.value < probability) {
			EnemyFire ();
		}
	}
}