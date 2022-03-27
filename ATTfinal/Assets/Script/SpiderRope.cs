using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderRope : MonoBehaviour
{
    public Material mat;
    private LineRenderer line;
    public Rigidbody2D origin;
    private float line_width = 0.02f;
    [SerializeField] private float pull_force = 20;
    [SerializeField] public bool isPull = false;
    private Vector3 velocity;
    [SerializeField] private float speeds = 18;
    private bool pull = false;
    private bool update = false;
    public float gasAm3;
    public static SpiderRope instance;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start() 
    {
        line = GetComponent<LineRenderer>();
        if (!line)
        {
            line = gameObject.AddComponent<LineRenderer>();
        }
        line.startWidth= line_width;
        line.endWidth = line_width;
        Debug.Log(line.startWidth);
        line.material = mat;
    }
    public void setZero(Vector2 yes)
    {
        if (yes == yes)
            update = false;
        line.SetPosition(0, Vector2.zero);
        line.SetPosition(1, Vector2.zero);
        return;
    }
    public void setStart(Vector2 targetPos)
    {
        if (gasAm3 > 2)
        {
            Vector2 dir = targetPos - origin.position;
            dir = dir.normalized;
            velocity = dir * speeds;
            transform.position = origin.position + dir;
            pull = false;
            update = true;
            isPull = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        gasAm3 = GasBar.instance.gasAm2;
        if (!update)
        {
            return;
        }
        if (pull)
        {
            Vector2 dir = (Vector2)transform.position - origin.position;
            dir = dir.normalized;
            origin.AddForce(dir * pull_force);
        }
        else
        {
            transform.position += velocity * Time.deltaTime;
            float distance = Vector2.Distance(transform.position, origin.position);
            if (distance > 30)
            {
                update = false;
                line.SetPosition(0, Vector2.zero);
                line.SetPosition(1, Vector2.zero);
                isPull = false;
                return;
            }
        }
       
        line.SetPosition(0, transform.position);
        line.SetPosition(1, origin.position);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        velocity = Vector2.zero;
        pull = true;
    }
}
