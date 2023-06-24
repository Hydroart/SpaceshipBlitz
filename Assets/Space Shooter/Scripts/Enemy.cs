using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// This script defines 'Enemy's' health and behavior. 
/// </summary>
public class Enemy : MonoBehaviour {

    #region FIELDS
    [Tooltip("Health points in integer")]
    public int health;
    public int rn;
    public static event Action<int> OnScoreUpdate;
    public int points;
    public int dropChance;
    public int test;

    [Tooltip("Enemy's projectile prefab")]
    public GameObject Projectile;

    [Tooltip("VFX prefab generating after destruction")]
    public GameObject destructionVFX;
    public GameObject hitEffect;

    public AudioClip fireSound;
    public AudioClip hitSound;
    public AudioClip deathSound;
    
    [HideInInspector] public int shotChance; //probability of 'Enemy's' shooting during tha path
    [HideInInspector] public float shotTimeMin, shotTimeMax; //max and min time for shooting from the beginning of the path
    #endregion

    private void Start()
    {
        Invoke("ActivateShooting", UnityEngine.Random.Range(shotTimeMin, shotTimeMax));
    }

    //coroutine making a shot
    void ActivateShooting() 
    {
        if (UnityEngine.Random.value < (float)shotChance / 100)                             //if random value less than shot probability, making a shot
        {                         
            Instantiate(Projectile,  gameObject.transform.position, Quaternion.identity);   
            SFXManager.instance.PlaySoundFXClip(fireSound, transform, 0.8f);          
        }
    }

    //method of getting damage for the 'Enemy'
    public void GetDamage(int damage) 
    {
        health -= damage;           //reducing health for damage value, if health is less than 0, starting destruction procedure
        if (health <= 0)
        {
            Destruction();
            rn = UnityEngine.Random.Range(0, 0);
            SFXManager.instance.PlaySoundFXClip(deathSound, transform, 1f);
        }
        else{
            SFXManager.instance.PlaySoundFXClip(hitSound, transform, 0.5f);
            Instantiate(hitEffect,transform.position,Quaternion.identity,transform);
        }
    }    

     public GameObject drop;//power up drop
     public GameObject drop1;//2nd power up drop

     private void OnDestroy() //on destruction enemies give score and have a chance of dropping poiwer-ups
     {
        if(health <= 0) {
            OnScoreUpdate?.Invoke(points);//points earned

            rn = UnityEngine.Random.Range(0, dropChance);//power-up drops
            if(rn == 0)
            {
                rn = UnityEngine.Random.Range(0, 1);
                if(rn == 0)
                {
                    Instantiate(drop, transform.position, drop.transform.rotation);
                }
                else {
                    Instantiate(drop1, transform.position, drop1.transform.rotation);
                }
            }
        }
     }

    //if 'Enemy' collides 'Player', 'Player' gets the damage equal to projectile's damage value
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Projectile.GetComponent<Projectile>() != null)
                Player.instance.GetDamage(Projectile.GetComponent<Projectile>().damage);
            else
                Player.instance.GetDamage(1);
        }
    }

    //method of destroying the 'Enemy'
    void Destruction()                           
    {
        Instantiate(destructionVFX, transform.position, Quaternion.identity); 
        Destroy(gameObject);
    }
}
