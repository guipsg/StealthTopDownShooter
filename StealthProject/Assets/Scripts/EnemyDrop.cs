using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    public GameObject drop;
    public int dropAmount = 3;
    public void DropItem()
    {
        for (int i = 0; i < dropAmount; i++)
        {
            Instantiate(drop, transform.position, transform.rotation);
        }
    }
}
