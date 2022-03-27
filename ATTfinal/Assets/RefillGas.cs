using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillGas : MonoBehaviour
{
    public bool isFill=false;
    public static RefillGas instance;
    private void Awake()
    {
        instance = this;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            SoundsManager.instance.playrefillGas();
            isFill = true;
        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            isFill = false;
        }
    }
}
