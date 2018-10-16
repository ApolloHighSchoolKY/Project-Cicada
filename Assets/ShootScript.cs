using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour {

    //float bulletTime = 0f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    float refire = 0f;
    bool canFire = true;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1) && canFire)
        {

            var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 15;

            Destroy(bullet, 2.0f);

            canFire = false;
            while (refire < 100)
            {
                refire += Time.deltaTime;
            }
            canFire = true;
        }
    }

}
