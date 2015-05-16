using UnityEngine;
using System.Collections;

public class Jogador : MonoBehaviour {

	public float velocidade_X;
	public float velocidade_Y;
	public float vida;
	public float dano;
	public float Jogador_velocidade_tiro;
	public float Jogador_cadencia_tiro;
	float Jogador_proximo_tiro = 0.0f;
	float move_X;
	float move_Y;
	GameObject Jog;

	//public float vel = 2.0f;


	// Use this for initialization
	void Start () {
		//Jog = GameObject.FindGameObjectWithTag("Player");

	
	}
	
	// Update is called once per frame
	void Update () {
		Jogador_move();
		/*if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved){
			Jogador_move();
			Jogdor_atira();
		}*/






		if(Input.GetKey(KeyCode.Space)){
			Jogdor_atira();

		}

	
	}


	void Jogador_move(){

		//move_X = Input.GetTouch(0).deltaPosition.x ;
		move_X = Input.GetAxis("Horizontal") * velocidade_X;

		//move_X = Input.GetTouch(0).deltaPosition.y ;
		//Vector2 mover = Input.GetTouch(0).deltaPosition;
		move_Y = Input.GetAxis("Vertical") * velocidade_Y;


		gameObject.GetComponent<Rigidbody>().velocity = new Vector3 (move_X, 0, move_Y) ;

		//gameObject.GetComponent<Transform>().Translate(mover.x * vel,0,mover.y * vel);
	}

	void Jogdor_atira(){
		if(Time.time > Jogador_proximo_tiro){
			Jogador_proximo_tiro = Time.time + Jogador_cadencia_tiro;
			float Jog_vel_tiro;

			GameObject Jogador_tiro = Instantiate(Resources.Load("Jogador_tiro"),transform.position,Quaternion.identity) as GameObject;
			Physics.IgnoreCollision(gameObject.GetComponent<Rigidbody>().GetComponent<Collider>() , Jogador_tiro.GetComponent<Rigidbody>().GetComponent<Collider>());

			if(gameObject.GetComponent<Rigidbody>().velocity.z < 0){
				Jog_vel_tiro = Jogador_velocidade_tiro;
			}
			else{
				Jog_vel_tiro = Jogador_velocidade_tiro + gameObject.GetComponent<Rigidbody>().velocity.z;
			}

			Jogador_tiro.GetComponent<Rigidbody>().velocity += new Vector3(0.0f,0.0f,1.0f) * Jog_vel_tiro;

		}
	}
}


