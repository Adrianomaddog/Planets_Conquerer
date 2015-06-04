using UnityEngine;
using System.Collections;

public class p_final : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void sair(){
		Application.Quit();
	}
	public void novamente(){
		GameObject.Find("gerente").GetComponent<gerente>().experiencia = 0;
		Application.LoadLevel("cena_teste");
		
	}

}
