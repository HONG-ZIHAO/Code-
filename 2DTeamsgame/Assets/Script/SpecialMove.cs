using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialMove : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(-5, 0);
        if (transform.localScale.x==-5)
        {
            rb.velocity = new Vector2(5, 0);
        }
        Destory();
    }


    void Destory()
    {
        Destroy(this.gameObject,1.0f);

    }
}
