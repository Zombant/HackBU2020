using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainChooseEntrance : MonoBehaviour
{
    [SerializeField]
    private GameObject[] EntranceNodes;


    int EntranceToPick;

    TrainMove trainMove;

    GameObject TheSpotWhereTheRailMountedPassengerCarryingApparatusBeginsItsJourneyForWonderAndDiscovery;

    // Start is called before the first frame update
    void Start()
    {
        TheSpotWhereTheRailMountedPassengerCarryingApparatusBeginsItsJourneyForWonderAndDiscovery = GameObject.FindGameObjectWithTag("TrainCreationLocation");
        transform.position = TheSpotWhereTheRailMountedPassengerCarryingApparatusBeginsItsJourneyForWonderAndDiscovery.transform.position;
        EntranceNodes = GameObject.FindGameObjectsWithTag("EntranceNode");
        trainMove = GetComponent<TrainMove>();
        EntranceToPick = Random.Range(0, EntranceNodes.Length);
        trainMove.SetCurrentNode(EntranceNodes[EntranceToPick]);
        trainMove.SetNextNode(EntranceNodes[EntranceToPick]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
