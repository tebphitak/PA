using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyHealth : MonoBehaviour {

	public int Health = 100;
	public int currentHealth;
	public float sinkSpeed = 2.5f;
	public Animator animator;

	//public ParticleSystem hitParticles;
	public CapsuleCollider capsuleCollider;
	bool IsDead;
	bool IsSinking;

	void Start () {
		currentHealth = Health;
        GetComponent<NavMeshAgent>().enabled = true;
    }
	

	void Update () {
//		Debug.Log (Health);
		if (IsSinking) {
			transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
		}
	}

	public void TakeDamage(int amount/*, Vector3 hitPoint*/){
		if (IsDead) {
			return;
		}
		currentHealth -= amount;
		//hitParticles.transform.position = hitPoint;
		//hitParticles.Play ();
		if (currentHealth <= 0) {
			Dead ();
		}
	}

	void Dead(){
		IsDead = true;
		capsuleCollider.isTrigger = true;
		animator.SetTrigger ("IsDead");
	}

	public void StartSinking(){
		GetComponent<NavMeshAgent> ().enabled = false;
		GetComponent<Rigidbody> ().isKinematic = true;
		IsSinking = true;
		Destroy (gameObject, 2f);
	}
}
