using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D boxCollider2d1;
    public float distance;
    bool isFalling = false;
    public static Falling instance;
    private void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        boxCollider2d1 = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        Physics2D.queriesStartInColliders = false;
        if (isFalling == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distance);
            Debug.DrawRay(transform.position, Vector2.down * distance, Color.red);
            if (hit.transform.tag == "Player")
            {
                rb.gravityScale = 5;
                isFalling = true;
                StartCoroutine(waitsHand());
            }
        }
    }
    IEnumerator waitsHand()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
