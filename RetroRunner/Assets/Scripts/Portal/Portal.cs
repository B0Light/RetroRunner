using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private GameObject puzzle;
    [SerializeField] private GameObject puzzleCam;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SetPuzzleCam();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ResetPuzzleCam();
        }
    }

    private void SetPuzzleCam()
    {
        puzzleCam.SetActive(true);
    }

    private void ResetPuzzleCam()
    {
        puzzleCam.SetActive(false);
    }
}
