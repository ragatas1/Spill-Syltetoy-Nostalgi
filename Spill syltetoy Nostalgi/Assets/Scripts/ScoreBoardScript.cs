using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoardScript : MonoBehaviour
{
    public TimerScript timer;
    private float ny2Score;
    private float ny3Score;
    private float ny4Score;
    private float ny5Score;

    public void LagreTid()
    {
        if (timer.count < PlayerPrefs.GetFloat("1Score"))
            {
                ny2Score = PlayerPrefs.GetFloat("1Score");
                PlayerPrefs.SetFloat("1Score", timer.count);

                ny3Score = PlayerPrefs.GetFloat("2Score");
                PlayerPrefs.SetFloat("2Score", ny2Score);

                ny4Score = PlayerPrefs.GetFloat("3Score");
                PlayerPrefs.SetFloat("3Score", ny3Score);

                ny5Score = PlayerPrefs.GetFloat("4Score");
                PlayerPrefs.SetFloat("4Score", ny4Score);

                PlayerPrefs.SetFloat("5Score", ny5Score);
            }
            else if (timer.count < PlayerPrefs.GetFloat("2Score"))
            {
                ny3Score = PlayerPrefs.GetFloat("2Score");
                PlayerPrefs.SetFloat("2Score", timer.count);

                ny4Score = PlayerPrefs.GetFloat("3Score");
                PlayerPrefs.SetFloat("3Score", ny3Score);

                ny5Score = PlayerPrefs.GetFloat("4Score");
                PlayerPrefs.SetFloat("4Score", ny4Score);

                PlayerPrefs.SetFloat("5Score", ny5Score);
            }
            else if (timer.count < PlayerPrefs.GetFloat("3Score"))
            {
                ny4Score = PlayerPrefs.GetFloat("3Score");
                PlayerPrefs.SetFloat("3Score", timer.count);

                ny5Score = PlayerPrefs.GetFloat("4Score");
                PlayerPrefs.SetFloat("4Score", ny4Score);

                PlayerPrefs.SetFloat("5Score", ny5Score);
            }
            else if (timer.count < PlayerPrefs.GetFloat("4Score"))
            {
                ny5Score = PlayerPrefs.GetFloat("4Score");
                PlayerPrefs.SetFloat("4Score", timer.count);

                PlayerPrefs.SetFloat("5Score", ny5Score);
            }
            else if (timer.count < PlayerPrefs.GetFloat("5Score"))
            {
                PlayerPrefs.SetFloat("5Score", timer.count);
            }
    }
    public void ResetScore()
    {
        PlayerPrefs.SetFloat("1Score", 999);
        PlayerPrefs.SetFloat("2Score", 999);
        PlayerPrefs.SetFloat("3Score", 999);
        PlayerPrefs.SetFloat("4Score", 999);
        PlayerPrefs.SetFloat("5Score", 999);

    }
}
