using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class reader : MonoBehaviour {
	int i= 0;
	public IList <base_db> db_log2 = new List<base_db>();
	public IList <base_db> db_log1 = new List<base_db>();
	//public IDictionary<string, string> db_log2_B = new Dictionary<string, string>();
	public string[] linha ;//= new string(linha);
	//char sep = '_';


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ler(){
		using (System.IO.StreamReader file2 = new System.IO.StreamReader(Application.dataPath + "/log2.txt"))
		{
			while(!file2.EndOfStream ){
				linha = file2.ReadLine().Split('*');
				base_db temp = new base_db();

				temp.jogador = linha[0];
				temp.inimigo = linha[1];
				temp.pos = linha[2];
				temp.vida_tempo = linha[3];
				temp.ck = true;

				db_log2.Add(temp);

				/*db_log2[i].inimigo = linha[1];
				db_log2[i].pos = linha[2];
				db_log2[i].vida = linha[3];
				i++;*/
			}

		}
		using (System.IO.StreamReader file = new System.IO.StreamReader(Application.dataPath + "/log.txt"))
		{
			while(!file.EndOfStream ){
				linha = file.ReadLine().Split('*');
				base_db temp = new base_db();
				
				temp.jogador = linha[0];
				temp.inimigo = linha[1];
				temp.pos = linha[2];
				temp.vida_tempo = linha[3];
				temp.ck = true;
				
				db_log1.Add(temp);
				
				/*db_log2[i].inimigo = linha[1];
				db_log2[i].pos = linha[2];
				db_log2[i].vida = linha[3];
				i++;*/
			}
			
		}
	}
}
