using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy2 : MonoBehaviour
{

    public int health = 5;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int Damage;
    public static bool isPlayertakingDmg = false;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    [SerializeField] public float stopDistance;
    [SerializeField] private Transform target;

    [SerializeField] private Animator anim;
    [SerializeField] public float speed = 1;

    public static NormalEnemy2 instance;


    //private Health playerHealth;

    private EnemyPatrol enemyPatrol;

    private void Awake()
    {
        instance = this;
        anim = GetComponent<Animator>();
        //enemyPatrol = GetComponentInParent<EnemyPatrol>();
        target = GameObject.FindGameObjectWithTag("Gas Tank").GetComponent<Transform>();
        anim.SetBool("moving", true);
    }


    // Update is called once per frame
    void Update()
    {


        cooldownTimer += Time.deltaTime;

        //Attack when in sight
        if (PlayerInSight())
        {
            anim.SetBool("moving", false);
            if (cooldownTimer >= attackCooldown)
            {
                //Attack
                cooldownTimer = 0;
                anim.SetTrigger("Attack");
                speed = 0;
            }
        }

        else
        {
            speed = 1;
            if (Vector2.Distance(transform.position, target.position) > stopDistance)
            {
                anim.SetBool("moving", true);
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
        }

        if (enemyPatrol != null)
        {
            enemyPatrol.enabled = !PlayerInSight();
        }

        if (health <= 0)
        {
            //EnemyPatrol.instance.OnDisables();
            //EnemyPatrol.instance.speed = 0;
            anim.SetTrigger("die");
            StartCoroutine(waitDied());
        }

    

    }
    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

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

    IEnumerator waitDied()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    public void TakeDamage(int Damage)
    {
        // Instantiate(bloodEffect, transform.position, Quaternion.identity);
        health -= Damage;
        Debug.Log("damage Taken!");
    }
}
