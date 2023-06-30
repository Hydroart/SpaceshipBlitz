using UnityEngine;

public class BonusFireRate : MonoBehaviour {


    //when colliding with another object, if another objct is 'Player', sending command to the 'Player'
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Player") 
        {
            Destroy(gameObject);
            
            PlayerShooting.instance.fireRate += 0.5f;
            
        }
    }
}