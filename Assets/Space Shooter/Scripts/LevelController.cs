using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

#region Serializable classes
[System.Serializable]
public class EnemyWaves 
{
    [Tooltip("Enemy wave's prefab")]
    public GameObject wave;
}

#endregion

public class LevelController : MonoBehaviour {

    //Serializable classes implements
    int score;
    public EnemyWaves[] enemyWaves; 

    public float timeForNewWave;
    public GameObject[] planets;
    public float timeBetweenPlanets;
    public float planetsSpeed;
    public int ws;
    List<GameObject> planetsList = new List<GameObject>();

    Camera mainCamera;   

    private void Start()
    {
        mainCamera = Camera.main;
        StartCoroutine(NewEnemyWave());
        StartCoroutine(PlanetsCreation());
    }

    IEnumerator NewEnemyWave()
    {
        while(Player.instance != null)
        {
        yield return new WaitForSeconds(timeForNewWave);
        ws = Random.Range(0, 6);
        StartCoroutine(CreateEnemyWave(enemyWaves[ws].wave));
        }
    }


    //Create a new wave after a delay
    IEnumerator CreateEnemyWave(GameObject Wave) 
    {
        if(Player.instance != null)
        {
            yield return new WaitForSeconds(1);
            Instantiate(Wave);
        }


    }

    IEnumerator PlanetsCreation()
    {
        //Create a new list copying the arrey
        for (int i = 0; i < planets.Length; i++)
        {
            planetsList.Add(planets[i]);
        }
        yield return new WaitForSeconds(10);
        while (true)
        {
            ////choose random object from the list, generate and delete it
            int randomIndex = Random.Range(0, planetsList.Count);
            GameObject newPlanet = Instantiate(planetsList[randomIndex]);
            planetsList.RemoveAt(randomIndex);
            //if the list decreased to zero, reinstall it
            if (planetsList.Count == 0)
            {
                for (int i = 0; i < planets.Length; i++)
                {
                    planetsList.Add(planets[i]);
                }
            }
            newPlanet.GetComponent<DirectMoving>().speed = planetsSpeed;

            yield return new WaitForSeconds(timeBetweenPlanets);
        }
    }

    
}
