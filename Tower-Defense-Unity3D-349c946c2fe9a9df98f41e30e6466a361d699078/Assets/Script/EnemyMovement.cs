using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public Vector3 offset;

    public float speed;

    int index;

    private void Start()
    {
        index = 1;

        transform.position += offset;
    }

    // Update is called once per frame
    void Update()
    {
        Deplacement();

        BetterLookAt();
        

    }

    void BetterLookAt()
    {
        Transform nextPoint = WaypointsManager.instance.waypoints[index];

        Vector3 fixedPosition = new Vector3(
            nextPoint.position.x, 
            transform.position.y, 
            nextPoint.position.z);

        transform.LookAt(fixedPosition);
    }


    private void Deplacement()
    {
        transform.position = Vector3.MoveTowards(transform.position, WaypointsManager.instance.waypoints[index].position + offset, speed * Time.deltaTime);

        float distance = Vector3.Distance(transform.position, WaypointsManager.instance.waypoints[index].position + offset);


        if (distance <= .1f)
        {

            // SI ON ARRIVE A LA FIN

            if (index >= WaypointsManager.instance.waypoints.Count - 1)
            {
                WavesManager.instance.nbrEnemyEnVie--;
                
                GameManager.instance.PerdreVie(1);

                Destroy(gameObject);
                return;
            }

            index++;
        }
    }
}
