using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class nome_jogador : MonoBehaviour {
	//public InputField i;
	public GameObject g;

	// Use this for initialization
	void Start () {
		//input.onEndEdit.AddListener(SubmitName);

	
	}
	public void jogName (InputField n){

		g.GetComponent<gerente>().nome_jogador = n.text;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
