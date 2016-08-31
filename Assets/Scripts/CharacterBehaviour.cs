using UnityEngine;
using System.Collections;

public class CharacterBehaviour : MonoBehaviour {

	public Animator _animator;
    public bool _ground;

	// Use this for initialization
	void Start () {
	
		this._animator = GetComponent<Animator>();
        this._ground = true;
	}
	
	// Update is called once per frame
	void Update () {
        
		Rigidbody rb = GetComponent<Rigidbody> ();
        if (Input.GetKey(Constants.PLAYER_MOVE_LEFT) && Input.GetKey(Constants.PLAYER_MOVE_RIGHT))
        { // Stay

			rb.velocity = new Vector3 (0f, rb.velocity.y, 0f);
        } else if (Input.GetKey(Constants.PLAYER_MOVE_LEFT))
        { // Lateral left
			
			transform.rotation = new Quaternion(0f,180f,0f,0f);
			rb.velocity = new Vector3 (-5f, rb.velocity.y, 0f);
        } else if (Input.GetKey(Constants.PLAYER_MOVE_RIGHT))
        { // Lateral right
			
			transform.rotation = new Quaternion(0f,0f,0f,0f);
			rb.velocity = new Vector3 (5f, rb.velocity.y, 0f);
		} else { // Stay
			
			rb.velocity = new Vector3 (0f, rb.velocity.y, 0f);
		}

		if (Input.GetKeyDown(Constants.PLAYER_JUMP)) { // Jump

			if(rb.velocity.y <= 0f && this._ground){
                this._ground = false;
				rb.velocity += new Vector3 (0f, 5f, 0f);
			}
		}

		float move = rb.velocity.x;
		float jump = rb.velocity.y;
        this._animator.SetFloat(Constants.PLAYER_ANIMATION_VARIABLE_SPEED, move);
        this._animator.SetFloat(Constants.PLAYER_ANIMATION_VARIABLE_JUMP, jump);
        this._animator.SetBool(Constants.PLAYER_ANIMATION_VARIABLE_GROUND, this._ground);

	}


    void OnTriggerEnter(Collider other) {
        this._ground = true;
    }
}
