using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class box : MonoBehaviour
{
    public int bossHp=50;
    public Slider hpbar;
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            bossHp -= 5;
        }
    }
    // Update is called once per frame
    void Update()
    {
        hpbar.value = bossHp;

        if (bossHp == 0)
        {
            
            StartCoroutine(wait());
            Destroy(gameObject);
            StartCoroutine(wait());
            SceneManager.LoadScene(0);


        }
    }
    IEnumerator wait()
    {
        SoundsManager.instance.playVictory2();
        yield return new WaitForSeconds(4f);

    }
}
