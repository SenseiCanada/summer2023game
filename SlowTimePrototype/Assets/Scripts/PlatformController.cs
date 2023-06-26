using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlatformController : MonoBehaviour
{
    Rigidbody2D PlatformRB;
    public float speed = 3f;
    public int startingPoint;
    public Transform[] points;
    public float debugNumber = 4f;

    private int i;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[startingPoint].position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;
            }
        }
        
        var step = speed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, points[i].position, step);
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
