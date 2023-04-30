using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mail : MonoBehaviour
{
    private Animator anim;

    public GameObject sound;

    public SpriteRenderer folder;

    public Sprite closed;

    public void Awake()
    {
        anim = GetComponent<Animator>(); ;
    }

    public void End()
    {
        anim.SetTrigger("end");
        folder.sprite = closed;
        Instantiate(sound, transform.position, Quaternion.identity);
    }

}
