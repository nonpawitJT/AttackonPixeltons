using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Go()
    {
        StartCoroutine(Waits());
      
    }
    IEnumerator Waits()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(1);
    }
}
