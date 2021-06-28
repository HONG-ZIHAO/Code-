using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPcontrol : MonoBehaviour
{
    public float hp = 100f;
    int hutr = 10;
    int blood = 20;
    public float palyerHP;
    public GameObject hand;
    Slider HP;
    
    // Start is called before the first frame update
    void Start()
    {
        HP = GetComponent<Slider>();
        HP.maxValue = hp;
        //hand = this.transform.FindChild("Handle Slie Area/Handle").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        HP.value = palyerHP;
    }

    public void HPhutr()
    {
         palyerHP -= hutr ;
    }

    public void HPblood() 
    {
        palyerHP += blood ;
    }


   }
