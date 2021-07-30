using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotationBehaviour : MonoBehaviour
{
    public enum Style { OneDirection, TwoDirections,FourDirections,Corner }
    public Style style;
    public float timeDelay = 3f;
    public bool foundPlayer = false;
    public bool beginOnStart = false;
    public bool isRotating = false;
    [SerializeField] private Vector3 newRotation;
    private Vector3 startRotation;
    private Transform player;
    public Transform view;
    private void Start()
    {
        if (beginOnStart)
        {
            StartCoroutine(ChangeDirection(timeDelay));
        }
        newRotation = view.eulerAngles;
        startRotation = view.localEulerAngles;
    }

    private void Update()
    {
        if (foundPlayer)
        {
            player = GameObject.Find("Player").transform;
            view.up = (player.position - view.position) *-1;
            newRotation = view.eulerAngles;
        }
        else
        {
            //view.localEulerAngles = Vector3.Lerp(view.rotation,newRotation,1f*Time.deltaTime);
            view.localEulerAngles = newRotation;
        }
    }
    public void RotateView( Style _style)
    {
        switch (_style)
        {
            case Style.OneDirection:
                newRotation = view.eulerAngles;
                break;
            case Style.TwoDirections:
                
                if (newRotation.z <= startRotation.z + 360f)
                {
                    newRotation = view.localEulerAngles + new Vector3(0, 0, 180f);
                }
                if (newRotation.z > startRotation.z + 360f)
                {
                    newRotation = view.localEulerAngles - new Vector3(0, 0, 360f);
                }

                break;
            case Style.FourDirections:
                if (newRotation.z <= startRotation.z + 360f)
                {
                    newRotation = view.localEulerAngles + new Vector3(0, 0, 90f);
                }
                if (newRotation.z > startRotation.z + 360f)
                {
                    newRotation = view.localEulerAngles - new Vector3(0, 0, 360f);
                }
                break;
            case Style.Corner:
                if (newRotation.z <= startRotation.z + 90f)
                {
                    newRotation = view.localEulerAngles + new Vector3(0, 0, 45f);
                }
                if (newRotation.z > startRotation.z + 90f)
                {
                    newRotation = view.localEulerAngles - new Vector3(0, 0, 90f);
                }

                break;
            default:
                break;
        }
    }

    IEnumerator ChangeDirection(float _timeDelay) 
    {
        if (!foundPlayer)
        {
            yield return new WaitForSecondsRealtime(_timeDelay);
            RotateView(style);
            StartCoroutine(ChangeDirection(timeDelay));
        }
    }

    
}
