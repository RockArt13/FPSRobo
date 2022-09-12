using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ItemController : MonoBehaviour
{
    public GameObject player;

    public float damageItem = 5f;

    public float healthItem = 15f;

    public static int destroyedItem = 0;


    public void Hit(float damage)
    {
        healthItem -= damage;
        Debug.Log("Item health is " + healthItem);
        if (healthItem <= 0)
        {
            Destroy(gameObject);
            destroyedItem++;
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

       

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            player.GetComponent<PlayerController>().Hit(damageItem);
        }
    }
}
