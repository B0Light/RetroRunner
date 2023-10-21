using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Transform layer0;
    [SerializeField] private Transform layer1;
    [SerializeField] private Transform layer2;
    [SerializeField] private Transform layer3;
    [SerializeField] private Transform layer4;
    [SerializeField] private Transform layer5;
    [SerializeField] private Transform layer6;

    private void Update()
    {
        layer0.transform.position -= new Vector3(playerMovement.movementInputDirection.x,0,0).normalized * 1 * Time.deltaTime;
        layer1.transform.position -= new Vector3(playerMovement.movementInputDirection.x,0,0).normalized * 5 * Time.deltaTime;
        layer2.transform.position -= new Vector3(playerMovement.movementInputDirection.x,0,0).normalized * 6 * Time.deltaTime;
        layer3.transform.position -= new Vector3(playerMovement.movementInputDirection.x,0,0).normalized * 3 * Time.deltaTime;
        layer4.transform.position -= new Vector3(playerMovement.movementInputDirection.x,0,0).normalized * 2 * Time.deltaTime;
        layer5.transform.position -= new Vector3(playerMovement.movementInputDirection.x,0,0).normalized * 3 * Time.deltaTime;
        layer6.transform.position -= new Vector3(playerMovement.movementInputDirection.x,0,0).normalized * 1 * Time.deltaTime;
    }
}
