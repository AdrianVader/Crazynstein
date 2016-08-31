using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public string _behaviourName;
    public float _life;
    public float _horizontalMovementSpeed;
    public float _jumpHeigth;

	// Use this for initialization
	void Start () {

        this._behaviourName = null;

        // Set the tag to player
        this.tag = Constants.PLAYER_TAG;

        // Set the default values
        this._life = Constants.PLAYER_INITIAL_VALUE_LIFE;
        this._horizontalMovementSpeed = Constants.PLAYER_MOVEMENT_SPEED;
        this._jumpHeigth = Constants.PLAYER_JUMP_HEIGTH;
        
	}
	
	// Update is called once per frame
	void Update () {

        // TODO: Interact (Constants.PLAYER_INTERACTION)
        // Ask with a ray cast or mouse position if the object is interactive and use it if possible.

	}
}
