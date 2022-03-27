using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioSource mySoundEffect;
    [SerializeField] private AudioClip playerRun;
    [SerializeField] private AudioClip playerDash;
    [SerializeField] private AudioClip playerAttack;
    [SerializeField] private AudioClip playerJump;
    [SerializeField] private AudioClip playerODMGear;
    [SerializeField] private AudioClip playerTakeDamage;
    [SerializeField] private AudioClip titanTakeDamage;
    [SerializeField] private AudioClip titanAttack;
    [SerializeField] private AudioClip gasRefill;
    [SerializeField] private AudioClip bossAttack;
    [SerializeField] private AudioClip gameOver;
    [SerializeField] private AudioClip victory;


    public static SoundEffect instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
    }

    public void playerRunPlay()
    {
        //??? isGround ???? ????????????????????????????????????????????????????????? a ???? d ???????????????????????????????????????
        wait();
        mySoundEffect.Stop();
        mySoundEffect.loop = true;
        mySoundEffect.clip = playerRun;
        mySoundEffect.Play();
    }

    public void playerRunStop()
    {
        //??? isGround ???? ????????????????????????????????????????????????????????????????????? a ???? d ???????????????????????????????????????
        mySoundEffect.clip = playerRun;
        mySoundEffect.Stop();
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.5f);
    }


    public void playerDashPlay()
    {
        mySoundEffect.PlayOneShot(playerDash);
    }

    public void playerAttackPlay()
    {
        mySoundEffect.PlayOneShot(playerAttack);
    }

    public void playerJumpPlay()
    {
        mySoundEffect.PlayOneShot(playerJump);
    }

    public void playerODMGearPlay()
    {
        mySoundEffect.PlayOneShot(playerODMGear);
    }

    public void playerTakeDamagePlay()
    {
        mySoundEffect.PlayOneShot(playerTakeDamage);
    }

    public void titanTakeDamagePlay()
    {
        mySoundEffect.PlayOneShot(titanTakeDamage);
    }

    public void titanAttackPlay()
    {
        mySoundEffect.PlayOneShot(titanAttack);
    }

    public void gasRefillPlay()
    {
        //??????????????????? ??????????? 8 Bit ????????????????????
        mySoundEffect.PlayOneShot(gasRefill);
    }

    public void bossAttackPlay()
    {
        mySoundEffect.PlayOneShot(bossAttack);
    }
    public void victoryPlay()
    {
        //??????????
        mySoundEffect.PlayOneShot(victory);
    }

    public void gameOverPlay()
    {
        //?????????
        mySoundEffect.PlayOneShot(gameOver);
    }
}