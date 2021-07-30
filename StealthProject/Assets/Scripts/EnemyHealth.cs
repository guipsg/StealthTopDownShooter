using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private enum Type
    {
        Green,
        Yellow,
        Red
    }
    [SerializeField] private Type enemyType;
    [SerializeField] private int life = 3;
    [SerializeField] private EnemyDrop dropScript;
    // Start is called before the first frame update
    void Start()
    {
        dropScript = GetComponent<EnemyDrop>();
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
            dropScript.DropItem();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<ProjectileScript>().type.ToString() == enemyType.ToString())
        {
            life--;
        }
    }
}
