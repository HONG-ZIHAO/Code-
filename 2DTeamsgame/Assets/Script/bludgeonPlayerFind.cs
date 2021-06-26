using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class bludgeonPlayerFind : MonoBehaviour
{
    public Transform player;
    Animator Anim;
    [SerializeField]
    float Dis;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < player.position.x)
            transform.localScale = new Vector3(1, 1, 1);
        else if (transform.position.x > player.position.x)
            transform.localScale = new Vector3(-1, 1, 1);
        Dis = Vector2.Distance(transform.position, player.transform.position);
        if (Dis >= 1.5f)
        {
            Anim.SetBool("Runing", true);
            //GameObject.Find("enemy2").GetComponent<AIPath>().enabled = true;
        }
        else
        {
            
            Anim.SetBool("Runing", false);
            Anim.SetBool("Attack", true);
            GameObject.Find("enemy2").GetComponent<AIPath>().enabled = false;
        }

    }

    public void AminSwitch()
    {
        Anim.SetBool("Attack", false);
        Anim.SetBool("Runing", true);
        GameObject.Find("enemy2").GetComponent<AIPath>().enabled = true;
    }
}
