using UnityEngine;
using System.Collections;
//using UnityEngine.Cloud.Analytics;
using System.Collections.Generic;

public class inimigo_01 : MonoBehaviour {

	public GameObject goal;
	public GameObject final;
	public GameObject gerente;
	public int vida;
	public int xp;
    float count;
    float ncount= 0.25f;


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
		gerente = GameObject.Find("gerente");
		//Physics.IgnoreLayerCollision(9,9);
	
	}
	
	// Update is called once per frame
	void Update () {



			if(liga == true){
				gameObject.GetComponent<NavMeshAgent>().enabled = true;
				if(agent.remainingDistance < 0.5f){
					agent.destination = final.GetComponent<Transform>().position;
				}

				//goal = GameObject.Find("Jogador");

                if (Time.time > count)
                {
                    count = Time.time + ncount;


                    salvar s = new salvar();
                    s.vida = vida;
                    s.pos = gameObject.GetComponent<Transform>().position;
                    s.nome = gameObject.name;
                    gerente.GetComponent<gerente>().log2.Add(s);
                    //Debug.Log(gerente.GetComponent<gerente>().log2[0].vida);
                }
				agent.destination = goal.GetComponent<Transform>().position;
				if(vida <= 0){
				using (System.IO.StreamWriter file = new System.IO.StreamWriter(Application.dataPath + "/log.txt", true))
				{
					file.WriteLine(gerente.GetComponent<gerente>().nome_jogador + "*" + gameObject.name + "*" + gameObject.transform.position + "*" + Time.realtimeSinceStartup );
				}
				//if(gameObject.GetComponent<AudioSource>().isPlaying == false){
					gameObject.GetComponent<AudioSource>().Play();
				//}
					gerente.GetComponent<gerente>().experiencia += xp;
					Destroy(gameObject);
				}


				//liga = false;
			}


		
	}
	
	void OnCollisionEnter(Collision col){
		if(col.gameObject.name == "Jogador_tiro(Clone)"){
			//using (System.IO.StreamWriter file = new System.IO.StreamWriter(Application.persistentDataPath + "/log.txt", true))
			//{
			//	file.WriteLine(gameObject.name + " " + gameObject.transform.position + " " + Time.realtimeSinceStartup );
			//}
			//UnityAnalytics.CustomEvent("Morte_inimigo_1", new Dictionary<string, object>
			                           //{
				//{ "tipo_inimigo", "kamikaze" },
				//{ "posicao", gameObject.transform.position },
				//{ "tempo", Time.realtimeSinceStartup },
				//{ "vida" , vida}
			//});
			vida -= goal.GetComponent<Jogador>().dano;
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
