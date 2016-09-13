using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Computer : MonoBehaviour {

    public GameObject _player;
    public GameObject _mainMenu;

	// Use this for initialization
	void Start () {

        this._player = GameObject.FindGameObjectWithTag(Constants.PLAYER_TAG);

        foreach (Transform child in this.gameObject.transform) {
            if (child.name.Equals(Constants.COMPUTER_CANVAS_CHILD_NAME)) {
                foreach (Transform canvasChild in child.gameObject.transform)
                {
                    if (canvasChild.name.Equals(Constants.COMPUTER_MAIN_MENU_CHILD_NAME))
                    {
                        this._mainMenu = canvasChild.gameObject;
                    }
                }
            }
        }

	}
	
	// Update is called once per frame
	void Update () {

        // Hide computer's face
        float distance = Mathf.Abs(Vector3.Distance(this._player.transform.position, this.gameObject.transform.position));

        GameObject face = null;
        foreach (Transform child in this.gameObject.transform)
        {
            if (child.name.Equals(Constants.COMPUTERS_FACE_CHILD_NAME))
            {
                face = child.gameObject;
            }
        }

        if (distance > Constants.COMPUTER_MININUM_INTERACTION_DISTANCE) {
            face.SetActive(false);
            this._mainMenu.SetActive(false);
        } else {
            face.SetActive(true);
        }

	}

    void OnMouseEnter() {
        
    }

    void OnMouseExit() {
        
    }

    void OnMouseOver()
    {

        float distance = Mathf.Abs(Vector3.Distance(this._player.transform.position, this.gameObject.transform.position));
        if (Input.GetKeyDown(Constants.PLAYER_USE_KEY) && distance <= Constants.COMPUTER_MININUM_INTERACTION_DISTANCE)
        { // Use

            //List<GameObject> inventory = player.GetComponent<Player>()._inventory;

            // Create menu (GUI) with interaction options.
                // Tip -> Next possible steps to continue your adventure
                // Storage -> Exchange items between your inventory and this device. Use some to change your skills.
                // Research -> Invest your items and resources to create new awesome things or update them.
                // Save -> Saves the game in the current state.


            this._mainMenu.SetActive(true);
            this._player.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));

        }

    }

    public void tip() {
        Debug.Log("THIS IS A TIP!");
        this._mainMenu.SetActive(false);
    }

    public void storage() {
        Debug.Log("THIS IS THE STORAGE!");
        // Unity UI Tutorial - How to make a scrollable list
    }

    public void research()
    {
        Debug.Log("THIS IS THE RESEARCH!");
    }

    public void save()
    {
        Debug.Log("THIS IS THE SAVE GAME BUTTON!");
    }

}
