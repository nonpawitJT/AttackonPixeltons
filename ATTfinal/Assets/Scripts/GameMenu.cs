using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameMenu : MonoBehaviour
{
    public Button playBut;
    public Button exitBut;

    [SerializeField] private GameObject exitGameObject;
    [SerializeField] private GameObject videoPlayer;
    [SerializeField] private GameObject fadeWhite;


    public static GameMenu instance;
    public bool checkPlay = false;


    private void Awake()
    {
        instance = this;
        videoPlayer.SetActive(false);
        fadeWhite.SetActive(false);
    }

    void Start()
    {
        Button playbtn = playBut.GetComponent<Button>();
        Button exitbtn = exitBut.GetComponent<Button>();
        playbtn.onClick.AddListener(TaskOnClick_Play);
        exitbtn.onClick.AddListener(TaskOnClick_Exit);
    }
    
    void Update()
    {

    }

    //Onclicked
    void TaskOnClick_Play()
    {
        Debug.Log("Play!");
        checkPlay = true;
        exitGameObject.SetActive(false);
        StartCoroutine(playMv());
        StartCoroutine(playfadeWhite());
    }
    void TaskOnClick_Exit()
    {
        Debug.Log("Exit!");
        StartCoroutine(clickQuit());
    }

   IEnumerator clickQuit()
    {
        yield return new WaitForSeconds(2);
        Application.Quit();
    }

    IEnumerator playMv()
    {
        yield return new WaitForSeconds(3);
        videoPlayer.SetActive(true);
        SoundsManager.instance.breakthewallSoundPlay();
        yield return new WaitForSeconds(1);
        videoPlayer.SetActive(false);
    }
    IEnumerator playfadeWhite()
    {
        yield return new WaitForSeconds(3);
        fadeWhite.SetActive(true);
    }


}
