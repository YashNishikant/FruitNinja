using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int score;

    private void Start()
    {
        score = 0;
    }

    public void inc() {
        score++;
    }
    public void reset()
    {
        score=0;
    }
    private void Update()
    {
        transform.GetComponent<TextMeshProUGUI>().text = score.ToString();

    }

}
