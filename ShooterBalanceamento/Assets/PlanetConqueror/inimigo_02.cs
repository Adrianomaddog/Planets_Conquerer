using UnityEngine;
using System.Collections;
using UnityEngine.Cloud.Analytics;
using System.Collections.Generic;
//using GameAnalyticsSDK;
//using 

public class inimigo_02 : MonoBehaviour {
	public Transform alvo;
	public float Ini_02_cadencia_tiro;
	public float Ini_02_vel_tiro;
	float Inimigo_02_proximo_tiro = 0.0f;
	public int vida; 
	GameObject gere;
	GameObject jog;
	public int xp;

	bool liga = false;

	// Use this for initialization
	void Start () {

		alvo = GameObject.Find("Jogador").GetComponent<Transform>();
		gere = GameObject.Find("gerente");
		jog = GameObject.Find("Jogador");

	
	}
	
	// Update is called once per frame
	void Update () {
		Physics.IgnoreLayerCollision(9,9);
		if(liga == true){//gameObject.GetComponent<Transform>().Translate( new Vector3 (0.0f,0.0f,-0.03f));
		//gameObject.GetComponent<Rigidbody>().rotation.SetLookRotation(alvo.position);
			Inimigo_02_atira();

			if(vida <= 0){
				gere.GetComponent<gerente>().experiencia += xp;
				Destroy(gameObject);

			}
		
			/*screenPosition = Camera.main.WorldToScreenPoint(transform.position);
			if (screenPosition.y > Screen.height || screenPosition.y < 0 || screenPosition.x > Screen.width || screenPosition.x < 0)
			{
				Destroy(gameObject);
				Debug.Log("Destroy");
			}*/

		}
	}
	void Inimigo_02_atira(){
		if(Time.time > Inimigo_02_proximo_tiro){
			Inimigo_02_proximo_tiro = Time.time + Ini_02_cadencia_tiro;

			GameObject Inimigo_02_tiro = Instantiate(Resources.Load("inimigo_02_tiro"),transform.position,Quaternion.identity) as GameObject;
			Physics.IgnoreCollision(gameObject.GetComponent<Rigidbody>().GetComponent<Collider>() , Inimigo_02_tiro.GetComponent<Rigidbody>().GetComponent<Collider>());

			//Ini_02_vel_tiro += gameObject.GetComponent<Rigidbody>().velocity.z;

			Vector3 direcao = alvo.position - transform.position; 


			Inimigo_02_tiro.GetComponent<Rigidbody>().velocity += direcao.normalized * Ini_02_vel_tiro;

			//if(gameObject.GetComponent<Rigidbody>().velocity.z < 0){
				//Ini_02_vel_tiro = Jogador_velocidade_tiro;
			//}
			//else{
				
			//}
			
			//Inimig0_02_tiro.GetComponent<Rigidbody>().velocity += new Vector3(0.0f,0.0f,1.0f) * Ini_02_vel_tiro;
			
		}
	}
	void OnCollisionEnter(Collision col){
		if(col.gameObject.name == "Jogador_tiro(Clone)"){
			//using (System.IO.StreamWriter file = new System.IO.StreamWriter(Application.dataPath + "/log.txt", true))
			//{
				//file.WriteLine(gameObject.name + " " + gameObject.transform.position + " " + Time.realtimeSinceStartup );
			//}
			//gam
			UnityAnalytics.CustomEvent("Morte_inimigo_02", new Dictionary<string, object>
			                           {
				{ "tipo_inimigo", "torre" },
				//{ "posicao", gameObject.transform.position },
				{ "tempo", Time.realtimeSinceStartup },
				//{ "vida" , vida}
			});
			vida -= jog.GetComponent<Jogador>().dano;


			//Destroy(gameObject);

		}
		
	}
	void OnTriggerEnter(Collider col){
		if(col.gameObject.name == "frente"){
			liga = true;
		}
		if(col.gameObject.name == "traz"){
			Destroy (gameObject);
		}
	}
}
