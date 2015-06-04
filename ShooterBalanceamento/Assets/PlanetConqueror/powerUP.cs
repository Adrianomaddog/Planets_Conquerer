﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class powerUP : MonoBehaviour {

	GameObject jog;
	GameObject ger;
	GameObject cam;
	GameObject uvida;
	GameObject udano;
	public int custo_vida;
	public int custo_dano;
	string v;
	string d;

	// Use this for initialization
	void Start () {
		jog = GameObject.Find("Jogador");
		ger = GameObject.Find ("gerente");
		cam = GameObject.Find ("Main Camera");
		uvida = GameObject.Find("pu_vida");
		udano = GameObject.Find("pu_dano");
	
	}
	
	// Update is called once per frame
	void Update () {
		v = jog.GetComponent<Jogador>().vida_max.ToString();
		uvida.GetComponent<Text>().text = v;

		d = jog.GetComponent<Jogador>().dano.ToString();
		udano.GetComponent<Text>().text = d;



	
	}

	public void plusVida(){
		if(ger.GetComponent<gerente>().experiencia >= custo_vida){
			jog.GetComponent<Jogador>().vida_max += 10;
			ger.GetComponent<gerente>().experiencia -= custo_vida;

		}

	}

	public void plusDano(){
		if(ger.GetComponent<gerente>().experiencia >= custo_dano){
			jog.GetComponent<Jogador>().dano += 5;
			ger.GetComponent<gerente>().experiencia -= custo_dano;
			
		}

	}

	public void o_k(){
		 GameObject t = GameObject.Find ("Canvas_transicao(Clone)");
		Destroy(t);
		cam.GetComponent<camera_apecto>().rolagem.y = 0.03f;
		Time.timeScale = 1.0f;


	}
}
