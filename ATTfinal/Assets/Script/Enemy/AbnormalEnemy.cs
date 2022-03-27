using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbnormalEnemy : MonoBehaviour
{
    public int Abhealth = 1;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int Damage;
    public static bool isPlayertakingDmg = false;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;
    public static AbnormalEnemy instance;

    [SerializeField] private GameObject abnormalTitan;

    private Animator anim;
    

    public AbnormalEnemyPatrol abnormalenemyPatrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        abnormalenemyPatrol = GetComponentInParent<AbnormalEnemyPatrol>();
        instance = this;
    }


    // Update is called once per frame
    void Update()
    {

        
        if (Abhealth == 0)
        {
            AbnormalEnemyPatrol.instance.OnDisables();
            AbnormalEnemyPatrol.instance.speed = 0;
            anim.SetTrigger("die");
            StartCoroutine(waitDied());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isPlayertakingDmg == false)
        {
            Debug.Log("Trigger!");
            isPlayertakingDmg = true;
            StartCoroutine(waitDamage());
        }
        
    }

    IEnumerator waitDamage()
    {
        yield return new WaitForSeconds(0.3f);
        isPlayertakingDmg = false;
    }


    IEnumerator waitDied()
    {
        Score.scoreValue += 1;
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }

    public void TakeDamage(int Damage)
    {
        // Instantiate(bloodEffect, transform.position, Quaternion.identity);
        Abhealth -= Damage;
        Debug.Log("damage Taken!");
    }
   
}
