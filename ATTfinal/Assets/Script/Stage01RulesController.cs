using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage01RulesController : MonoBehaviour
{
   
    public bool iswin=false;
    public static Stage01RulesController instance;
    private void Awake()
    {
        instance = this;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (iswin==true) {
              
                StartCoroutine(wait());
          
                SceneManager.LoadScene(2);

        }
        }
    }
    void Update()
    {
        if (Score.scoreValue == 10)
        {
            iswin = true;
        }
        else
        {
            iswin = false;
        }
    }

        IEnumerator wait()
    {
           Score.scoreValue = 0;
           yield return new WaitForSeconds(4f);
       
    }
}
