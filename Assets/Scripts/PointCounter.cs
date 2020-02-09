using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointCounter : MonoBehaviour
{

    public int Score;
    public int PointsPerTrain;
    public int MaxScore;

    public GameObject ScoreCounter;
    TextMeshProUGUI textBox;
    // Start is called before the first frame update
    void Start()
    {
        textBox = ScoreCounter.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textBox.SetText(Score.ToString());
        
    }

    public void AddPoints() {
        if(Score < MaxScore)
            Score += PointsPerTrain;
    }
    public void RemovePoints() {

        int tempScore = Score;
        if (tempScore >= 0)
            tempScore -= PointsPerTrain / 2;
        if(tempScore < 0) {
            Score = 0;
        } else {
            Score = tempScore;
        }
    }
}
