using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputRandom : MonoBehaviour
{
    public GameObject[] arrowDirectionObjects;

    public void Start()
    {
        int rand = Random.Range(0, arrowDirectionObjects.Length);
        Instantiate(arrowDirectionObjects[rand], transform.position, Quaternion.identity);
    }
}
