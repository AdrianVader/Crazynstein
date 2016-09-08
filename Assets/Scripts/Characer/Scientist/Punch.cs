using UnityEngine;
using System.Collections;

public class Punch : MonoBehaviour {

    public float _createdTime;
    public float _maximumLifeTime;

	// Use this for initialization
	void Start () {

        this._createdTime = Time.time;
        this._maximumLifeTime = Constants.PLAYER_MAXIMUM_LIFE_TIME_PUNCH;
	
	}
	
	// Update is called once per frame
	void Update () {

        if ((Time.time - this._createdTime) >= this._maximumLifeTime) {
            Destroy(this.gameObject);
        }

	}
}
