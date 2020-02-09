using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverText;
    TextMeshProUGUI textBox;
    // Start is called before the first frame update

    
    void Start() {
        textBox = GameOverText.GetComponent<TextMeshProUGUI>();
        textBox.color = Color.red;
        FindObjectOfType<AudioPlayer>().StopSounds();
        FindObjectOfType<AudioPlayer>().PlaySound("gameover");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
