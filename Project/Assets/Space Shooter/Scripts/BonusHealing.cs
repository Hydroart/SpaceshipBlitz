using UnityEngine;

public class BonusHealing : MonoBehaviour {

    //when power-up collides with player, the player is healed
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
