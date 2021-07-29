using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeapoSelector : MonoBehaviour
{
    public WeaponScript[] weapon;
    [SerializeField] private GameObject SelectedWeapon;
    public bool hasGun1,hasGun2,hasGun3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasGun1)
        {
            SelectedWeapon = null;
        }
        if (Input.GetButtonDown("FirstWeapon") && hasGun1)
        {
            weapon[0].gameObject.SetActive(true);
            weapon[1].gameObject.SetActive(false);
            weapon[2].gameObject.SetActive(false);
        }
        else if (Input.GetButtonDown("SecondWeapon") && hasGun2)
        {
            weapon[1].gameObject.SetActive(true);
            weapon[2].gameObject.SetActive(false);
            weapon[0].gameObject.SetActive(false);
        }
        else if (Input.GetButtonDown("ThirdWeapon") && hasGun3)
        {
            weapon[2].gameObject.SetActive(true);
            weapon[1].gameObject.SetActive(false);
            weapon[0].gameObject.SetActive(false);
        }
    }
}
