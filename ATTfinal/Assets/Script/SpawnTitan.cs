using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTitan : MonoBehaviour
{
    [SerializeField] private GameObject[] Titan;
    [SerializeField] private GameObject spawnPoint;

    [SerializeField] public float time;
    [SerializeField] public float spawntime;

    //[SerializeField] private GameObject[] spwanpoint;

    public bool isSpawn;

    private void Awake()
    {
        
    }
    void Start()
    {
        time = 0f;
        spawntime = 5;
        isSpawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isSpawn)
        {
            
            time += Time.deltaTime;
            if (time > spawntime) 
            {
                time = 0;

                Instantiate(Titan[Random.Range(0, 3)], spawnPoint.transform.position, Quaternion.identity);

            }
        }
        delaySpawn();
        /*if(Timer.instance.isTimeOver == true)
        {
            Destroy(spawnPoint);
        }*/
    }

    public void delaySpawn()
    {
        spawntime = Random.Range(7, 11);
        isSpawn = true;
    }
}
