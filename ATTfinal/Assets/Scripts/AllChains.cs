using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllChains : MonoBehaviour
{
    [SerializeField] private Animator allChains;

    private void Awake()
    {
        allChains.gameObject.GetComponent<Animator>().enabled = false;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(GameMenu.instance.checkPlay == true)
        {
            allChains.gameObject.GetComponent<Animator>().enabled = true;
        }
    }
}
