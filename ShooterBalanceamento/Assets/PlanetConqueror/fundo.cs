using UnityEngine;
using System.Collections;

public class fundo : MonoBehaviour {

	Vector3 rolagem;

	// Use this for initialization
	void Start () {
		rolagem.x = 0f;
		rolagem.y = 0f;
		rolagem.z = -0.03f;
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Transform>().Translate(rolagem);
	
	}
}
