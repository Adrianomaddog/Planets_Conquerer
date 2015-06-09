using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_vida : MonoBehaviour {
	string vida;
	public GameObject j;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		vida = j.GetComponent<Jogador>().vida.ToString();
		gameObject.GetComponentInChildren<Text>().text = "VIDA = "+vida;
	
	}
}
