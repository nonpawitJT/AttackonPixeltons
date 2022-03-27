using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSetter : MonoBehaviour
{
    public SpiderRope rope;
    public bool isrope = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isrope == false)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                SoundsManager.instance.playGear();
                Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                rope.setStart(worldPos);
                isrope = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Vector2 yes = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                rope.setZero(yes);
                SpiderRope.instance.isPull = false;
                isrope = false;
            }
        }
        

        
    }
}
