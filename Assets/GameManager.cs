using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [HideInInspector]
    public TMP_Text scoreText;
    public TMP_Text timer;
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

    public void IncreaseScore()
    {
        scoreNumber++;
        scoreText.text = scoreNumber.ToString();
    }

    public void Test()
    {
        Debug.Log("TESTING");
    }

    
    public IEnumerator Timer()
    {
        //Start game ? init/reset
        while (_timer <= 30)
        {
            if(_timer < 10)
            {
                timer.text = "0" + _timer.ToString();
            }
            else
            {
                timer.text = _timer.ToString();
            }
            _timer++;
            yield return new WaitForSecondsRealtime(1f);
        }
        Debug.Log("DONE");
        //Stop game
    }

    public void CallTimer()
    {
        StartCoroutine("Timer");
    }
}

