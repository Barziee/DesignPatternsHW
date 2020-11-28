using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [HideInInspector]
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public BoxCollider bc;
    public int scoreNumber = 0;
    float _timer;

    private void Awake()
    {
        Instance = this;
        scoreText = GetComponent<TMP_Text>();
        Invoke("Test", 5f);
        _timer = 0;
    }

    public void ScoreCounter()
    {
        scoreNumber++;
        scoreText.text = scoreNumber.ToString();
    }

    public IEnumerator Timer()
    {
        while (_timer <= 30)
        {
            if(_timer < 10)
            {
                timerText.text = "0" + _timer.ToString();
            }
            else
            {
                timerText.text = _timer.ToString();
            }
            _timer++;
            yield return new WaitForSecondsRealtime(1f);
        }
        Debug.Log("30 Seconds are gone!");
    }

    public void CallTimer()
    {
        StartCoroutine("Timer");
    }
}

