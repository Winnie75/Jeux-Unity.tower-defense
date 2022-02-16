using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public GameObject tourellePrefab;

    public int cost = 30;

    public LayerMask layerConstruction;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // SI JE CLIC GAUCHE
        if(Input.GetMouseButtonDown(0))
        {
            // RAYON DE LA SOURIS
            RaycastHit hitInfo;
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, 100f, layerConstruction);


            
            

            // if(hit = true)


            if(hit)
            {
                // EST CE QUE MON OBJET A LE BON TAG
                if (hitInfo.transform.tag == "PlaneConstruction")
                {
                    // EST CE QU'ON PEUT CONSTRUIRE
                    if(hitInfo.transform.GetComponent<CheckerBuilder>().canBuild == true )
                    {
                        // EST CE QUE J'AI DE L'ARGENT
                        if (GameManager.instance.money >= cost)
                        {

                            // ON DEUIT DE LE COUT DE LA TOURELLE A NOTRE ARGENT
                            GameManager.instance.GagnerPerdreArgent(-cost);

                            // CREE UN OBJET
                            Instantiate(tourellePrefab, hitInfo.transform.position + offset, Quaternion.identity);

                            // JE NE PEUX PLUS CONSTRUIRE SUR LE CUBE
                            hitInfo.transform.GetComponent<CheckerBuilder>().canBuild = false;
                        }
                    }


                }




            }



        }

    }
}
