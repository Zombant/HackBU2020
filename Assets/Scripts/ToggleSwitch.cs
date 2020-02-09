using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSwitch : MonoBehaviour {
    // Start is called before the first frame update

    private bool SwitchActive;
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null && hit.collider.tag == "SwitchRail") {
                hit.collider.gameObject.GetComponent<NodeManager>().ToggleActiveRail();
                ToggleActive();
            }
        }
    }

    void ToggleActive() {
        SwitchActive = !SwitchActive;
        if (SwitchActive) {
            gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
        } else if (!SwitchActive) {
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }
}