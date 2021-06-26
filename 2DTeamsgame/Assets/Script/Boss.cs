using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss : MonoBehaviour
{

    public Transform leftX ,rightX;
    Rigidbody2D rb;
    public float speed;
    float leftPos;
    float rightPos;
    private bool Faceleft=true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        leftPos = leftX.position.x;
        rightPos = rightX.position.x;
        transform.DetachChildren();
        //削除
        Destroy(leftX.gameObject);
        Destroy(rightX.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    public void Move()
    {
        if (Faceleft)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            if (transform.position.x < leftPos)

            {
                transform.localScale = new Vector3(-2, 2, 2);
                Faceleft = false;

            }
        }
        else
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            if (transform.position.x > rightPos)
            {
                transform.localScale = new Vector3(2, 2, 2);
                Faceleft = true;
            }

        }
                    
        }


    }


