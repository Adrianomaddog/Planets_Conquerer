using UnityEngine;
using System.Collections;

public class tiro : MonoBehaviour {

	 
	// Use this for initialization
	void Start () {
		Destroy(gameObject,4.5f);	
	}
	
	// Update is called once per frame
	void Update () {
		Physics.IgnoreLayerCollision(8,8);
		Physics.IgnoreLayerCollision(8,9);
		Physics.IgnoreLayerCollision(8,10);
	
	}
	void OnCollisionEnter(Collision col){

			Destroy(gameObject);

		
	}
}


