using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public AudioSource mySounds;
    [SerializeField] private AudioClip hoverSound;
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private AudioClip submitSound;
    [SerializeField] private AudioClip breakthewallSound;
    [SerializeField] private AudioClip Gear;
    [SerializeField] private AudioClip BossAttack;
    [SerializeField] private AudioClip Gas;
    [SerializeField] private AudioClip refillGas;
    [SerializeField] private AudioClip Jump;
    [SerializeField] private AudioClip takeDamage;
    [SerializeField] private AudioClip Run;
    [SerializeField] private AudioClip Slash;
    [SerializeField] private AudioClip enemyAttack;
    [SerializeField] private AudioClip titantakeDamage;
    [SerializeField] private AudioClip Victory;
    [SerializeField] private AudioClip Victory2;
    [SerializeField] private AudioClip gameOver;
    [SerializeField] private AudioSource ads;
    public static SoundsManager instance;

    private void Awake()
    {
        instance = this;
        ads = gameObject.AddComponent<AudioSource>();
        ads.volume = 0.2f;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Sounds
    public void playSound(AudioClip clip)
    {
        ads.PlayOneShot(clip);
    }


    public void playGear()
    {
        playSound(Gear);
      
    }
    public void playBossAttack()
    {
        playSound(BossAttack);
    }
    public void playGas()
    {
        playSound(Gas);
    }
    public void playrefillGas()
    {
        playSound(refillGas);
    }
    public void playJump()
    {
        playSound(Jump);
    }
    public void playtakeDamage()
    {
        playSound(takeDamage);
    }
    public void playRun()
    {
        playSound(Run);
    }
    public void playSlash()
    {
        playSound(Slash);
    }
    public void playenemyAttack()
    {
        playSound(enemyAttack);
    }
    public void playtitantakeDamage()
    {
        playSound(titantakeDamage);
    }
    public void playVictory()
    {
        playSound(Victory);
    }
    public void playVictory2()
    {
        playSound(Victory2);
    }
    public void playgameOver()
    {
        playSound(gameOver);
    }






    public void hoverSoundPlay()
    {
        mySounds.PlayOneShot(hoverSound);
    }

    public void clickSoundPlay()
    {
        mySounds.PlayOneShot(clickSound);
    }

    public void submitSoundPlay()
    {
        mySounds.PlayOneShot(submitSound);
    }

    public void breakthewallSoundPlay()
    {
        mySounds.PlayOneShot(breakthewallSound);
    }
}
