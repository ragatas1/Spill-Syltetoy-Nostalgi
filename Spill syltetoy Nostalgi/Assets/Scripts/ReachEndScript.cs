using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class ReachEndScript : MonoBehaviour
{
    public GameObject text;
    public TimerScript timer;
    public ScoreBoardScript scoreboard;
    // Start is called before the first frame update
    void Start()
    {
        timer.vant = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            scoreboard.ResetScore();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        text.SetActive(true);
        Debug.Log(":)");
        timer.vant = true;
        StartCoroutine (nyScene());
    }
    IEnumerator nyScene()
    {
        yield return new WaitForSeconds(3);
        scoreboard.LagreTid();
        SceneManager.LoadScene("scoreboard");
    }
}
