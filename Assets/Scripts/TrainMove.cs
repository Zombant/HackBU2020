using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMove : MonoBehaviour
{
    [SerializeField]
    private GameObject CurrentNode;
    private GameObject NextNode;

    public float TrainSpeed;
    public float RotationSpeed;
    void Start()
    {
        transform.position = CurrentNode.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (NextNode != null) {
            //Move to next node
            transform.position = Vector3.MoveTowards(transform.position, NextNode.transform.position, TrainSpeed * Time.deltaTime);

            //Look at the next node
            Vector3 targetPoint = new Vector3(NextNode.transform.position.x, NextNode.transform.position.y, NextNode.transform.position.z) - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint, Vector3.up);
            targetRotation = new Quaternion(0, 0, targetRotation.z, targetRotation.w);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * RotationSpeed);
        }

    }

    void OnTriggerEnter2D(Collider2D col) {
        //If the train hits a straight node
        if(col.gameObject.tag == "StraightNode") {
            CurrentNode = col.gameObject;
            NextNode = col.gameObject.GetComponent<NodeManager>().GetNextNode();
            Debug.Log(col.name);
        } else if(col.gameObject.tag == "SwitchNode") {
            CurrentNode = col.gameObject;
            NextNode = col.gameObject.GetComponent<NodeManager>().GetActiveNode();
        } else if(col.gameObject.tag == "ExitNode") {
            Debug.Log("DESTROYED");
            Destroy(gameObject);
        }
    }
}
