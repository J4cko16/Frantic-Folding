using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private string sceneTitle;
    public float time;
    
    public void sceneChange(string sceneName)
    {
        sceneTitle = sceneName;        
        StartCoroutine(Change());
    }

    public IEnumerator Change()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(sceneTitle);
    }

    public void destoryMusic()
    {
        GameObject[] music = GameObject.FindGameObjectsWithTag("titleMusic");
        foreach (GameObject item in music)
            GameObject.Destroy(item);
    }
}
