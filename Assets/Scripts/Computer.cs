using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Computer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseEnter() {
        GameObject player = GameObject.FindGameObjectWithTag(Constants.PLAYER_TAG);
        float distance = Mathf.Abs(Vector3.Distance(player.transform.position, this.gameObject.transform.position));
        if (distance <= Constants.COMPUTER_MININUM_INTERACTION_DISTANCE) {
            // Show computer's face
        } else {
            // Hide computer's face
        }
        
    }

    void OnMouseExit() {
        // Hide computer's face
    }

    void OnMouseOver()
    {

        GameObject player = GameObject.FindGameObjectWithTag(Constants.PLAYER_TAG);
        float distance = Mathf.Abs(Vector3.Distance(player.transform.position, this.gameObject.transform.position));
        if (Input.GetKeyDown(Constants.PLAYER_USE_KEY) && distance <= Constants.COMPUTER_MININUM_INTERACTION_DISTANCE)
        { // Use

            List<GameObject> inventory = player.GetComponent<Player>()._inventory;

            // Create menu (GUI) with interaction options.
                // Tip -> Next possible steps to continue your adventure
                // Storage -> Exchange items between your inventory and this device. Use some to change your skills.
                // Research -> Invest your items and resources to create new awesome things or update them.

        }

    }

}
