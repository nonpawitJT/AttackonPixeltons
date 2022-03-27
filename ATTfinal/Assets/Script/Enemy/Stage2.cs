using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Stage2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer.instance.timeRemaining == 0)
        {
            SceneManager.LoadScene(3);
        }
    }
    IEnumerator wait()
    {
        
        yield return new WaitForSeconds(4f);

    }
}
