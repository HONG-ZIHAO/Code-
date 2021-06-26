using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    // public int speed;//

    
    Rigidbody2D rb;
    GameObject player;
    public int Fireballatk = 20;
    int CBATK = 20;
    //GameObject playerObject;
    // Update is called once per frame

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        // attackPoint = GetComponent<AttackPoint>();

    }


    void FixedUpdate()
    {
        //x方向の速度
        rb.velocity = new Vector2(5, 0);
        if (transform.localScale.x == -1)
        {
            rb.velocity = new Vector2(-5, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            Destroy(gameObject, 0.2f);


        }
        //DragonController Dg = collision.gameObject.GetComponent<DragonController>();
        //Frog fg = collision.gameObject.GetComponent<Frog>();
        //Guy GY = collision.gameObject.GetComponent<Guy>();
        //Crab Cb = collision.gameObject.GetComponent<Crab>();
        //// attackPoint.TakeDamage(10);
        //// Enemy 
        //Dg.DgTakeDamage(10);
        //fg.T
    }
    //自分を削除する
    private void DestorySelf()
    {

        Destroy(this.gameObject, 0.3f);
    }
}

