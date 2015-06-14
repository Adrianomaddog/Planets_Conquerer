using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class metrica : MonoBehaviour {
	public IList<string> jogadores = new List<string>();
	public GameObject r;
	public int n_jog =0;
	bool t_test= true;
	public GameObject[] toggles_list;
	public jog jog_mortes;

	// Use this for initialization
	void Start () {
		toggles_list = GameObject.FindGameObjectsWithTag("check");



	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void organiza(){
		for(int i=0; i < r.GetComponent<reader>().db_log2.Count; i++){
			if(!jogadores.Contains(r.GetComponent<reader>().db_log2[i].jogador) ){
				jogadores.Add(r.GetComponent<reader>().db_log2[i].jogador);
				n_jog ++;
			}

		}
		for(int i=0; i < r.GetComponent<reader>().db_log1.Count; i++){
			if(!jogadores.Contains(r.GetComponent<reader>().db_log1[i].jogador) ){
				jogadores.Add(r.GetComponent<reader>().db_log1[i].jogador);
				n_jog ++;
			}
			
		}
	}


	public void desenha(){
		for(int i=0; i< toggles_list.Length; i++){
			if(toggles_list[i].GetComponentInChildren<Text>().text != "null"){

				if(toggles_list[i].GetComponent<Toggle>().isOn == true){

				}
			}
		}




		Debug.Log(jogadores[0] + " ");
		Debug.Log(jogadores[1] + " ");
		Debug.Log(n_jog);
	}

	public void listar_jogs(){
		for(int i=0; i< jogadores.Count; i++){
			toggles_list[i].GetComponentInChildren<Text>().text = jogadores[i];
			toggles_list[i].name = jogadores[i];

		}
	}

	public void mortes(){

		for(int i=0; i < r.GetComponent<reader>().db_log1.Count; i++){
			if(r.GetComponent<reader>().db_log1[i].jogador == jogadores[i]){
				if(r.GetComponent<reader>().db_log1[i].inimigo == "Jogador"){
					jog_mortes.nome = jogadores[i];
					jog_mortes.mortes++;
				}

			}
		}

	}

}
