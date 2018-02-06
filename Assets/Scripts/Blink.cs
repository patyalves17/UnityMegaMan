using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Blink : MonoBehaviour {

	//Intervalo para ligar/desligar a renderizacao
	public float intervalo;

	IEnumerator Start () {

		//obtem o camponente do objeto
		GetComponent<SpriteRenderer> ().enabled = false;
		yield return new WaitForSeconds (intervalo);
		GetComponent<SpriteRenderer> ().enabled = true;
		yield return new WaitForSeconds (intervalo);

		//faz a chamada novamente do metodo deixado em looping
		StartCoroutine(Start());
	}

	void update (){
		//pressionar enter
		if(Input.GetKeyDown(KeyCode.Return)){
			SceneManager.LoadScene ("game-scene");
		}
	}

}
