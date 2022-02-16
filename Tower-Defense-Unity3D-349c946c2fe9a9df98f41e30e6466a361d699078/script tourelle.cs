using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourelleIA : MonoBehaviour
{
    [Header("SETUP TOURELLE")]
    public LayerMask enemyLayer;
    public Transform partToRotate;
    public Transform firePoint;

    [Header("OPTION DE TIR")]
    public GameObject bulletPrefab;
    public float range;
    public float tempsDeRecharge;

    [Range(0.1f, 5)]
    public float nbrBalleParSeconde = 1f;

    Transform target;

    

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(Tir());
    }

    // Update is called once per frame
    void Update()
    {
        RechercheEnemy();
        
        // SI J'AI UNE CIBLE 
        if(target)
        {
            // JE LA REGARDE
            Vector3 fixPosTarget = new Vector3(
                target.transform.position.x,
                transform.position.y,
                target.transform.position.z
                );

            partToRotate.transform.LookAt(target);

            // JE LUI TIR DESSUS
            

        }

    }

    void RechercheEnemy()
    {
        // SI J'AI DEJA UNE CIBLE
        if(target != null)
        {

            


            // JE CHECK SI MA CIBLE EST TOUJOURS DANS MA RANGE DE TIR
            float distanceTarget = Vector3.Distance(transform.position, target.transform.position);
            
            if(distanceTarget <= range)
            {
                // PAS DE BESOIN DE CHERCHER DE NOUVEL ENNEMI
                return;
            }
            else
            {
                // JE N'AI PLUS DE CIBLE
                target = null;
            }

        }





        // ---------------------------------------------

        // SI JE N'AI PAS DE CIBLE
        // ON RECUPERE TOUS LES ENNMEMIS A PORTEE DANS UNE LISTE
        Collider[] hits = Physics.OverlapSphere(transform.position, range, enemyLayer);

        
        float closestDistance = -1;

        // POUR CHAQUE ENNEMI A DISTANCE
        foreach(Collider c in hits)
        {
            // ON CALCULE LA DISTANCE
            float distance = Vector3.Distance(transform.position, c.transform.position);
            
            // SI JE N'AI PAS ENCORE DE CIBLE OU QUE L'ENNEMI EST PLUS PROCHE QUE LES AUTRES
            if(target == null || distance < closestDistance)
            {
                // CET ENNEMI DEVIENT MA CIBLE
                closestDistance = distance;
                target = c.transform;
            }



        }

    }

    IEnumerator Tir()
    {
        while (true)
        {
            if(target)
            {
                if (target.gameObject.layer != enemyLayer)
                {
                    target = null;
                    yield return null;

                }

                GameObject go = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                go.GetComponent<BulletMovement>().targetBullet = target;

            }

            yield return new WaitForSeconds(1f/nbrBalleParSeconde);

        }

        
    }

}


