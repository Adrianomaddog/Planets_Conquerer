using UnityEngine;
using System.Collections;

public class gerente : MonoBehaviour {
	public string nome_jogador;
	public bool salvo = false;
	public int svida;
	public int sdano;
	public int sexp;
	public Vector3 jpos;

	public int experiencia = 0;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("exp: " + experiencia);
	
	}
	public void b_jogar(){
		Application.LoadLevel("cena_teste");
	}
}
