using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ArcherPlayerFind : MonoBehaviour
{
    public float Dis;
    float speed = 1f;
    public Transform player;
    public bool AnimSwitch = true;
    public GameObject enemy3;
    public GameObject bow;
    Animator Anim;
    void Start()
    {
        Anim = GetComponent<Animator>();
    }
    void Update()
    {
        Dis = Vector2.Distance(transform.position, player.transform.position);
        if (Dis < 10 && Dis > 5)
        {
            //Debug.Log("123");
            Anim.SetBool("runing", true);
            GameObject.Find("enemy3").GetComponent<AIPath>().enabled = true;
            bow.SetActive(false);
            Direction();
        }
        else if (Dis <= 5 && Dis > 2)
        {
            Anim.SetBool("runing", false);
            GameObject.Find("enemy3").GetComponent<AIPath>().enabled = false;
            bow.SetActive(true);
            Direction();
            
        }
        else if (Dis <= 2)
        {
            Anim.SetBool("runing", true);
            //GameObject.Find("enemy3").GetComponent<AIPath>().enabled = true;
            GameObject.Find("enemy3/Archer/Crossbow").SetActive(false);
            if (transform.position.x > player.position.x)
            {
                enemy3.transform.Translate(Vector2.right * speed * Time.deltaTime);
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (transform.position.x < player.position.x)
            {
                enemy3.transform.Translate(Vector2.left * speed * Time.deltaTime);
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }

    }
    void Direction()
    {
        if (transform.position.x < player.position.x)
            transform.localScale = new Vector3(1, 1, 1);
        else if (transform.position.x > player.position.x)
            transform.localScale = new Vector3(-1, 1, 1);
    }
}


