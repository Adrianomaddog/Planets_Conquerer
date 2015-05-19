using UnityEngine;
using System.Collections;

public class inimigo_01 : MonoBehaviour {

	public GameObject goal;
	public GameObject final;

	bool liga = false;
	//Transform fim;

	NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		goal = GameObject.Find("Jogador");
		final = GameObject.Find("fim");
		agent = GetComponent<NavMeshAgent>();
		//agent.destination = goal.GetComponent<Transform>().position; 
		gameObject.GetComponent<NavMeshAgent>().enabled = false;
		//fim.position = final.GetComponent<Transform>().position;

	
	}
	
	// Update is called once per frame
	void Update () {

		Physics.IgnoreLayerCollision(9,9);

			if(liga == true){
				gameObject.GetComponent<NavMeshAgent>().enabled = true;
				if(agent.remainingDistance < 0.5f){
					agent.destination = final.GetComponent<Transform>().position;
				}

				goal = GameObject.Find("Jogador");

				agent.destination = goal.GetComponent<Transform>().position;


				//liga = false;
			}


		
	}
	
	void OnCollisionEnter(Collision col){
		if(col.gameObject.name == "Jogador_tiro(Clone)"){
			using (System.IO.StreamWriter file = new System.IO.StreamWriter(Application.persistentDataPath + "/log.txt", true))
			{
				file.WriteLine(gameObject.name + " " + gameObject.transform.position + " " + Time.realtimeSinceStartup );
			}

			Destroy(gameObject);
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
