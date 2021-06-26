using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCon : MonoBehaviour
{
    public Slider slider;
    Animator animator;
    PlayerCon player;
    bool isDead;
    UnityEngine.Object Item;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerCon>();
        animator = GetComponent<Animator>();
        Item = Resources.Load("item1");
    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }
    public void Die()
    {
      
            if (slider.value <= 0)
            {
                isDead = true;
            animator.SetBool("Dead", true);
             Destroy(this.gameObject,1.0f);
            this.enabled = false;//アクションStop
            GameObject item1 = (GameObject)Instantiate(Item);
            item1.transform.position = new Vector3(transform.position.x , transform.position.y, transform.position.z);
        }
          
        }
    

private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag){
            case   "AttackPoint":
                slider.value -= 10;
                Die();
                break;
            case "AttackPoint2":
                Debug.Log("AttackPoint2");
                slider.value -= 15;
                Die();
                break;
            case "AttackPoint3":
                slider.value -= 15;
                Die();
                break;
            case "Fire":
                slider.value -= 20;
                Die();
                break;
            case "Special":
                slider.value -= 30;
                Die();
                break;


        }
      
       
        
       
            //Destroy(collision.gameObject, 0.3f);
       
    }
}
