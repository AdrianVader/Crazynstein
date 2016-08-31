using UnityEngine;
using System.Collections;

public class Frog : CharacterBehaviour
{

	// Use this for initialization
	void Start () {

        base.start();

        if (this._player != null)
        {

            this._player._life += 5.0f;
            this._player._jumpHeigth += 2.0f;

        }
	
	}
	
	/*// Update is called once per frame
	void Update () {
	


	}*/

    void OnDestroy() {

        if (this._player != null)
        {

            this._player._life -= 5.0f;
            this._player._jumpHeigth -= 2.0f;

        }

    }

}
