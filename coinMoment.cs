using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinMoment : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            playerMoment player = collision.gameObject.GetComponent<playerMoment>();
            player.score += 5;
            gameObject.SetActive(false);
        }
    }
}
