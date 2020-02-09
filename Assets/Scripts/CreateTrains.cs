using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTrains : MonoBehaviour
{
    public GameObject Train;
    public float TimeBetweenTrains;

    public bool readyToStart;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if (readyToStart) {
            readyToStart = false;
            InvokeRepeating("createNewTrain", 0f, TimeBetweenTrains);
        }
    }

    public void createNewTrain() {
        Instantiate(Train);
    }

}
