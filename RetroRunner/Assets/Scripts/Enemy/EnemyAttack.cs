using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private BoxCollider attackBox;
    [SerializeField] private float atkPower;
    
    private void OnTriggerEnter(Collider other)
    {
        if(health.isDead) return;
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemyatk");
            Health playerHealth =  other.gameObject.GetComponent<Health>();
            
            playerHealth.TakeDmg(atkPower);

            attackBox.enabled = false;
            Invoke("AttackReady",1f);
        }
    }

    private void AttackReady()
    {
        attackBox.enabled = true;
    }
    
}
