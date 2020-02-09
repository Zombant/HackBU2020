using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTrains : MonoBehaviour
{
    public GameObject Train;
    public float TimeBetweenTrains;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("createNewTrain", 0f, TimeBetweenTrains);
    }

    // Update is called once per frame
    void Update() { 
    
        
    }

    public void createNewTrain() {
        Instantiate(Train);
    }

}
