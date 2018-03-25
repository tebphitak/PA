using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerAttack : MonoBehaviour {
	
	public int attackDamage = 10;
	public Animator animator;
	public GameObject enemy;
	public EnemyHealth enemyHealth;

    bool enemyInRange;
	float timer;

	//void Start () {

 //   }
    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == enemy)
        {
            enemyInRange = true;
            Debug.Log("ATTACK!!!");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == enemy)
        {
            enemyInRange = false;
        }
    }

    void Update () {
        //enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemy = FindClosestEnemy();
        if(enemy != null)
        {
            enemyHealth = enemy.GetComponent<EnemyHealth>();
        }
        //Debug.Log(FindClosestEnemy());

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("IsAttack1");
            if (enemyInRange == true)
            {
                Attack();
            }
        }
        //if (Input.GetMouseButtonDown(1))
        //{
        //    animator.SetTrigger("IsAttack2");
        //    if (enemyInRange == true)
        //    {
        //        Attack();
        //    }
        //}
    }
    
    void Attack(){
		if (enemyHealth.currentHealth > 0) {
			enemyHealth.TakeDamage (attackDamage);
		}
	}

}
