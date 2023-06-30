using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script defines which sprite the 'Player" uses and its health.
/// </summary>

public class Player : MonoBehaviour
{
    public int damage;
    public int health;
    public int numOfHearts;
    public AudioClip damageSound;
    public AudioClip explosionSound;

    public GameObject destructionFX;

    public static Player instance; 

    public GameOverScreen GameOverScreen;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Update() {

        if(health > numOfHearts){
            numOfHearts = health;
        }

        for(int i = 0; i < hearts.Length; i++)
        {
            if(i < health){
                hearts[i].sprite = fullHeart;
            } else{
                hearts[i].sprite = emptyHeart;
            }

            if(i < numOfHearts){
                hearts[i].enabled = true;
            } else{
                hearts[i].enabled = false;
            }
        }
    }

    private void Awake()
    {
        if (instance == null) 
            instance = this;
    }

    //method for damage proceccing by 'Player'
    public void GetDamage(int damage)   
    {
        Instantiate(destructionFX, transform.position, Quaternion.identity);
        health -= damage;
        if(health <= 0) Destruction();
        else SFXManager.instance.PlaySoundFXClip(damageSound, transform, 0.15f);
    }    

    //'Player's' destruction proScedure
    public void Destruction()
    {
        SFXManager.instance.PlaySoundFXClip(explosionSound, transform, 1f);
        Update();
        Instantiate(destructionFX, transform.position, Quaternion.identity); //generating destruction visual effect and destroying the 'Player' object
        Destroy(gameObject);  
        GameOverScreen.Setup(0);
        HighScore.highScore = 0;
    }

}
















