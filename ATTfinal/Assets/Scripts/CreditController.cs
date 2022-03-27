using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditController : MonoBehaviour
{
    public bool isCredits = false;
    public Button creditsBut;
    [SerializeField] private GameObject creditsGameObject;
    [SerializeField] private GameObject imageCredits;
    [SerializeField] private GameObject textCredits;
    [SerializeField] private GameObject textCreditsTitle;
    [SerializeField] private GameObject pressEsc;

    private void Awake()
    {
        imageCredits.gameObject.SetActive(false);
        textCredits.gameObject.SetActive(false);
        textCreditsTitle.gameObject.SetActive(false);
        pressEsc.gameObject.SetActive(false);
    }
    void Start()
    {
        Button creditsbtn = creditsBut.GetComponent<Button>();
        creditsbtn.onClick.AddListener(TaskOnClick_Credits);
    }

    void Update()
    {
        if (Input.GetKeyDown("escape") && isCredits == true)
        {
            imageCredits.gameObject.SetActive(false);
            textCredits.gameObject.SetActive(false);
            textCreditsTitle.gameObject.SetActive(false);
            pressEsc.gameObject.SetActive(false);
            isCredits = false;
            SoundsManager.instance.clickSoundPlay();
        }

        if(GameMenu.instance.checkPlay == true)
        {
            creditsGameObject.SetActive(false);
        }
    }

    void TaskOnClick_Credits()
    {
        if (isCredits == false)
        {
            Debug.Log("Credits!");
            imageCredits.gameObject.SetActive(true);
            textCredits.gameObject.SetActive(true);
            textCreditsTitle.gameObject.SetActive(true);
            pressEsc.gameObject.SetActive(true);
            isCredits = true;
        }
    }
}
