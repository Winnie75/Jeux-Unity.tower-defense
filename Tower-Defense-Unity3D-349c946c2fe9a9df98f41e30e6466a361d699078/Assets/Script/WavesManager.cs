using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WavesManager : MonoBehaviour
{
    public static WavesManager instance;


    private void Awake()
    {
        instance = this;
    }

    public GameObject enemyPrefab;
    public List<int> nbreEnemy;
    public float delay = 1f;
    public float timeBetweenWaves = 10f;
    public Text timeText;
    int index;
  
    public int nbrEnemyEnVie;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;


        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        float startTimes = timeBetweenWaves;
        // TANT QUE QU'IL RESTE DES VAGUES A JOUER
        while (index <= nbreEnemy.Count - 1)
        {
            timeBetweenWaves = startTimes;
            timeText.gameObject.SetActive(true);
            // yield return new WaitForSeconds(timeBetweenWaves);
            while (timeBetweenWaves > 0)
            {
                timeText.text = Mathf.Ceil(timeBetweenWaves).ToString();
                timeBetweenWaves -= Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            timeText.gameObject.SetActive(false);

            // NOUVELLE VAGUE
            nbrEnemyEnVie = nbreEnemy[index];


            Transform spawnPoint = WaypointsManager.instance.waypoints[0];


            // TANT QU'IL RESTE DES ENNEMIS A SPAWN
            while (nbreEnemy[index] > 0)
            {

                //ON SPAWN LES ENNEMIS

                Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

                nbreEnemy[index] --;

                yield return new WaitForSeconds(delay);
            }

            while(nbrEnemyEnVie > 0 )
            {
                yield return null;
            }


            Debug.Log("FIN DE VAGUE");

            
            
            // NEXT WAVE
            index++;
        }

        Debug.Log("FIN DU JEU ");
        GameManager.instance.Win();


    }


}
