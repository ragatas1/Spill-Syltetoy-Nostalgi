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
        count = Mathf.Round(secondsCount * 10f) * 0.1f;
        timerText.text = count.ToString();

    }
}
