using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public string tagToDestroy;
    private GameObject[] gameObjects;

    public bool destroySong = true;

    public bool takeOver = false;

    private static Music instance;

    public void Awake()
    {
        if (takeOver == true)
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(instance);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
    
    void Update()
    {
        DontDestroyOnLoad(this.gameObject);

        if(destroySong == true)
        {
            gameObjects = GameObject.FindGameObjectsWithTag(tagToDestroy);

            if (gameObjects.Length == 0)
            {

            }
            else
            {
                Destroy(gameObject);
            }
        } else
        {

        } 
        
    }
}
