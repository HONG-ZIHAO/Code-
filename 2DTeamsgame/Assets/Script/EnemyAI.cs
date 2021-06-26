using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    bool isGround=false;
    [SerializeField]
    Transform player;

    [SerializeField]
    float Range;//敵とプレイヤーの距離どのくらい制定するのか、
    
    [SerializeField]
    float moveSpeed;//移動スピード

    Rigidbody2D rb;

    Animator animator;

    private Renderer rend;
    //最初敵の色はブラックします
    [SerializeField] private Color colorToTurnTo = Color.black;
    [SerializeField] private Color newcolorToTurnTo = Color.white;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rend = GetComponent<Renderer>();
        rend.material.color = colorToTurnTo;
       
    }

    // Update is called once per frame
    void Update()
    {
        //float Range = Random.Range(0f, 5f);
        // 敵とプレイヤーとの距離求める
        float disToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (disToPlayer >=4)//もし 敵とプレイヤーの距離Rangeより小さいたったら
        {

            //rend.material.color = newcolorToTurnTo;
            //プレイヤー追いかける
            FllowPlayer();
        }
        else if (disToPlayer >=1&& disToPlayer <= 3 )
        {
            //rend.material.color = newcolorToTurnTo;
            Attacking();

        }
        else if(disToPlayer<2)
        {
            //rend.material.color = colorToTurnTo;
            StopMoveing();
        }
        void FllowPlayer()
        {
            //もし敵がプレイヤーの左にいるなら、右に移動する
            if (transform.position.x < player.position.x)
            {
                
                //rb.velocity = new Vector2(moveSpeed, 0);
                //transform.localScale =new Vector3(1,1,1);
                //animator.SetBool("isMove", true);
                //animator.SetBool("isAttack", false);
            }
            else if(transform.position.x > player.position.x )
            {
                //もし敵がプレイヤーの右にいるなら、左に移動する
              
                //rb.velocity = new Vector2(-moveSpeed, 0);
                //transform.localScale = new Vector3(-1, 1, 1);
                //animator.SetBool("isMove", true);
                //animator.SetBool("isAttack", false);
            }
        }

        void Attacking()
        {
            //Color colorToTurnTo = Color.white;
            //rb.velocity = Vector2.zero;
            //animator.SetBool("isAttack",true);

        }
        void StopMoveing()
        {
           
            //rb.velocity =new Vector2(0, 0);
            //animator.SetBool("isMove", false);
            animator.SetBool("isAttack",false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;


        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = false;


        }


    }
}
