using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skillcontrol : MonoBehaviour
{
    public float playerSkill;
    public bool Skillmax = false;
    Slider Skill;

    // Start is called before the first frame update
    void Start()
    {
        Skill = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        //Skill.value = playerSkill;
        if (Skillmax)
        {
            Skill.value -= Time.deltaTime * 10;
        }
        if (Skill.value <= Skill.minValue)
        {
            Skillmax = false;
        }

    }

    public void Skillvalue()
    {
        Skill.value = Skill.maxValue;
        //Skillmax = true;
    }
    public void UesSkill()
    {
        Skillmax = true;
    }
}
