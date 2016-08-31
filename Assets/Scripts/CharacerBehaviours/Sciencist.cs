using UnityEngine;
using System.Collections;

public class Sciencist : CharacterBehaviour
{

	// Use this for initialization
	void Start () {

        base.start();

	}
	
	// Update is called once per frame
	void Update () {

        this.horizontalMove();

        this.jump();

        this.animations();

	}

}
