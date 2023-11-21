using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Mathematics;

public class TimerScript : MonoBehaviour
{
	public TextMeshProUGUI timerText;

	private float secondsCount;
	private float count;
	private int minuteCount;
	public bool vant;
	

	void Update()
	{
		UpdateTimerUI();
	}

	//call this on update
	public void UpdateTimerUI()
	{
		//set timer UI
		if (vant == false)
		{
			secondsCount += Time.deltaTime;
			count = Mathf.Round(secondsCount * 10f) * 0.1f;
			timerText.text = count.ToString();
		}
    }
}
