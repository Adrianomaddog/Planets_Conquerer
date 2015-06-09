using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gerente : MonoBehaviour {
	public string nome_jogador;
	public bool salvo = false;
	public int svida;
	public int sdano;
	public int sexp;
	public Vector3 jpos;
	//public string nome_jog;
	public GameObject nj;

	public int experiencia = 0;

	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 60;
		DontDestroyOnLoad(gameObject);
		//GameObject.Find("nomeJogador");
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("exp: " + experiencia);
	
	}
	public void b_jogar(){
		Application.LoadLevel("cena_teste");
	}



}
