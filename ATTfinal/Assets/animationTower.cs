using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationTower : MonoBehaviour
{
    [SerializeField] private Animator animation;
    [SerializeField] private bool isWin1;
    // Start is called before the first frame update

    private void Awake()
    {
        animation = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        isWin1 = Stage01RulesController.instance.iswin;
        if (isWin1 == true)
        {
            AnimationPlayer();
        }
    }
    void AnimationPlayer()
    {
        animation.SetBool("isWin", isWin1);
    }
}
