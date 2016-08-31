using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public string _behaviourName;
    public float _life;

	// Use this for initialization
	void Start () {

        this._behaviourName = null;
        this._life = Constants.PLAYER_INITIAL_VALUE_LIFE;
	
	}
	
	// Update is called once per frame
	void Update () {

        // TODO: Interact (Constants.PLAYER_INTERACTION)
        // Ask with a ray cast or mouse position if the object is interactive and use it if possible.

	}
}
