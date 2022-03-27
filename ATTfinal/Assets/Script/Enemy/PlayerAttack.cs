using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private float timeBtwAttack;
    public float startTimeAttack;
    public Transform attackPos;
    public Animator PlayerAnim;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int Damage;
    public bool isAttacking=false;
    public static PlayerAttack instance;
    private void Awake()
    {
        instance = this;
      
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBtwAttack <= 0)
        {
            
            if (Input.GetKey(KeyCode.Mouse0))

            {
                isAttacking = true;
             
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position,attackRange,whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length ; i++)
                {
                    enemiesToDamage[i].GetComponent<NormalEnemy>().TakeDamage(Damage);
                   // enemiesToDamage[i].GetComponent<AbnormalEnemy>().TakeDamage(Damage);

                }

                
                StartCoroutine(waits());
               
            }
            
            timeBtwAttack = startTimeAttack;
            
        }
        else
        {

            timeBtwAttack -= Time.deltaTime;
            
        }

     
    }
    IEnumerator waits()
    {
        yield return new WaitForSeconds(.4f);
        isAttacking = false;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position ,attackRange);
    }
}
