 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol Point")]
    [SerializeField] public Transform leftEdge;
    [SerializeField] public Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement Parameter")]
    [SerializeField] public float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;

    public static EnemyPatrol instance;

    private void Awake()
    {
        initScale = enemy.localScale;
        instance = this;

    }

   

    private void Update()
    { 
        if (movingLeft)
        {
            if(enemy.position.x >= leftEdge.position.x)
            {
                MoveInDirection(-1);
            }
            else
            {
                //Change Direction
                DirectionChange();
            }  
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
            {
                MoveInDirection(1);
            }
            else
            {
                //Change Direction
                DirectionChange();
            }
        }
    }
    public void OnDisables()
    {
        anim.SetBool("moving", false);    

    }
    private void DirectionChange()
    {
        anim.SetBool("moving", false);

        idleTimer += Time.deltaTime;
        if(idleTimer > idleDuration)
        {
            movingLeft = !movingLeft;
        }
        
    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("moving", true);

        //make enemy face direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);
        //move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z);


    }
}
