using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishTimer : MonoBehaviour
{
    private float currentTime = 0f;
    private float startingTime = 10f;
    public bool timerWorking = false;

    [SerializeField]
    private Text countdownText;
    public void ResetTimer()
    {
        currentTime = startingTime;
    }

    private void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        if (timerWorking)
        {
            currentTime -= 1 * Time.deltaTime;
            countdownText.text = $"Bean reached META. Level will end in {currentTime:0} seconds...";

            if (currentTime <= 0)
            {
                timerWorking = false;
                FindObjectOfType<LoadLevel>().LoadNextLevel();
            }
        }
    }
}
