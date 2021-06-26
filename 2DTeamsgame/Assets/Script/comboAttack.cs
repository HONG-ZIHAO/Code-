using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comboAttack : MonoBehaviour
{
    public Animator anim;
    Rigidbody2D rb;
    [SerializeField] GameObject AttackPoint1;
    [SerializeField] GameObject AttackPoint2;
    [SerializeField] GameObject AttackPoint3;
    public int noOfClicks = 0;//number of click//何回クリックすること

    float lastClickedTime = 0;
    public float maxComboDelayTime ;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        AttackPoint1.SetActive(false);
        AttackPoint2.SetActive(false);
        AttackPoint3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time-lastClickedTime>maxComboDelayTime)//このフレームの開始する時間
        {
            noOfClicks = 0;
        }
        // if (Input.GetMouseButtonDown(0)){
        if (Input.GetKeyDown(KeyCode.Z)) { 
            lastClickedTime = Time.time;
            noOfClicks++;
            if (noOfClicks == 1)
            {
                anim.SetBool("Attack1", true);
                AttackPoint1.SetActive(true);
            }
            noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);//attack  Mode 三つ//Mathf.Clamp(範囲内に指定したい値,最小値,最大値);
        }
    }

    public void return1()//アタック1からアタック2アニメーション切り替え
    {
       
        if (noOfClicks == 2)//もし二回クリックすると
        {
            AttackPoint2.SetActive(true);
            anim.SetBool("Attack2", true);
           
        }
        else
        {
            anim.SetBool("Attack1", false);
            noOfClicks = 0;
        }
    }

    public void return2()//アタック2からアタック3アニメーション切り替え
    {
        
        if (noOfClicks == 3)
        {
            AttackPoint3.SetActive(true);
            anim.SetBool("Attack3", true);
            
        }
        else
        {
            anim.SetBool("Attack2", false);
            noOfClicks = 0;
        }
    }
    public void return3()//アイドル戻る
    {
        
      anim.SetBool("Attack1", false);
       anim.SetBool("Attack2", false);
        anim.SetBool("Attack3", false);
        noOfClicks = 0;//ゼロから戻ります
        AttackPoint1.SetActive(false);
       // AttackPoint2.SetActive(false);
       // AttackPoint3.SetActive(false);
    }
       
    }

