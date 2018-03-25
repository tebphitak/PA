using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour {
	
	private NavMeshAgent nav;
	public Transform player;
	public PlayerHealth playerHealth;
	public EnemyHealth enemyHealth;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent> ();
    }

	void Update () {
		if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0) {
			nav.SetDestination (player.position);
		} else {
			nav.enabled = false;
		}
	}
}
