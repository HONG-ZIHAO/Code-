using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeDamORHealer : MonoBehaviour
{
    public Slider slider;
    public Slider exe;
  


    Rigidbody2D rb;
    Animator animator;
    PlayerCon player;

    public int itemscore = 0;
    [SerializeField]
    Text Item;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GetComponent<PlayerCon>();
        itemscore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Item.GetComponent<Text>().text = itemscore.ToString();
        // Exe();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {

            case "Heart":
                slider.value += 10;
                break;
            case "Exe":
                exe.value += 10;
                break;
            case "item":
                itemscore++;
                Destroy(collision.gameObject, 0.1f);
                break;
        }

      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                slider.value -= 20;

                rb.velocity = Vector2.zero;
                animator.SetTrigger("isHurt");
                break;
            case "Boss":
                //slider.value -= 10;
                rb.velocity = Vector2.zero;
                if (transform.localScale.x == 1)
                {

                    rb.velocity = new Vector2(-150f*2f, 10f);
                    // Bossfallen();
                    animator.SetTrigger("fallen"); 
                    Die();
                }
                else if (transform.localScale.x == -1)//もしプレイヤーは右にBoss当たったら、右方向飛び出す

                {

                    rb.velocity = new Vector2(150f*2f, 10f);
                    //Bossfallen();
                    animator.SetTrigger("fallen");
                    Die();
                }
                // rb.AddForce(Vector2.left *- 5, 0f); ;
                break;

        }
    }
    


    public void Die()
    {
        if (slider.value <= 0)
        {
            rb.velocity = Vector2.zero;
            animator.SetBool("isDie", true);
            this.enabled = false;
        }
    }
}

