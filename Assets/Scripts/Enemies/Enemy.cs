using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float _life;

	// Use this for initialization
	void Start () {
	    this.start();
	}

    protected void start() {
        this._life = Constants.ENEMY_FROG_LIFE;
    }
	
	// Update is called once per frame
	void Update () {
        this.update();
	}

    protected void update() {

    }

}
