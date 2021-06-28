using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MPcontrol : MonoBehaviour
{
    public float playerMP;
    Slider MP;

    // Start is called before the first frame update
    void Start()
    {
        MP = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        MP.value = playerMP;
        playerMP += Time.deltaTime*10;
    }
}
