using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{

    public GameObject player;

    public Animator enemyAnimator;

    public float damage = 12f;

    public float health = 100f;

    public GameManager gameManager;

    public static int killedEnemies = 0;

   


    public void Hit(float damage)
    {
        health -= damage;


        if(health <= 0)
        {
            this.health = 1000;
            gameManager.enemiesCount--;
            enemyAnimator.SetBool("isDying", true);
            this.GetComponent<NavMeshAgent>().isStopped = true;
            Destroy(gameObject,2.0f);
            killedEnemies++;
        }    
    }


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = player.transform.position;

        if(GetComponent<NavMeshAgent>().velocity.magnitude > 1)
        {
            enemyAnimator.SetBool("isRunning", true);
        }
        else
        {
            enemyAnimator.SetBool("isRunning", false);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == player)
        {
            player.GetComponent<PlayerController>().Hit(damage);
        }
    }
}
