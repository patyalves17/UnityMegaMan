using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public float velocidade;
	public float impulso;

	public Transform chaoVerificador;
	bool estaNoChao;
	Animator anima;

	SpriteRenderer spriteRenderer;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		rb = GetComponent<Rigidbody2D> ();
		anima = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		float mover_x = Input.GetAxisRaw ("Horizontal") * velocidade * Time.deltaTime;
		transform.Translate (mover_x, 0.0f,0.0f);

		//verificar colisao com o piso
		estaNoChao = Physics2D.Linecast(transform.position, 
					chaoVerificador.position, 1 << LayerMask.NameToLayer("Piso"));


		anima.SetFloat ("pMover",Mathf.Abs(Input.GetAxisRaw("Horizontal")));
		anima.SetFloat ("pJump",0.0f);

		//Pulo
		if (Input.GetButtonDown ("Jump") && estaNoChao) {
				rb.velocity = new Vector2 (0.0f, impulso);
		} 

		if (estaNoChao) {
			anima.SetFloat ("pJump", 0.0f);
		} else {
			anima.SetFloat ("pJump", 1.0f);
		}


		//orientacao
		if(mover_x >0){
			spriteRenderer.flipX = false;
		}else if(mover_x < 0){
			spriteRenderer.flipX = true;
		}
	}
}
