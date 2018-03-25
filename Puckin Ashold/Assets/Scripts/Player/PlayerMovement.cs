using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {
	
	public CharacterController controller;
	public Animator animator;
	public float speed = 5f;
	public Text textscore;
	public int score = 0;

	void FixedUpdate () {
		float v = Input.GetAxis ("Vertical");
		float h = Input.GetAxis ("Horizontal");

		Vector3 movement = new Vector3 (v*transform.forward.x*Time.deltaTime,0f,v*transform.forward.z*Time.deltaTime);
		controller.Move(movement*speed);
		transform.Rotate (new Vector3 (0, h * speed, 0));

		if (v == 0 && h == 0) {
			animator.SetBool ("IsRun", false);
		} else {
			animator.SetBool ("IsRun", true);
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			animator.SetTrigger ("IsJump");
		}
//		if (Input.GetKeyUp (KeyCode.E)) {
//			SceneManager.LoadScene ("state_two");
//		}
//		if (Input.GetMouseButtonDown (0)) {
//			animator.SetTrigger ("IsAttack1");
//		}
//		if (Input.GetMouseButtonDown (1)) {
//			animator.SetTrigger ("IsAttack2");
//		}

	}

//	void OnTriggerEnter(Collider other) {
//		//Debug.Log ("Colider");
//		score++;
//		textscore.text = score.ToString();
//		Destroy(other.gameObject);
//	}

}
