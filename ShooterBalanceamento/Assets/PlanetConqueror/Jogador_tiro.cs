using UnityEngine;
using System.Collections;

public class Jogador_tiro : MonoBehaviour {
	
	
	// Use this for initialization
	void Start () {
		//Physics.IgnoreLayerCollision(8,8);
		//Physics.IgnoreLayerCollision(8,9);
		//Physics.IgnoreLayerCollision(8,10);
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
