using UnityEngine;
using System.Collections;

public class SceneCamera : MonoBehaviour {

    public GameObject _player;

	// Use this for initialization
	void Start () {

        this._player = GameObject.FindGameObjectWithTag(Constants.PLAYER_TAG);

	}
	
	// Update is called once per frame
	void Update () {

        if (this._player != null)
        {
            Debug.Log("BEFORE!" + this.transform.position + "   " + this._player.transform.position.x);
            this.transform.position = new Vector3(this._player.transform.position.x, this._player.transform.position.y, this.transform.position.z);
            Debug.Log("AFTER!" + this.transform.position + "   " + this._player.transform.position.x);
        }
        else
        {
            this._player = GameObject.FindGameObjectWithTag(Constants.PLAYER_TAG);
        }

	}
}
