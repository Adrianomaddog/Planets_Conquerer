using UnityEngine;
using System.Collections;

public class inimigo_01 : MonoBehaviour {

	public Transform goal;
	public Transform final;
	Vector2 screenPosition;

	NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		agent.destination = goal.position; 

	
	}
	
	// Update is called once per frame
	void Update () {
		if(agent.remainingDistance < 0.5f){
			agent.destination = final.position;
		}

			screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		if (screenPosition.y > Screen.height || screenPosition.y < 0 || screenPosition.x > Screen.width || screenPosition.x < 0)
		{
			Destroy(gameObject);
			Debug.Log("Destroy");
		}

		
	}
	
	void OnCollisionEnter(Collision col){
		if(col.gameObject.name == "Jogador_tiro(Clone)"){
			Destroy(gameObject);
		}

	}
}
