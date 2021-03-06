using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    public Animator animator;
    
    public Slider sliderVie;


    public float health;
    public int gainScore = 10;
    public int gainMoney = 50;

    private void Start()
    {
        //EnemiesManager.instance.enemiesList.Add(transform);
        if (sliderVie)
        {
            sliderVie.maxValue = health;
            sliderVie.value = health;

        }
    }


    private void Update()
    {
        if (sliderVie)
        {
            sliderVie.transform.LookAt(Camera.main.transform);
            sliderVie.transform.Rotate(0, 180, 0);

        }
    }

    public void PerdreDesPV(float _damage)
    {
        //health = health - 1;
        health -=  _damage;

        if(sliderVie)
        {

            sliderVie.value = health;
        }


        if(health <= 0)
        {
            //EnemiesManager.instance.enemiesList.Remove(transform);
            GameManager.instance.AugmenterScore(gainScore);
            WavesManager.instance.nbrEnemyEnVie--;
            GameManager.instance.GagnerPerdreArgent(gainMoney);

            // PLAY DEAD ANIMATION
            if(animator)
            {
                animator.SetTrigger("Mourir");

            }

            // STOP MOVE
            GetComponent<EnemyMovement>().enabled = false;

            // CHANGE LAYER FROM "enemy" TO "default"
            gameObject.layer = 0;

            // DESTROY WITH COOL DOWN
            Destroy(gameObject);
        }

    } 


}
