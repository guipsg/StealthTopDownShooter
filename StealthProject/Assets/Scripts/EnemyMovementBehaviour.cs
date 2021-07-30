using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementBehaviour : MonoBehaviour
{
    [SerializeField] private enum State { Waiting, Moving }
    [SerializeField] private State state;
    [SerializeField] private Transform target;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        state = State.Waiting;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Waiting:
                transform.position = transform.position;
                break;
            case State.Moving:
                transform.position = Vector2.Lerp(transform.position, target.position, speed * Time.deltaTime);
                break;
            default:
                break;
        }
    }
}
