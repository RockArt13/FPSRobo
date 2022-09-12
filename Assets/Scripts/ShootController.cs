using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{

    public GameObject playerCam;
    public float range = 100f;
    public float damage = 34f;
    public Animator gunAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(gunAnimator.GetBool("isShooting"))
        {
            gunAnimator.SetBool("isShooting", false);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }


    void Shoot()
    {

        gunAnimator.SetBool("isShooting", true);
        RaycastHit hit;

        if(Physics.Raycast(playerCam.transform.position, transform.forward, out hit, range))
        {
            EnemyController enemyController = hit.transform.GetComponent<EnemyController>();
            ItemController itemController = hit.transform.GetComponent<ItemController>();

            if (enemyController != null)
            {
                enemyController.Hit(damage);
            }

            if (itemController != null)
            {
                itemController.Hit(damage);
            }

        }
    }
}



