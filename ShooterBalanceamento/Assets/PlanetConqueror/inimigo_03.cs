using UnityEngine;
using System.Collections;

public class inimigo_03 : MonoBehaviour {
	public Transform alvo;
	public float Ini_03_cadencia_tiro;
	public float Ini_03_vel_tiro;
	float Inimigo_03_proximo_tiro = 0.0f;
	public int vida;
	public int xp;
	GameObject jog;
	GameObject ger;
	GA_Design evento;
	
	bool liga = false;
	
	// Use this for initialization
	void Start () {
		//gameObject.GetComponent<MeshRenderer>().enabled = false;
		//gameObject.GetComponent<Rigidbody>().isKinematic = true;
		//gameObject.GetComponent<BoxCollider>().enabled = false;
		//gameObject.GetComponent<>().enabled = false;
		
		alvo = GameObject.Find("Jogador").GetComponent<Transform>();
		jog = GameObject.Find ("Jogador");
		ger = GameObject.Find ("gerente");
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("liga=" + liga);
		Physics.IgnoreLayerCollision(9,9);
		if(liga == true){//gameObject.GetComponent<Transform>().Translate( new Vector3 (0.0f,0.0f,-0.03f));
			//gameObject.GetComponent<Rigidbody>().rotation.SetLookRotation(alvo.position);
			Inimigo_03_atira();
			gameObject.GetComponent<Transform>().Translate(new Vector3 (0.0f, 0.0f , 0.02f));
			
			if(vida <= 0){
				using (System.IO.StreamWriter file = new System.IO.StreamWriter(Application.dataPath + "/log.txt", true))
				{
					file.WriteLine(gameObject.name + " " + gameObject.transform.position + " " + Time.realtimeSinceStartup );
				}

				ger.GetComponent<gerente>().experiencia += xp;
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
	void Inimigo_03_atira(){
		if(Time.time > Inimigo_03_proximo_tiro){
			Inimigo_03_proximo_tiro = Time.time + Ini_03_cadencia_tiro;
			
			GameObject Inimigo_03_tiro = Instantiate(Resources.Load("inimigo_02_tiro"),transform.position,Quaternion.identity) as GameObject;
			Physics.IgnoreCollision(gameObject.GetComponent<Rigidbody>().GetComponent<Collider>() , Inimigo_03_tiro.GetComponent<Rigidbody>().GetComponent<Collider>());
			
			//Ini_02_vel_tiro += gameObject.GetComponent<Rigidbody>().velocity.z;
			
			Vector3 direcao = alvo.position - transform.position; 
			
			
			Inimigo_03_tiro.GetComponent<Rigidbody>().velocity += direcao.normalized * Ini_03_vel_tiro;
			
			//if(gameObject.GetComponent<Rigidbody>().velocity.z < 0){
			//Ini_02_vel_tiro = Jogador_velocidade_tiro;
			//}
			//else{
			
			//}
			
			//Inimig0_02_tiro.GetComponent<Rigidbody>().velocity += new Vector3(0.0f,0.0f,1.0f) * Ini_02_vel_tiro;
			
		}
	}
	void OnCollisionEnter(Collision col){
		if(col.gameObject.name == "Jogador" && liga == false){
			Physics.IgnoreCollision(gameObject.GetComponent<Rigidbody>().GetComponent<Collider>() , col.gameObject.GetComponent<Rigidbody>().GetComponent<Collider>());
		}
		if(col.gameObject.name == "Jogador_tiro(Clone)"){
			if(liga == true){
				//using (System.IO.StreamWriter file = new System.IO.StreamWriter(Application.dataPath + "/log.txt", true))
				//{
				//	file.WriteLine(gameObject.name + " " + gameObject.transform.position + " " + Time.realtimeSinceStartup );
				//}
				vida -= jog.GetComponent<Jogador>().dano;
				//Destroy(gameObject);
			}
			if(liga == false){
				Physics.IgnoreCollision(gameObject.GetComponent<Rigidbody>().GetComponent<Collider>() , col.gameObject.GetComponent<Rigidbody>().GetComponent<Collider>());
			}
			
		}
		
	}
	void OnTriggerEnter(Collider col){
		if(col.gameObject.name == "frente"){
			liga = true;
			//gameObject.GetComponent<MeshRenderer>().enabled = true;
			//gameObject.GetComponent<Rigidbody>().isKinematic = false;
		}
		if(col.gameObject.name == "traz"){
			if(liga == true){
				Destroy (gameObject);
			}
		}
	}
}
