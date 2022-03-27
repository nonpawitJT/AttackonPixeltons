using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbnormalEnemyPatrol : MonoBehaviour
{
    [Header("Patrol Point")]
    [SerializeField] public Transform leftEdge;
    [SerializeField] public Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement Parameter")]
    public float speed;
    public float speedTime;
    private Vector3 initScale;
    private bool movingLeft;
    public bool isChangeSpeed = false;

    public static bool isPlayertakingDmg = false;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Enemy Animator")]
    public Animator anim;
    

    public static AbnormalEnemyPatrol instance;

    private void Awake()
    {
        initScale = enemy.localScale;
        instance = this;
        
        speed = 5;
    }

    public void OnDisables()
    {
        anim.SetBool("moving", false);
    }

    private void Update()
    {

        if(isChangeSpeed)
        {
            speedTime += Time.deltaTime;
            if(speedTime >= 1)
            {
                speed = Random.Range(1, 7);
                speedTime = 0;
                isChangeSpeed = false;
            }
        }
        delaySpeed();
        
        if (movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
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

    private void DirectionChange()
    {
        anim.SetBool("moving", false);

        idleTimer += Time.deltaTime;
        if (idleTimer > idleDuration)
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

    public void delaySpeed()
    {
        isChangeSpeed = true;
    }

    

    
}
