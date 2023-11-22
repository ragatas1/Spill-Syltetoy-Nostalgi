using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Mathematics;

public class TimerScript : MonoBehaviour
{
	public TextMeshProUGUI timerText;
	public TextMeshProUGUI highscoreText;

	private float secondsCount;
	public float count;
	public bool vant;
	public float sdfg;

    private void Start()
    {
        OppdaterHighscore();  
    }
    void Update()
	{
		UpdateTimerUI();
		sdfg = PlayerPrefs.GetFloat("HighScore");
	}

	//call this on update
	public void UpdateTimerUI()
	{
		//set timer UI
		if (vant == false)
		{
			secondsCount += Time.deltaTime;
		}
		else
		{
			if (count < PlayerPrefs.GetFloat("HighScore", 0))
			{
				PlayerPrefs.SetFloat("HighScore", count);
				OppdaterHighscore();
			}
		}
        count = Mathf.Round(secondsCount * 10f) * 0.1f;
        timerText.text = count.ToString();

    }
	void OppdaterHighscore()
	{
		highscoreText.text = PlayerPrefs.GetFloat("HighScore",0).ToString();
	}
}
