using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
	public TextMeshProUGUI timerText;

	private float secondsCount;
	private int minuteCount;
	

	void Update()
	{
		UpdateTimerUI();
	}

	//call this on update
	public void UpdateTimerUI()
	{
		//set timer UI
		secondsCount += Time.deltaTime;
		timerText.text = minuteCount + "m:" + (int)secondsCount + "s";
		if (secondsCount >= 60)
		{
			minuteCount++;
			secondsCount = 0;
		}
		
	}
}
