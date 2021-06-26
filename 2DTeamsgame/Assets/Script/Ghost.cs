using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float ghostDelay;
    private float ghostDelaySeconds;
    public GameObject ghost;
    public bool makeGhost = false;
    // Start is called before the first frame update
    void Start()
    {
        ghostDelay = ghostDelaySeconds;
    }

    // Update is called once per frame
    void Update()
    {
        if (makeGhost)
        {
            if (ghostDelaySeconds > 0)
            {
                ghostDelaySeconds -= Time.deltaTime;
            }
            else
            {
                GameObject currentghost = Instantiate(ghost, transform.position, transform.rotation);
                Sprite currentSprite = GetComponent<SpriteRenderer>().sprite;
                currentghost.GetComponent<SpriteRenderer>().sprite = currentSprite;
                currentghost.transform.localScale = this.transform.localScale;//
                ghostDelaySeconds = ghostDelay;
                Destroy(currentghost, 0.5f);
            }
        }
    }
}
