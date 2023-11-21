using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReachEndScript : MonoBehaviour
{
    public GameObject text;
    public TimerScript timer;
    // Start is called before the first frame update
    void Start()
    {
        timer.vant = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        text.SetActive(true);
        Debug.Log(":)");
        timer.vant = true;
    }
}
