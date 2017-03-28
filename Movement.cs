using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Movement : MonoBehaviour {

	//variables publicas para modificar velocidad e inercia (drag)
	public GameObject maxPlayer;
	public float speed;
	public float drag1;
	public float drag2;
	public float vel;

	//variables privadas y publicas para modificar: margenes de movimiento x,y; margenes de posicion x,y;
	private float xmax = 5;
	private float xmin = -5;
	private float ytop = 1;
	private float ydown = -1;
	public float padding = 1;
	public float vpadding = 0.5f;

	//variables para asignar: balas, casquillos y velocidad de ambos
	public GameObject bullet;
	public GameObject shell;
	public float bulletSpeed;
	public float force;
	public float bulletRepeatRate;

	//variables vida del jugador

	//public float player_health;

	//variables para el audio

	public AudioClip shootSound;
	public AudioClip playerEngine;

	// Use this for initialization
	void Start () {

		// prevenir valores 0
		if (speed == 0)
			speed = 4.0f;
		if (drag1 == 0)
			drag1 = 0.1f;
		if (drag2 == 0)
			drag2 = 1;
		if (vel == 0)
			vel = 0.01f;

		//AudioSource.PlayClipAtPoint (playerEngine, transform.position);

	}
	//metodo para la generacion de las balas y los casquillos
	void Fire(){
		Vector3 startPosition = transform.position + new Vector3 (4, 0, 0);
		Vector3 shellPosition = transform.position + new Vector3 (0, 0, -1);
		GameObject shoot = Instantiate (bullet, startPosition, Quaternion.identity) as GameObject;
		shoot.GetComponent<Rigidbody>().velocity = new Vector3(bulletSpeed, 0,0);
		shoot.GetComponent<Rigidbody>().AddForce(transform.right * bulletSpeed * 500);
		GameObject drop = Instantiate (shell,shellPosition, Quaternion.identity) as GameObject;
		drop.GetComponent<Rigidbody>().velocity = new Vector3(0,-bulletSpeed,-10) * Time.deltaTime;
		AudioSource.PlayClipAtPoint (shootSound, transform.position);
		
	}

	//Metodo para recibir daño

	void OnTriggerEnter(Collider collider){

		EnemyWeapon EnemyBullet = collider.gameObject.GetComponent<EnemyWeapon> ();
		PlayerHealth playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

		if (EnemyBullet) {
			playerScript.currentHealth -= EnemyBullet.getenemyDamage ();
			print ("daño: " +EnemyBullet.enemydamage);
			EnemyBullet.Hit ();
			//playerScript.currentHealth -= EnemyBullet.getenemyDamage();
			//si la vida es igual o menor a cero, se destruye el objeto enemigo
			if (playerScript.currentHealth <= 0) {
			
				Destroy (gameObject);
			}
			Debug.Log ("hit");
		}
		
	}

	// Update is called once per frame
	void Update() {

	//metodo para designar el movimiento dentro de los margenes de la camara
		Camera camera = Camera.main;
		float distance = transform.position.z - camera.transform.position.z;
		xmin = camera.ViewportToWorldPoint (new Vector3 (0,0,distance)).x + padding;
		xmax = camera.ViewportToWorldPoint (new Vector3 (1,1,distance)).x - padding;
		ytop = camera.ViewportToWorldPoint (new Vector3 (0,0,distance)).y + vpadding;
		ydown = camera.ViewportToWorldPoint (new Vector3 (1,1,distance)).y - vpadding;
		
		//transform.Translate(Vector3.right*vel);//?

		// repetir disparo constante
		if (Input.GetKeyDown (KeyCode.Space)) {
			InvokeRepeating("Fire", 0.0001f, bulletRepeatRate);
				
		} 
		// cancelar repeticion de disparo
		if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke("Fire");
				}
		//movimiento del jugador añadiendo fuerzas, inercias y el bloqueo dentro de los margenes
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position = new Vector3 (
						Mathf.Clamp (transform.position.x + speed * Time.deltaTime, xmin, xmax),
			            transform.position.y,
			            transform.position.z);
			GetComponent<Rigidbody>().AddForce (Vector3.right * Time.deltaTime * drag1);
						
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			this.transform.position = new Vector3 (
						Mathf.Clamp (transform.position.x - speed * Time.deltaTime, xmin, xmax),
						transform.position.y,
						transform.position.z);
			GetComponent<Rigidbody>().AddForce (Vector3.left * Time.deltaTime * drag1);
		} 
		if (Input.GetKeyDown (KeyCode.UpArrow)){
			iTween.RotateTo(gameObject, iTween.Hash("x", 0, "y", 0, "z", 20, "time", 0.2, "looptype", iTween.LoopType.none, "easetype", iTween.EaseType.easeInOutSine));
		}
		if (Input.GetKeyUp (KeyCode.UpArrow)){
			iTween.RotateTo(gameObject, iTween.Hash("x", 0, "y", 0, "z", 0, "time", 0.2, "looptype", iTween.LoopType.none, "easetype", iTween.EaseType.easeInOutSine));
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)){
			iTween.RotateTo(gameObject, iTween.Hash("x", 0, "y", 0, "z", -20, "time", 0.2, "looptype", iTween.LoopType.none, "easetype", iTween.EaseType.easeInOutSine));
		}
		if (Input.GetKeyUp (KeyCode.DownArrow)){
			iTween.RotateTo(gameObject, iTween.Hash("x", 0, "y", 0, "z", 0, "time", 0.2, "looptype", iTween.LoopType.none, "easetype", iTween.EaseType.easeInOutSine));
			}
		if (Input.GetKeyDown (KeyCode.LeftArrow)){
			iTween.RotateTo(gameObject, iTween.Hash("x", 30, "y", 0, "z", 0, "time", 0.5, "looptype", iTween.LoopType.none, "easetype", iTween.EaseType.easeInOutSine));
		}
		if (Input.GetKeyUp (KeyCode.LeftArrow)){
			iTween.RotateTo(gameObject, iTween.Hash("x", 0, "y", 0, "z", 0, "time", 0.5, "looptype", iTween.LoopType.none, "easetype", iTween.EaseType.easeInOutSine));
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)){
			iTween.RotateTo(gameObject, iTween.Hash("x", -30, "y", 0, "z", 0, "time", 0.5, "looptype", iTween.LoopType.none, "easetype", iTween.EaseType.easeInOutSine));
		}
		if (Input.GetKeyUp (KeyCode.RightArrow)){
			iTween.RotateTo(gameObject, iTween.Hash("x", 0, "y", 0, "z", 0, "time", 0.5, "looptype", iTween.LoopType.none, "easetype", iTween.EaseType.easeInOutSine));
		}
		if (Input.GetKey (KeyCode.UpArrow)) {

			transform.position = new Vector3 (
						transform.position.x,
						Mathf.Clamp (transform.position.y + speed * Time.deltaTime, ytop, ydown),
						transform.position.z);
			GetComponent<Rigidbody>().AddForce (Vector3.up * Time.deltaTime * drag1);
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			transform.position = new Vector3 (
						transform.position.x,
						Mathf.Clamp (transform.position.y - speed * Time.deltaTime, ytop, ydown),
						transform.position.z);
			GetComponent<Rigidbody>().AddForce (Vector3.down * Time.deltaTime * drag1);
		}
					
		
	}
	
}

