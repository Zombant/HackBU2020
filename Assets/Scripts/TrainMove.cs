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
            transform.position = Vector3.MoveTowards(transform.position, NextNode.transform.position, TrainSpeed * Time.deltaTime);
        }

    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "StraightNode") {
            CurrentNode = col.gameObject;
            NextNode = col.gameObject.GetComponent<NodeManager>().GetNextNode();
            //transform.position = NextNode.transform.position;
            Debug.Log(col.name);
        }
    }
}
