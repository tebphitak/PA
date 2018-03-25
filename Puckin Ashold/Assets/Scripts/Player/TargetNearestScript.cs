using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetNearestScript : MonoBehaviour {

    public int attackDamage = 100;
    public List<Transform> Enemies;
    public Transform SelectedTarget;
    public Animator animator;
    public EnemyHealth enemyHealth;
    void Start()
    {
        SelectedTarget = null;
        Enemies = new List<Transform>();
        AddEnemiesToList();
    }

    public void AddEnemiesToList()
    {
        GameObject[] ItemsInList = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject _Enemy in ItemsInList)
        {
            AddTarget(_Enemy.transform);
        }
    }

    public void AddTarget(Transform enemy)
    {
        Enemies.Add(enemy);
    }

    public void DistanceToTarget()
    {
        Enemies.Sort(delegate (Transform t1, Transform t2) {
            return Vector3.Distance(t1.transform.position, transform.position).CompareTo(Vector3.Distance(t2.transform.position, transform.position));
        });

    }

    public void TargetedEnemy()
    {
        if (SelectedTarget == null)
        {
            DistanceToTarget();
            SelectedTarget = Enemies[0];
            enemyHealth = SelectedTarget.GetComponent<EnemyHealth>();
        }


    }

    void Update()
    {
        TargetedEnemy();
        float dist = Vector3.Distance(SelectedTarget.transform.position, transform.position);
        //if(dist < 3 )
        //{
        //}
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("IsAttack1");
            if (dist<1)
            {
                Attack();
            }
        }

    }
    void Attack()
    {
        if (enemyHealth.currentHealth > 0)
        {
            enemyHealth.TakeDamage(attackDamage);
        }
    }
}
