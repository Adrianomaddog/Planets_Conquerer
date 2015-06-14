using UnityEngine;
using System.Collections;

public class Jogador_tiro : MonoBehaviour {
	GameObject j;
	
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<ParticleSystem>().enableEmission = false;
		j = GameObject.Find("Jogador");

		//Physics.IgnoreLayerCollision(8,8);
		//Physics.IgnoreLayerCollision(8,9);
		//Physics.IgnoreLayerCollision(8,10);
			

		if(j.GetComponent<Jogador>().dano > 5 ){
			gameObject.GetComponent<TrailRenderer>().enabled = true;
		}
		if(j.GetComponent<Jogador>().dano > 11 ){
			gameObject.GetComponent<ParticleSystem>().enableEmission = true;
			
		}
		Destroy(gameObject,1.0f);

	}
	
	// Update is called once per frame
	void Update () {

		
	}
	void OnCollisionEnter(Collision col){

			Destroy(gameObject);


			

		
	}
	void OnTriggerEnter(Collider col){
		Destroy(gameObject);
	}
}
