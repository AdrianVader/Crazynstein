using UnityEngine;
using System.Collections;

public class Punch : MonoBehaviour {

    public float _createdTime;
    public float _maximumLifeTime;

	// Use this for initialization
	void Start () {

        this._createdTime = Time.time;
        this._maximumLifeTime = Constants.PLAYER_MAXIMUM_LIFE_TIME_PUNCH;

        this.gameObject.AddComponent<Damage>();
        this.gameObject.GetComponent<Damage>()._damage = Constants.PLAYER_SCIENTIST_PUNCH_DAMAGE;
	
	}
	
	// Update is called once per frame
	void Update () {

        if ((Time.time - this._createdTime) >= this._maximumLifeTime) {
            Destroy(this.gameObject);
        }

	}
}
