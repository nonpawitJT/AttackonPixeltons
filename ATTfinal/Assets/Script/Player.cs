using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public const float playerHp_MAX = 500;
    public float playerRegenAmount = 15;
    public float playerHp = 500;
    public float speed = 5f;
    public float jump = 5f;
    public float dashTime;
    public float dashSpeed;
    public float distanceBetweenImages;
    public float dashCoolDown;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animation;
    [SerializeField] private bool isMove;
    [SerializeField] private bool isDashing;
    public bool isPull2;
    public float gasAm;
    [SerializeField] public bool isUseGas = false;
    [SerializeField] private bool isGround;
    [SerializeField] private bool isAtk;
    [SerializeField] private bool isWin1 = false;
    [SerializeField] private bool isTakeDamage;
    [SerializeField] private bool isTakeDamage2;
    [SerializeField] private bool isFacingright = true;
    [SerializeField] LayerMask groundLayer;
    public static Player instance;

    private float dashTimeLeft;
    private float lastImageXpos;
    private float lastDash = -100;

    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerHp = playerHp + playerRegenAmount * Time.deltaTime;
        playerHp = Mathf.Clamp(playerHp, 0f, playerHp_MAX);
        isWin1 = Stage01RulesController.instance.iswin;
        isTakeDamage2 = AbnormalEnemy.isPlayertakingDmg;
        isTakeDamage = NormalEnemy.isPlayertakingDmg;
        isAtk = PlayerAttack.instance.isAttacking;
        gasAm = GasBar.instance.gasAm2;
        isPull2 = SpiderRope.instance.isPull;
        Run();
        CheckGround();
        Jump();
        AnimationPlayer();
        CheckDash();
        Dash();
        CheckMoveMentDirection();
        if (isTakeDamage)
        {
            
            playerTakeDamage(1f);
        }
        else if (isTakeDamage2)
        {
        
            playerTakeDamage(1f);
        }
        if (playerHp == 0)
        {
            SoundsManager.instance.playgameOver();
            animation.SetTrigger("Dead");
            StartCoroutine(waitDead());
        }
    }
    IEnumerator waitDead()
    {
        this.speed = 0;
        this.jump = 0;
        yield return new WaitForSeconds(4f);
        Score.scoreValue = 0;
        SceneManager.LoadScene("Stage01");
    }
    private void CheckMoveMentDirection()
    {
        if (isFacingright && rb.velocity.x < 0)
        {
            Flip();
        }
        else if (!isFacingright && rb.velocity.x > 0)
        {
            Flip();
        }
    }
    private void Flip()
    {
        isFacingright = !isFacingright;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    void Run()
    {

       
          rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        
        isMove = (Input.GetAxis("Horizontal") != 0);
    }
   

    void CheckGround()
    {
        isGround = Physics2D.OverlapCircle(transform.position, 0.8f, groundLayer);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGround)
        {
            
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }
    }

    void AnimationPlayer()
    {
        animation.SetBool("isWin", isWin1);
        animation.SetBool("isAttacking", isAtk);
        animation.SetBool("isDash", isDashing);
        animation.SetBool("isPull", isPull2);
        animation.SetBool("isMove", isMove);
        animation.SetBool("isGround", isGround);

    }

    void Dash()
    {
        if (Time.time >= (lastDash + dashCoolDown))
            if (Input.GetButtonDown("Fire3"))
            {
                
                if (gasAm > 4)
                {
                    SoundsManager.instance.playGas();
                    AttemptToDash();
                }
            }
    }

    private void AttemptToDash()
    {
        isDashing = true;
        dashTimeLeft = dashTime;
        lastDash = Time.time;

        PlayerAfterImagePool.Instance.GetFromPool();
        lastImageXpos = transform.position.x;
    }
    public void playerTakeDamage(float Damage)
    {
        // Instantiate(bloodEffect, transform.position, Quaternion.identity);
        playerHp -= Damage;
        Debug.Log("damage Taken!PPPP");
    }
    private void CheckDash()
    {
        if (isDashing)
        {
            if (dashTimeLeft > 0)
            {
                rb.velocity = new Vector2(dashSpeed * rb.velocity.x, rb.velocity.y);
                dashTimeLeft -= Time.deltaTime;
                isUseGas = true;

                if (Mathf.Abs(transform.position.x - lastImageXpos) > distanceBetweenImages)
                {
                    PlayerAfterImagePool.Instance.GetFromPool();
                    lastImageXpos = transform.position.x;
                }
            }
            if (dashTimeLeft < 0)
            {
                isUseGas = false;
                isDashing = false;
            }

        }
    }
}
