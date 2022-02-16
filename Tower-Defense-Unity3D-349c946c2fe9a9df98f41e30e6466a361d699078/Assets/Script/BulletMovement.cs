using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [HideInInspector]
    public Transform targetBullet;
    public float speed;
    public float damage = 5f;


    bool doDamage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // SI PAS DE CIBLE ON NE FAIT RIEN
        if (targetBullet == null)
        {
            Destroy(gameObject);
            return;
        }

        // DEPLACEMENT VERS LA CIBLE
        transform.position = Vector3.MoveTowards(transform.position, targetBullet.position, speed * Time.deltaTime);

        // CALCULE DE LA DISTANCE RESTANTE PAR RAPPORT A LA CIBLE
        float distanceRestante = Vector3.Distance(transform.position, targetBullet.position);

        // SI ON EST ASSEZ PROCHE
        if ( distanceRestante < .5f && !doDamage )
        {
            // ON FAIT PERDRE DES PV A LA CIBLE
            targetBullet.GetComponent<Health>().PerdreDesPV(damage);

            // ON APPLIQUE LES DEGATS
            doDamage = true;

            //ON DETRUIT LA BALLE
            Destroy(gameObject);

        }



    }
}
