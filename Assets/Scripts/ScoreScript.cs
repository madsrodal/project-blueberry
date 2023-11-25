using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public int penalty = 1;

    TextMeshProUGUI scoreText;
    public int scoreValue = 1000;

    public int framePenalty = 600;

    private int frameCount = 0;

    // Start is called before the first frame update
    void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        frameCount++;

        if (frameCount > framePenalty)
        {
            scoreValue = scoreValue - penalty;
            scoreText.text = $"Score: {scoreValue}";

            frameCount = 0;
        }
    }
}
