using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WeaponScript : MonoBehaviour
{
    [SerializeField]
    private enum Type
    {
        Green,
        Yellow,
        Red
    }
    [SerializeField] private Type type;
    [SerializeField] private int ammo;
    [SerializeField] private int startAmmo = 5;
    [SerializeField] private float shootDelay = 0.1f;
    [SerializeField] private float reloadSpeed = 2f;
    [SerializeField] private bool canShoot = true;
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject bulletParticle;
    private bool reloading = false;

    // Use this for initialization
    void Start()
    {
        ammo = startAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        //Shooting
        if (Input.GetMouseButtonDown(0))
        {
            if (canShoot == true)
            {
                ammo--;
                Instantiate(projectile, transform.position, transform.rotation);
                StartCoroutine(ShootDelay());
                //Instantiate (bulletParticle, gun.position, gun.rotation);
            }
        }
        if (ammo < startAmmo)
        {

            if (Input.GetKeyDown(KeyCode.R))
                StartCoroutine(Reload());
        }

        if (ammo == 0)
        {
            canShoot = false;
            StartCoroutine(Reload());
        }

    }

    IEnumerator Reload()
    {
        canShoot = false;
        reloading = true;
        yield return new WaitForSeconds(reloadSpeed);
        ammo = startAmmo;
        canShoot = true;
        reloading = false;
    }
    IEnumerator ShootDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }

}
