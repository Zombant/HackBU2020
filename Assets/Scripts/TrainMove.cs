using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMove : MonoBehaviour
{
    [SerializeField]
    private GameObject CurrentNode;
    [SerializeField]
    private GameObject NextNode;

    public float TrainSpeed;
    public float RotationSpeed;

    public bool isEnabled;
    void Start()
    {
        isEnabled = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (CurrentNode != null && NextNode != null) {
            if (isEnabled) {
                //Move to next node
                transform.position = Vector3.MoveTowards(transform.position, NextNode.transform.position, TrainSpeed * Time.deltaTime);

                //Look at the next node

                Vector3 targetPoint = new Vector3(NextNode.transform.position.x, NextNode.transform.position.y, NextNode.transform.position.z) - transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(targetPoint, Vector3.up);
                targetRotation = new Quaternion(0, 0, targetRotation.z, targetRotation.w);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * RotationSpeed);
            }
            
        }

    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject) {
                isEnabled = !isEnabled;

            }
        }


    }

    void OnTriggerEnter2D(Collider2D col) {
        //Kill train if it touches another train
        if (col.gameObject.tag == "Train") {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<KillTrains>().GameOver();
        }

            //If the train hits a straight node
            if (col.gameObject.tag == "StraightNode") {
                CurrentNode = col.gameObject;
                NextNode = col.gameObject.GetComponent<NodeManager>().GetNextNode();
            } else if (col.gameObject.tag == "SwitchNode") {
                CurrentNode = col.gameObject;
                NextNode = col.gameObject.GetComponent<NodeManager>().GetActiveNode();
            } else if (col.gameObject.tag == "ExitNode") {
                Debug.Log("DESTROYED");
                Destroy(gameObject);
            } else if (col.gameObject.tag == "EntranceNode") {
                CurrentNode = col.gameObject;
                NextNode = col.gameObject.GetComponent<NodeManager>().GetNextNode();
            } else if (col.gameObject.tag == "PlatformNode") {
                CurrentNode = col.gameObject;
                NextNode = col.gameObject.GetComponent<NodeManager>().GetNextNode();
            }
        
    }

    public void SetCurrentNode(GameObject node) {
        CurrentNode = node;
    }

    public void SetNextNode(GameObject node) {
        NextNode = node;
    }
}
