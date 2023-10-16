using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] goal;
    [SerializeField]
    private GameObject[] key;
    public bool[] checkList;

    private void Start()
    {
        goal = GameObject.FindGameObjectsWithTag("Goal");
        key = GameObject.FindGameObjectsWithTag("Key");
        checkList = new bool[goal.Length];
    }

    public IEnumerator ChkCube()
    {
        yield return new WaitForSeconds(.1f);
        int i, j = 0;
        for (i = 0; i < goal.Length; i++)
        {
            checkList[i] = false;
        }

        foreach(var k in goal)
        {
            
            RaycastHit hit;
            Physics.Raycast(k.transform.position, k.transform.forward, out hit, 50f);
            Debug.DrawRay(k.transform.position, k.transform.forward * 100, Color.green);
            if (hit.collider.tag == "Key")
            {
                checkList[j] = true;
                j++;
            }
        }

        for (i = 0; i < goal.Length; i++)
        {
            if (checkList[i] == false)
            {
                break;
            }
        }
        if (i >= goal.Length)
        {
            Debug.Log("Clear");
        }
    }
}
