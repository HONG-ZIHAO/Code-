//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerContest : MonoBehaviour
//{

//    SpriteRenderer Sprite;
//    float movespeed;
//    bool FaceRight = true;
//    Start is called before the first frame update
//    void Start()
//    {
//        Sprite = GetComponent<SpriteRenderer>();
//    }

//    Update is called once per frame
//    void Update()
//    {

//    }


//    void Movement()
//    {



//    }
//    void Attack()
//    {

//        if (Input.GetKeyDown(KeyCode.A) && !isAttack)


//        {

//            isAttack = true;

//            animator.SetTrigger("isAttack 0");

//            StartCoroutine(DoAttack());
//        }
//    }
//    IEnumerator DoAttack()
//    {
//        AttackPoint.SetActive(true);
//        yield return new WaitForSeconds(0.07f);
//        AttackPoint.SetActive(false);
//        isAttack = false;


//    }
//    if (isAttack)
//    {
//        rb.velocity = Vector2.zero;
//        attackCounter -= Time.deltaTime;
//        // //攻撃時間処理

//        if (attackCounter <= 0)
//        {
//            isAttack = false;
//            animator.SetBool("idle", true);
//            //animator.SetBool("isAttack", false);
//            Debug.Log("isAttack=false");
//        }
//    }

//    if (Input.GetKeyDown(KeyCode.A) )
//    {

//        attackCounter = attackTime;
//            isAttack = true;


//            //  animator.SetBool("isAttack", true);
//            animator.SetTrigger("isAttack 0");
//            Debug.Log("isAttack=true");
//        //}

//    }
//void Attack()
//{
//    if (Input.GetKeyDown(KeyCode.A))
//    {

//        animator.SetTrigger("isAttack 0");
//        AttackPoint.SetActive(true);
//    }
//    else if(Input.GetKeyUp(KeyCode.A))
//    {
//        AttackPoint.SetActive(false);
//    }
//}
//}
//}
