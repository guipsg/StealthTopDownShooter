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
    [SerializeField] private bool reloading = false;
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject bulletParticle;

    // Use this for initialization
    void Start()
    {
        ammo = startAmmo;
    }
    private void OnEnable()
    {
        reloading = false;
    }
    // Update is called once per frame
    void Update()
    {
        //Shooting
        if (Input.GetMouseButtonDown(0))
        {
            if (canShoot && !reloading)
            {
                canShoot = false;
                ammo--;
                Instantiate(projectile, transform.position + transform.right, transform.rotation);
                StartCoroutine(ShootDelay());
                Instantiate (bulletParticle, transform.position + transform.right, transform.rotation);
            }
        }
        if (ammo < startAmmo && !reloading)
        {

            if (Input.GetKeyDown(KeyCode.R))
                StartCoroutine(Reload());
        }

        if (ammo <= 0 && !reloading)
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
        reloading = false;
        canShoot = true;
    }
    IEnumerator ShootDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootDelay);
        if (!reloading)
            canShoot = true;
        
    }

}
