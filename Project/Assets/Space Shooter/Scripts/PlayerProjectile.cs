using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    private int playerDamage;

    private void Start()
    {
        playerDamage = Player.instance.damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().GetDamage(playerDamage);
            Destruction();
        }
    }

    private void Destruction()
    {
        Destroy(gameObject);
    }
}
