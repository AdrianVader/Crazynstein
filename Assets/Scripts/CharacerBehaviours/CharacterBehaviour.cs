using UnityEngine;
using System.Collections;

public class CharacterBehaviour : MonoBehaviour {

	public Animator _animator;
    public bool _ground;

    public Player _player;

	// Use this for initialization
	void Start () {
	
		this.start();
	}

    protected void start(){
        this._player = this.GetComponent<Player>();

        this._animator = this.GetComponent<Animator>();
        this._ground = true;
    }
	
	// Update is called once per frame
	void Update () {

        this.horizontalMove();

        this.jump();

        this.crouch();

        this.use();

        this.animations();

	}

    protected void horizontalMove(){

        Rigidbody rb = GetComponent<Rigidbody> ();
        if (Input.GetKey(Constants.PLAYER_MOVE_LEFT_KEY) && Input.GetKey(Constants.PLAYER_MOVE_RIGHT_KEY))
        { // Stay

			rb.velocity = new Vector3 (0f, rb.velocity.y, 0f);
        }
        else if (Input.GetKey(Constants.PLAYER_MOVE_LEFT_KEY))
        { // Lateral left
			
			transform.rotation = new Quaternion(0f,180f,0f,0f);
            this._player._lookingRight = false;
            rb.velocity = new Vector3(-this._player._horizontalMovementSpeed, rb.velocity.y, 0f);
        }
        else if (Input.GetKey(Constants.PLAYER_MOVE_RIGHT_KEY))
        { // Lateral right
			
			transform.rotation = new Quaternion(0f,0f,0f,0f);
            this._player._lookingRight = true;
            rb.velocity = new Vector3(this._player._horizontalMovementSpeed, rb.velocity.y, 0f);
		} else { // Stay
			
			rb.velocity = new Vector3 (0f, rb.velocity.y, 0f);
		}

    }

    protected void jump() {

        Rigidbody rb = GetComponent<Rigidbody>();
        if (Input.GetKeyDown(Constants.PLAYER_JUMP_KEY))
        { // Jump

            if (rb.velocity.y <= 0f && this._ground)
            {
                this._ground = false;
                rb.velocity += new Vector3(0f, this._player._jumpHeigth, 0f);
            }
        }

    }

    protected void crouch() {
        if (Input.GetKeyDown(Constants.PLAYER_CROUCH_KEY))
        { // Crouch

            Debug.Log("You pressed " + Constants.PLAYER_CROUCH_KEY);
            foreach (Transform child in this.gameObject.transform) {
                Debug.Log(child.name);
            }
        }
    }

    protected void use() {
        if (Input.GetKeyDown(Constants.PLAYER_USE_KEY))
        { // Use

            Debug.Log("You pressed " + Constants.PLAYER_USE_KEY);
        }
    }

    protected void animations() {

        Rigidbody rb = GetComponent<Rigidbody>();
        float move = rb.velocity.x;
        float jump = rb.velocity.y;
        this._animator.SetFloat(Constants.PLAYER_ANIMATION_VARIABLE_SPEED, move);
        this._animator.SetFloat(Constants.PLAYER_ANIMATION_VARIABLE_JUMP, jump);
        this._animator.SetBool(Constants.PLAYER_ANIMATION_VARIABLE_GROUND, this._ground);

    }

    void OnTriggerEnter(Collider collider) {

        if (collider.tag == Constants.GROUND_TAG)
        {
            this._ground = true;
        }

    }
}
