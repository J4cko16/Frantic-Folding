using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class up : MonoBehaviour
{
    private Transform player;
    public float boxDistance = 1;

    public SpriteRenderer image;
    public Sprite blank;

    public GameObject sound;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Update()
    {
        if (((Vector2.Distance(transform.position, player.position) < boxDistance)))
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Instantiate(sound, transform.position, Quaternion.identity);
                player.GetComponent<dectetor>().Move();
                image.sprite = blank;
            }
        }
    }
}

