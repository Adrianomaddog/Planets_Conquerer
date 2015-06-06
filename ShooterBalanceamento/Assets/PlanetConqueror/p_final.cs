using UnityEngine;
using System.Collections;

public class p_final : MonoBehaviour {
	GameObject g;
	GameObject c;
	// Use this for initialization
	void Start () {
		g= GameObject.Find ("gerente");
		c = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void sair(){
		Application.Quit();
	}
	public void novamente(){
		//if(g.GetComponent<gerente>().salvo == true){
			//Application.LoadLevel("cena_teste");
			//GameObject jo = GameObject.Find("Jogador");
			//jo.GetComponent<Jogador>().vida_max = g.GetComponent<gerente>().svida;
			//jo.GetComponent<Jogador>().vida = g.GetComponent<gerente>().svida;
			//jo.GetComponent<Jogador>().dano = g.GetComponent<gerente>().sdano;
			////g.GetComponent<gerente>().experiencia = g.GetComponent<gerente>().sexp;
			c.GetComponent<Transform>().position.Set(g.GetComponent<gerente>().jpos.x , g.GetComponent<gerente>().jpos.y , g.GetComponent<gerente>().jpos.z);
		//}
		//if(g.GetComponent<gerente>().salvo == false){
			GameObject.Find("gerente").GetComponent<gerente>().experiencia = 0;
			Application.LoadLevel("cena_teste");
		//}
		
	}

}
