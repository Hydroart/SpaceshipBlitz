﻿using UnityEngine;

public class Bonus1 : MonoBehaviour {

    //when colliding with another object, if another objct is 'Player', sending command to the 'Player'
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Player") 
        {
            Destroy(gameObject);
            if(Player.instance.health <= 4){
                Player.instance.health++;
            }
        }
    }
}
