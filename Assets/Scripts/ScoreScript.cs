using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public int penalty = 1;

    TextMeshProUGUI scoreText;
    public int scoreValue = 1000;

    public int framePenalty = 600;

    private int frameCount = 0;

    private int curResetCounter = 0;

    // Start is called before the first frame update
    void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        frameCount++;

        if (curResetCounter < ResetPlayer.ResetCounter)
        {
            curResetCounter++;
            scoreValue -= 50;
        }

        if (frameCount > framePenalty)
        {
            scoreValue = scoreValue - penalty;
            scoreText.text = $"Score: {scoreValue}";

            frameCount = 0;
        }
    }
}
