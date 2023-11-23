using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGreier : MonoBehaviour
{
    public MusicPlayer musikk;
    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("start"))
        {
            musikk.spillAvMusikk();
            SceneManager.LoadScene("sonic");
        }
    }
}
