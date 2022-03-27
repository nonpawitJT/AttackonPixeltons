using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : MonoBehaviour
{
    public int health=5;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int Damage;
    public static bool isPlayertakingDmg = false;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;
    public GameObject bloodEffect;
    public static NormalEnemy instance;

    private Animator anim;
   

    private EnemyPatrol enemyPatrol;

    private void Awake()
    {
        instance = this;
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }


    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;

        //Attack when in sight
        if(PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {

                SoundsManager.instance.playenemyAttack();//Attack
               
                cooldownTimer = 0;
                anim.SetTrigger("Attack");
               
               

            }
        }

        if(enemyPatrol != null)
        {
            enemyPatrol.enabled = !PlayerInSight();
        }
        if (health == 0)
        {
            SoundsManager.instance.playtitantakeDamage();
            EnemyPatrol.instance.OnDisables();
            EnemyPatrol.instance.speed = 0;
            Score.scoreValue += 1;
            anim.SetTrigger("die");
            StartCoroutine(waitDied());
        }
        
    }
    IEnumerator waitDied()
    {
       
        yield return new WaitForSeconds(1f);

        gameObject.SetActive(false);
    }
    private void Destroyyes()
    {
        Destroy(gameObject);
    }
    
    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range,boxCollider.bounds.size.y * 2.5f, boxCollider.bounds.size.z),
            0,Vector2.left,0,playerLayer);

        if (hit.collider != null)
        {
           isPlayertakingDmg = true;
            StartCoroutine(waitHp());
        }
       return hit.collider != null;
    }

    IEnumerator waitHp()
    {
        yield return new WaitForEndOfFrame();
        isPlayertakingDmg = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y*2.5f, boxCollider.bounds.size.z));
    }

  
    public void TakeDamage(int Damage)
    {
       // Instantiate(bloodEffect, transform.position, Quaternion.identity);
        health -= Damage;
        Debug.Log("damage Taken!");
    }
}
