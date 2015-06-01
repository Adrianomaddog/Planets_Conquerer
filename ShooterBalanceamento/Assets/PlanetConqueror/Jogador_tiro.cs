using UnityEngine;
using System.Collections;

public class Jogador_tiro : MonoBehaviour {
	
	
	// Use this for initialization
	void Start () {
		Destroy(gameObject,2.0f);	
	}
	
	// Update is called once per frame
	void Update () {
		Physics.IgnoreLayerCollision(8,8);
		//Physics.IgnoreLayerCollision(8,9);
		Physics.IgnoreLayerCollision(8,10);
		
	}
	void OnCollisionEnter(Collision col){
		//if(col.gameObject.GetComponent<Rigidbody>().isKinematic == false){
			Destroy(gameObject);
		//}
		//if(col.gameObject.GetComponent<Rigidbody>().isKinematic == true){
		//	Physics.IgnoreCollision(gameObject.GetComponent<Rigidbody>().GetComponent<Collider>() , col.gameObject.GetComponent<Rigidbody>().GetComponent<Collider>());
		//}

			

		
	}
}
