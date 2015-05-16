using UnityEngine;
using System.Collections;

public class inimigo_02 : MonoBehaviour {
	public Transform alvo;
	public float Ini_02_cadencia_tiro;
	public float Ini_02_vel_tiro;
	float Inimigo_02_proximo_tiro = 0.0f;

	// Use this for initialization
	void Start () {

		//alvo.position = GameObject.Find("Jogador");
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Transform>().Translate( new Vector3 (0.0f,0.0f,-0.03f));
		//gameObject.GetComponent<Rigidbody>().rotation.SetLookRotation(alvo.position);
		Inimigo_02_atira();

	
	}
	void Inimigo_02_atira(){
		if(Time.time > Inimigo_02_proximo_tiro){
			Inimigo_02_proximo_tiro = Time.time + Ini_02_cadencia_tiro;

			
			GameObject Inimigo_02_tiro = Instantiate(Resources.Load("inimigo_02_tiro"),transform.position,Quaternion.identity) as GameObject;
			Physics.IgnoreCollision(gameObject.GetComponent<Rigidbody>().GetComponent<Collider>() , Inimigo_02_tiro.GetComponent<Rigidbody>().GetComponent<Collider>());

			Ini_02_vel_tiro += gameObject.GetComponent<Rigidbody>().velocity.z;

			Vector3 direcao = alvo.position - transform.position; 


			Inimigo_02_tiro.GetComponent<Rigidbody>().velocity += direcao * Ini_02_vel_tiro;

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
			Destroy(gameObject);
		}
		
	}
}
