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

    public string color;

    GameObject GameManager;

    private bool isFinished;

    

    // Start is called before the first frame update
    void Start()
    {
        isFinished = false;
        GameManager = GameObject.FindGameObjectWithTag("GameManager");

        TheSpotWhereTheRailMountedPassengerCarryingApparatusBeginsItsJourneyForWonderAndDiscovery = GameObject.FindGameObjectWithTag("TrainCreationLocation");
        transform.position = TheSpotWhereTheRailMountedPassengerCarryingApparatusBeginsItsJourneyForWonderAndDiscovery.transform.position;
        EntranceNodes = GameObject.FindGameObjectsWithTag("EntranceNode");
        trainMove = GetComponent<TrainMove>();
        EntranceToPick = Random.Range(0, EntranceNodes.Length);
        trainMove.SetCurrentNode(EntranceNodes[EntranceToPick]);
        trainMove.SetNextNode(EntranceNodes[EntranceToPick]);

        int colorID;
        if(EntranceNodes[EntranceToPick].GetComponent<NodeManager>().colorID == 3) {
            colorID = Random.Range(0, 3);
        } else {
            colorID = Random.Range(0, 4);
        }

        
        switch (colorID) {
            case 0:
                color = "yellow";
                gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                break;
            case 1:
                color = "blue";
                gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            case 2:
                color = "red";
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case 3:
                color = "green";
                gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<NodeManager>() == null)
            return;
        if(collision.gameObject.GetComponent<NodeManager>().PlatformColor == color && !isFinished) {
            isFinished = true;
            GameManager.GetComponent<PointCounter>().AddPoints();
            gameObject.GetComponent<TrainMove>().isEnabled = false;
            transform.rotation = Quaternion.identity;
            Invoke("EnableTrain", 1f);
        }
        if(collision.gameObject.GetComponent<NodeManager>().NodeType == "exit" && isFinished == false) {
            GameManager.GetComponent<PointCounter>().RemovePoints();
        }
    }

    public void EnableTrain() {
        gameObject.GetComponent<TrainMove>().isEnabled = true;
        
    }
}
