using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{

    public string NodeType;
    public GameObject PreviousNode;
    public GameObject NextNode;

    //Only for switch nodes
    public int NumberOfOptions;
    public List<GameObject> PossibleSwitchNodes;
    public GameObject SwitchRail;
    public GameObject ActiveNode;

    //Only for platform nodes
    public string PlatformColor;
    public int colorID;
    

    // Start is called before the first frame update
    void Start()
    {
        //Set initial active rail to the first node
        if(NumberOfOptions > 0)
            ActiveNode = PossibleSwitchNodes[1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetNextNode() {
        return NextNode;
    }

    public GameObject GetActiveNode() {
        return ActiveNode;
    }

    //Only for Switch Rails
    public void ToggleActiveRail() {
        if (ActiveNode == PossibleSwitchNodes[0]) {
            ActiveNode = PossibleSwitchNodes[1];
        } else if (ActiveNode == PossibleSwitchNodes[1]) {
            ActiveNode = PossibleSwitchNodes[0];
        }
        
        
    }
}
