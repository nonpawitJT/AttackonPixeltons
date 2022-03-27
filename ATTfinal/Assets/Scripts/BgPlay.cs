using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgPlay : MonoBehaviour
{
    public bool checkPlay2 = false;
    public bool checkPlay2to3 = false;

    [SerializeField] private Animator animation;

    private void Awake()
    {
        animation = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (GameMenu.instance.checkPlay == true)
        {
            AnimationPlay();
            checkPlay2 = true;
            StartCoroutine(play2to3());
        }
    }

    void AnimationPlay()
    {
        animation.SetBool("checkPlay2", checkPlay2);
        animation.SetBool("checkPlay2to3", checkPlay2to3); 
    }
    IEnumerator play2to3()
    {
        yield return new WaitForSeconds(2);
        checkPlay2to3 = true;
    }
}
