using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class playerFind : MonoBehaviour
{
    float Dis;
    public bool animSwitch = true;
    public float attackTime;
    public float investigate = 10f;
    public Transform player;
    public Animator Anim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Dis = Vector2.Distance(transform.position, player.transform.position);
        if (Dis < investigate)
        {
            GameObject.Find("enemy").GetComponent<AIPath>().enabled = animSwitch;
            GameObject.Find("enemy/enemy-test").GetComponent<EnemyAI>().enabled = animSwitch;
            Anim.SetBool("isMove", animSwitch);
        }
        if (transform.position.x < player.position.x)
            transform.localScale = new Vector3(1, 1, 1);
        else if (transform.position.x > player.position.x)
            transform.localScale = new Vector3(-1, 1, 1);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //GameObject.Find("enemy").GetComponent<AIDestinationSetter>().enabled = false;
        //GameObject.Find("enemy/enemy-test").GetComponent<EnemyAI>().enabled = false;
        if (collision.collider.tag == "Player")
        {
            animSwitch = false;
            Anim.SetBool("isMove", animSwitch);
            Invoke("Switch", attackTime);
        }

    }
    void Switch()
    {
        animSwitch = true;
        
    }
}
