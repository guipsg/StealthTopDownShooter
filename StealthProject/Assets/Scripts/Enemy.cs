using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private enum Type
    {
        Green,
        Yellow,
        Red
    }
    [SerializeField] private Type enemyType;
    [SerializeField] private int life = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.GetComponent<ProjectileScript>().type.ToString());
        if (collision.gameObject.GetComponent<ProjectileScript>().type.ToString() == enemyType.ToString())
        {
            life--;
        }
    }
}
