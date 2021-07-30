using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerDetection : MonoBehaviour
{
    private Transform player;
    private bool playerNear = false;
    [SerializeField] private GameObject alert;
    private EnemyRotationBehaviour rotationBehaviour;
    private void Start()
    {
        Physics2D.queriesStartInColliders = false;
        rotationBehaviour = GetComponentInParent<EnemyRotationBehaviour>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.transform;
            playerNear = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNear = false;
            rotationBehaviour.foundPlayer = false;
        }
    }
    
    private void Update()
    {
        if (playerNear)
        {
            CheckPlayer(player);
        }
        
    }
    
    public void CheckPlayer(Transform target)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.parent.position, (transform.parent.position - target.transform.position)*-1);

        if (hit.collider.CompareTag("Wall"))
        {
            Debug.DrawLine(transform.parent.position, hit.point, Color.red);
            alert.SetActive(false);
            rotationBehaviour.foundPlayer = false;
        }
        else if (hit.collider.CompareTag("Player"))
        {
            Debug.DrawRay(transform.parent.position, (transform.parent.position - target.transform.position) * -1, Color.green);
            alert.SetActive(true);
            rotationBehaviour.foundPlayer = true;
            DestroyPlayer(0.5f);
        }
    }

    public void DestroyPlayer(float time)
    {
        
        Destroy(player.gameObject,time);
        
    }
}
