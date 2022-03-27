using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScreen : MonoBehaviour
{
    [SerializeField] private GameObject redDamageScreen;
    [SerializeField] Transform targetDS;
    public float redOpacity = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = targetDS.position;

        redOpacity = 0.5f - Player.instance.playerHp/1000f;
        if(redOpacity >= 0.5f)
        {
            redOpacity = 0.5f;
            redDamageScreen.GetComponent<Renderer>().material.color = new Color(1, 0, 0, redOpacity);
        }
        else
        {
            redDamageScreen.GetComponent<Renderer>().material.color = new Color(1, 0, 0, redOpacity);
        }
        

    }
}
