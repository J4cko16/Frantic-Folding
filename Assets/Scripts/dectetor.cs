using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class dectetor : MonoBehaviour
{
    private Vector2 targetPos;

    public float movementDistance = 2;

    public int inputNumber = 4;

    public float Countdown;

    private float startCountdown;

    public Slider timerSlider;

    private int currentInputs = 0;
    private int currentPattern = 1;

    public Transform startPos;

    public GameObject pattern1;
    public GameObject pattern2;
    public GameObject pattern3;
    public GameObject pattern4;
    public GameObject pattern5;

    private int Score;

    public bool ResetScore;
    public bool has5Patterns = false;

    private Transform mail;

    public Text scoreDisplay;

    private bool timerStop = false;

    public string nextScene;

    private bool Died = false;

    public GameObject panel;

    public void Start()
    {
        startCountdown = Countdown;
        
        if (ResetScore == true)
        {
            PlayerPrefs.SetInt("Score", 0);
        }

        Score = PlayerPrefs.GetInt("Score", 0);

        scoreDisplay.text = (PlayerPrefs.GetInt("Score", 0).ToString());

        currentInputs = 0;

        mail = GameObject.FindGameObjectWithTag("mail").transform;
    }

    public void Update()
    {
        if(currentInputs == inputNumber)
        {
            timerStop = true;
            StartCoroutine(End());
        }

        if (Countdown > 0)
        {
            if(timerStop == false)
            {
                Countdown -= Time.deltaTime;
            }
            timerSlider.value = Countdown;
}
        else if (Died == false) //activate "died" when death animation is over
        {
            StartCoroutine(fireddd());
        }

        if (Died == true)
        {
            SceneManager.LoadScene("fired");
        }
    }

    public IEnumerator fireddd()
    {
        panel.SetActive(true);
        GameObject[] music = GameObject.FindGameObjectsWithTag("Music");
        foreach (GameObject item in music)
            GameObject.Destroy(item);
        yield return new WaitForSeconds(.5f);
        Died = true;
    }

    public IEnumerator End()
    {
        currentInputs = 0;
        mail.GetComponent<mail>().End();

        Score = Score + 1;
        PlayerPrefs.SetInt("Score", (int)Score);

        scoreDisplay.text = (PlayerPrefs.GetInt("Score", 0).ToString());

        yield return new WaitForSeconds(1f);

        GameObject[] arrows = GameObject.FindGameObjectsWithTag("arrow");
        foreach (GameObject item in arrows)
            GameObject.Destroy(item);

        if (currentPattern == 1)
        {
            pattern2.SetActive(true);
            pattern1.SetActive(false);
        }

        if (currentPattern == 2)
        {
            pattern2.SetActive(false);
            pattern3.SetActive(true);
        }

        if (currentPattern == 3)
        {
            pattern3.SetActive(false);
            pattern4.SetActive(true);
        }

        if (currentPattern == 4)
        {
            if(has5Patterns == false)
            {
                SceneManager.LoadScene(nextScene);
            } else
            {
                pattern4.SetActive(false);
                pattern5.SetActive(true);
            }
                
        }

        if (currentPattern == 5)
        {
            SceneManager.LoadScene(nextScene);
        }

        mail = GameObject.FindGameObjectWithTag("mail").transform;

        targetPos = startPos.position;
        transform.position = targetPos;

        currentPattern = currentPattern + 1;

        Countdown = startCountdown;
        timerStop = false;
    }

    public IEnumerator Moves()
    {
        yield return new WaitForSeconds(.02f);

        targetPos = new Vector2(transform.position.x + movementDistance, transform.position.y);
        transform.position = targetPos;

        currentInputs = currentInputs + 1;
    }

    public void Move()
    {
        StartCoroutine(Moves());
    }
}
