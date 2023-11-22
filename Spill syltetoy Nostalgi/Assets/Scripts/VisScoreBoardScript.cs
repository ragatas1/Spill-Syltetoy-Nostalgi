using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VisScoreBoardScript : MonoBehaviour
{
    public TextMeshProUGUI forstePlass;
    public TextMeshProUGUI andrePlass;
    public TextMeshProUGUI tredjePlass;
    public TextMeshProUGUI fjerdePlass;
    public TextMeshProUGUI femtePlass;

    void Start()
    {
        forstePlass.text = PlayerPrefs.GetFloat("1Score").ToString();
        andrePlass.text = PlayerPrefs.GetFloat("2Score").ToString();
        tredjePlass.text = PlayerPrefs.GetFloat("3Score").ToString();
        fjerdePlass.text = PlayerPrefs.GetFloat("4Score").ToString();
        femtePlass.text = PlayerPrefs.GetFloat("5Score").ToString();
    }
}
