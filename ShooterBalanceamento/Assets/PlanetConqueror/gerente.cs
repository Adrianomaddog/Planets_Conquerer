using UnityEngine;
using System.Collections;

public class gerente : MonoBehaviour {

	public int experiencia = 0;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("exp: " + experiencia);
	
	}
	public void b_jogar(){
		Application.LoadLevel("cena_teste");
	}
}
