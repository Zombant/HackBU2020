using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMove : MonoBehaviour
{
    [SerializeField]
    private GameObject CurrentNode;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = CurrentNode.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "StraightNode") {
            transform.position = col.gameObject.GetComponent<NodeManager>().GetNextNode().transform.position;
            Debug.Log(col.name);
        }
    }
}
