using UnityEngine;
using System.Collections;
//using UnityEngine.Cloud.Analytics;
using System.Collections.Generic;

public class Jogador : MonoBehaviour {

	public float velocidade_X;
	public float velocidade_Y;
	public int vida;
	public int dano;
	public int vida_max;
	//public int dano_max;
	public float Jogador_velocidade_tiro;
	public float Jogador_cadencia_tiro;
	float Jogador_proximo_tiro = 0.0f;
	float move_X;
	float move_Y;
	bool fj = false;


	GameObject cam;
	GameObject ger;
	GameObject pu;
	GameObject tela_final;


	public float vel = 0.5f;


	// Use this for initialization
	void Start () {
		cam = GameObject.Find("Main Camera");
		vida = vida_max;

		Time.timeScale = 1.0f;
		ger = GameObject.Find("gerente") as GameObject;


	
	}
	
	// Update is called once per frame
	void Update () {
		Jogador_move();
		//Jogdor_atira();
		if(vida <= 0){


			Time.timeScale = 0.0f;
			cam.GetComponent<camera_apecto>().rolagem.y = 0.00f;
			//if(Input.GetKey(KeyCode.C)){
				ger.GetComponent<gerente>().experiencia = 0;
			Fim_de_jogo();
				//Application.LoadLevel("cena_teste");

			//}
			//Destroy (gameObject);
		}
		/*if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved){
			Jogador_move();
			Jogdor_atira();
		}*/






		if(Input.GetKey(KeyCode.Space)){
			Jogdor_atira();
			if(gameObject.GetComponent<AudioSource>().isPlaying == false){
				gameObject.GetComponent<AudioSource>().Play ();
			}


		}

	
	}


	void Jogador_move(){
		/********** CONTROLES MOBILE *********/


		//Vector2 mover = Input.GetTouch(0).deltaPosition;

		//gameObject.GetComponent<Transform>().Translate(-mover.x * vel,0,-mover.y * vel);

		/******************************************/




		/*************** CONTROLE DE PC *************/
		move_X = Input.GetAxis("Horizontal") * velocidade_X;
		move_Y = Input.GetAxis("Vertical") * velocidade_Y;

		gameObject.GetComponent<Rigidbody>().velocity = new Vector3 (move_X, 0, move_Y) ;
		/*****************************************/

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

	void OnCollisionEnter(Collision col){
		if(col.gameObject.name == "inimigo_02_tiro(Clone)"){
			vida -= 10;
			//UnityAnalytics.CustomEvent("Dano_no_player", new Dictionary<string, object>
			                          // {
				//{ "tipo_inimigo", "torre" },
				////{ "posicao", gameObject.transform.position },
				//{ "tempo", Time.realtimeSinceStartup },
				//{ "vida" , vida}
			//});


		}
		if(col.gameObject.tag == "kamikaze"){
			vida -= 15;
			Destroy(col.gameObject);


		}
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.name ==  "transicao"){
			//ger.GetComponent<gerente>().sexp = ger.GetComponent<gerente>().experiencia;
			//ger.GetComponent<gerente>().svida = vida_max;
			//ger.GetComponent<gerente>().sdano = dano;
			//ger.GetComponent<gerente>().jpos = cam.GetComponent<Transform>().position;
			//ger.GetComponent<gerente>().salvo = true;
			cam.GetComponent<camera_apecto>().rolagem.y = 0.00f;
			Time.timeScale = 0.0f;
			//t_liga = true;
			pu = Instantiate(Resources.Load("Canvas_transicao")) as GameObject;
			
		}
		if(col.gameObject.name ==  "final_jog"){
			cam.GetComponent<camera_apecto>().rolagem.y = 0.00f;
			Time.timeScale = 0.0f;
			//t_liga = true;
			tela_final = Instantiate(Resources.Load("telaFinal")) as GameObject;
			
		}
		
	}


	public void Fim_de_jogo(){
		if(fj == false){
			tela_final = Instantiate(Resources.Load("telaFinal")) as GameObject;
			fj = true;
			using (System.IO.StreamWriter file = new System.IO.StreamWriter(Application.dataPath + "/log.txt", true))
			{
				file.WriteLine(ger.GetComponent<gerente>().nome_jogador + " " + gameObject.name + " " + gameObject.transform.position + " " + Time.realtimeSinceStartup );
			}
			//GUI.TextArea(new Rect (10,10,200,100),"FIM DE JOGO \nc - jogar novamente \nesc - sair");
		}

	}
	/*public void sair(){
		Application.Quit();
	}
	public void novamente(){
		GameObject.Find("gerente").GetComponent<gerente>().experiencia = 0;
		Application.LoadLevel("cena_teste");

	}*/
}


