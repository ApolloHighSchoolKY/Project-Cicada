using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{

    //float bulletTime = 0f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float cooldownTime;
    public int bulletSpeed;
    float cooldown;
    public int maxAmmo;
    int ammo;

    // Update is called once per frame
    private void Awake()
    {
        ammo = maxAmmo;
        cooldown = cooldownTime;
    }

    void Update()
    {
        if (Input.GetMouseButton(1) && cooldown > cooldownTime && ammo > 0)
            {
                Fire();
                ammo--;
            }
        else if (ammo == 0 && cooldown > cooldownTime)
            {
                ammo = maxAmmo;
                cooldown = -1f;
        }
        cooldown += Time.deltaTime;
    }

    void Fire()
    {
        cooldown = 0;
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        Debug.Log("test");

        Destroy(bullet, 2.0f);

    }
}
