using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyAttack : MonoBehaviour {
	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;
	public Animator animator;
	public GameObject player;

	public PlayerHealth playerHealth;
	public EnemyHealth enemyHealth;
	bool playerInRange;
	float timer;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyHealth = GetComponent<EnemyHealth>();
        playerHealth = player.GetComponent<PlayerHealth> ();
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject == player) {
			playerInRange = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject == player) {
			playerInRange = false;
		}
	}
		
	void Update () {
		timer += Time.deltaTime;
		if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0) {
			Attack ();
		}
		if (playerHealth.currentHealth <= 0) {
			animator.SetTrigger ("IsIdle");
		}
	}
		
	void Attack(){
		timer = 0f;
		if (playerHealth.currentHealth > 0) {
			playerHealth.TakeDamage (attackDamage);
		}
	}
		
}
