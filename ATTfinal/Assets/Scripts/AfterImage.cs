using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterImage : MonoBehaviour
{
    [SerializeField] private GameObject exitAfterImage;
    [SerializeField] private GameObject creditsAfterImage;

    private void Awake()
    {
        exitAfterImage.gameObject.SetActive(false);
        creditsAfterImage.gameObject.SetActive(false);
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        if (GameMenu.instance.checkPlay == true)
        {
            exitAfterImage.SetActive(true);
            creditsAfterImage.SetActive(true);
        }
    }

}
