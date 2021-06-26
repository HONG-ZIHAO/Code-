using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerCon : MonoBehaviour
{
    public Slider slider;//HP値
    public Slider exe;//Mp値
    Rigidbody2D rb;//
    Animator animator;
    //CapsuleCollider2D collider2D;
    public enum PlayerMode
    {
        action     //アクション中
    }
    //プレイヤーのMode
    public static PlayerMode nowMode = PlayerMode.action;
    bool isGround = false;//地してない
    float speed = 5f;//移動スビート

    

    [SerializeField] GameObject AttackPoint;
    
   
    
    //FireballObject　呼び出す
    UnityEngine.Object FireballRef;
    //プレイヤーの技呼び出す

    UnityEngine.Object SpecialPowerLeft;
    UnityEngine.Object SpecialPowerRight;

    private float dashAtual;
    private bool canDash;
   private  bool isDashing;

    public float duracaDash;
    public float dashSpeed;
    public Ghost ghost;
    //public float dashcoolDown;
    // Start is called before the first frame update
    void Start()
    {
        //現在のプレイヤーの状態をアクションモードにリセット
        nowMode = PlayerMode.action;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //主人公の技（火球）GameObjecを導入します
        FireballRef = Resources.Load("Fireball");
        //主人公の技GameObjecを導入します
        SpecialPowerLeft = Resources.Load("SpecialMoveLeft");
        SpecialPowerRight = Resources.Load("SpecialMoveRight");
        //
        AttackPoint.SetActive(false);
        canDash = true;
        dashAtual = duracaDash;
    }

    // Update is called once per frame
    void Update()
    {
        //アクション中以外は操作不可にする
        if (nowMode != PlayerMode.action) return;
        //プレイヤーの移動処理
        //ｘ軸取得
        float moveX = Input.GetAxis("Horizontal");//　<-- //-->
        //Vector2 xとy 同時に管理できる
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
        //  *6f移動スビート

        //方向転換処理ーーーーー.

        //player transform ｚ軸取得
        Vector3 scale = transform.localScale;
        if ((moveX > 0 && scale.x < 0) || (moveX < 0 && scale.x > 0))
        {
            scale.x *= -1;
            transform.localScale = scale;
        }
        //  transform.Rotate(0, 180f, 0);
        //Attack();//攻撃処理
        FireBall();
        SpecialMove();
        //Dash();


        Jump();   //ジャンプ処理ーーー
        Dash();
        Die();//死亡
        //移動中か
        animator.SetBool("isMove", moveX != 0);
            //速度ベクトル取得
            float velocityY = Mathf.Round(rb.velocity.y);
            //ジャンプ中か
            animator.SetBool("isJump", velocityY > 0 && !isGround);
            //落下中か
            animator.SetBool("isFall", velocityY < 0 && !isGround);

           
        }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Ground") isGround = true;
        {
            Debug.Log("isGround == true");
        }
    }
       
        private void  OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Ground")

                isGround = false;
        }
   
        //攻撃処理
  
    void FireBall()//火球処理
    {

        if (exe.value>=10&&Input.GetKeyDown(KeyCode.C))
        {
            rb.velocity = Vector2.zero;
            GameObject Fireball = (GameObject)Instantiate(FireballRef);////instantiate gameobject 現れるために
            Fireball.transform.localScale = this.transform.localScale;
            //Fireball でる場所
            if (transform.localScale.x == 1)
            {                                          //Fireball でる場所
                Fireball.transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
                //Fireball.transform.localScale = new Vector3(transform.localScale.x, 1, transform.localScale.z);
            }
                 if (transform.localScale.x == -1)
            {
                Fireball.transform.position = new Vector3(transform.position.x - 1, transform.position.y + 0.2f, transform.position.z);
                //Fireball.transform.localScale = this//new Vector3(-1, 1, transform.localScale.z);
            }
                
            Debug.Log("FireBall");
            //audioSource.PlayOneShot(se_Fireball);
            //Fireball　アニメーションの切り替え
            animator.SetBool("isFire", true);
        }
        else if (Input.GetKeyUp(KeyCode.C)&&exe.value>=10)
        {
            exe.value -=10;
            animator.SetBool("isFire", false);
        }
    }
    void SpecialMove()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            rb.velocity = Vector2.zero;
            GameObject SpecialMoveLeft = (GameObject)Instantiate(SpecialPowerLeft);
            GameObject SpecialMoveRight = (GameObject)Instantiate(SpecialPowerRight);
            SpecialMoveLeft.transform.position = new Vector3(transform.position.x - 4, transform.position.y, transform.position.z);

            SpecialMoveRight.transform.position = new Vector3(transform.position.x + 4, transform.position.y, transform.position.z);
            //animator.SetBool("isSpecialPower", true);
            animator.SetTrigger("isSpecialPower 0");
        }

    }


    void Jump()
    {
        //ジャンプ処理ーーー
        if (Input.GetButtonDown("Jump") && rb.velocity.y==0)
        {
            //*800f ジャンプ力
            rb.AddForce(Vector2.up * 800f);
           
            Debug.Log("rb 800");
        }
    }
    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.V) && canDash)
        {
            if (dashAtual <= 0)
            {
                StopDash();
            }
            else
            {
               // isDashing = true;
                dashAtual -= Time.deltaTime;

                if (transform.localScale.x == -1)
                {
                    rb.velocity = Vector2.left*2f * dashSpeed;
                    ghost.makeGhost = true;
                }
                else if (transform.localScale.x == 1)
                {
                    rb.velocity = Vector2.right*2f * dashSpeed;
                    ghost.makeGhost = true;
                }

            }


        }
        if (Input.GetKeyUp(KeyCode.V))
        {
            ghost.makeGhost = false;
            //isDashing = false;
            canDash = true;
            dashAtual = duracaDash;


        }

    }
    private void StopDash()
    {
        rb.velocity = Vector2.zero;
        dashAtual = duracaDash;
        isDashing = false;
        canDash = false;
        ghost.makeGhost = false;

    }



        public void Die()//死亡処理
    {
        if (slider.value <= 0)
        {
            rb.velocity = Vector2.zero;
            animator.SetBool("isDie", true);
            this.enabled = false;
        }
    }



}

