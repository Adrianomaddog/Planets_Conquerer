﻿using UnityEngine;
using System.Collections;

public class camera_apecto : MonoBehaviour {
	public Vector3 rolagem;


	// Use this for initialization
	void Start () {
		//if(GameObject.Find("gerente").GetComponent<gerente>().salvo == true){
		//	gameObject.transform.position.Set()
		//}


		rolagem.x = 0.0f;
		rolagem.y = 0.03f;
		rolagem.z = 0.0f;


		/*// set the desired aspect ratio (the values in this example are
		// hard-coded for 16:9, but you could make them into public
		// variables instead so you can set them at design time)
		float targetaspect = 2f / 3.5f;//16.0f / 9.0f;
		
		// determine the game window's current aspect ratio
		float windowaspect = (float)Screen.width / (float)Screen.height;
		
		// current viewport height should be scaled by this amount
		float scaleheight = windowaspect / targetaspect;
		
		// obtain camera component so we can modify its viewport
		Camera camera = GameObject.Find ("Main Camera").GetComponent<Camera>();
		
		// if scaled height is less than current height, add letterbox
		if (scaleheight < 1.0f)
		{  
			Rect rect = camera.rect;
			
			rect.width = 1.0f;
			rect.height = scaleheight;
			rect.x = 0;
			rect.y = (1.0f - scaleheight) / 2.0f;
			
			camera.rect = rect;
		}
		else // add pillarbox
		{
			float scalewidth = 1.0f / scaleheight;
			
			Rect rect = camera.rect;
			
			rect.width = scalewidth;
			rect.height = 1.0f;
			rect.x = (1.0f - scalewidth) / 2.0f;
			rect.y = 0;
			
			camera.rect = rect;
		}*/
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Transform>().Translate(rolagem);
		if(Input.GetKey(KeyCode.Escape)){
			Application.Quit();
		}

	
	}
}
