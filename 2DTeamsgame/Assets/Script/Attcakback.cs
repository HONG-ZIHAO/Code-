using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attcakback : MonoBehaviour
{
    public Transform player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Vector2 difference = collision.transform.position - player.transform.position;
            collision.transform.position = new Vector2(collision.transform.position.x + difference.x, collision.transform.position.y + difference.y);
        }

    }
}
