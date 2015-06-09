using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_inGame : MonoBehaviour {
	GameObject ger;

	string xp;


	// Use this for initialization
	void Start () {
		ger = GameObject.Find("gerente");

	
	}
	
	// Update is called once per frame
	void Update () {
		xp = ger.GetComponent<gerente>().experiencia.ToString();
		gameObject.GetComponentInChildren<Text>().text = "XP = "+xp;// = ger.GetComponent<gerente>().experiencia.ToString();


	
	}
}
