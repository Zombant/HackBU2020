using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTrains : MonoBehaviour
{
    public GameObject GameOverPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver() {
        GameObject[] trains = GameObject.FindGameObjectsWithTag("Train");
        foreach(GameObject train in trains) {
            Destroy(train);
        }
        Instantiate(GameOverPrefab);
    }
}
