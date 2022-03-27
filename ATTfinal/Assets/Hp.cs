using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp : MonoBehaviour
{

    public int gasHp = 10;
    public Slider hpbar;
    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            gasHp -= 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        hpbar.value = gasHp;
    }
}
