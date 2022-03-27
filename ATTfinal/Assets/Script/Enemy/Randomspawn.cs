using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomspawn : MonoBehaviour
{
    public GameObject ItemPrefeb;
    public Transform t;


    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            SpawnObjectAtRanDom();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
       


    }
    void SpawnObjectAtRanDom()
    {
       
        Instantiate(ItemPrefeb, t.position, Quaternion.identity);
    }
    IEnumerator waitsHand()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
