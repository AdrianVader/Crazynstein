using UnityEngine;
using System.Collections;

public class CharacterBehaviour : MonoBehaviour {

	public Animator _animator;
    public bool _ground;

    public Player _player;

    public bool _leftMovementPressed;
    public bool _rightMovementPressed;

    public bool _crouched;

	// Use this for initialization
	void Start () {
	
		this.start();
	}

    protected void start(){
        this._player = this.GetComponent<Player>();

        this._animator = this.GetComponent<Animator>();
        this._ground = true;

        this._leftMovementPressed = false;
        this._rightMovementPressed = false;

        this._crouched = false;
    }
	
	// Update is called once per frame
	void Update () {

        this.update();

	}

    protected void update() {
        this.horizontalMove();

        this.jump();

        this.crouch();
        this.standUp();

        this.animations();
    }

    protected void horizontalMove(){

        Rigidbody rb = this.GetComponent<Rigidbody> ();
        if (Input.GetKeyUp(Constants.PLAYER_MOVE_LEFT_KEY)){this._leftMovementPressed = false;}
        if (Input.GetKeyUp(Constants.PLAYER_MOVE_RIGHT_KEY)){this._rightMovementPressed = false;}
        if (Input.GetKeyDown(Constants.PLAYER_MOVE_LEFT_KEY)){this._leftMovementPressed = true;}
        if (Input.GetKeyDown(Constants.PLAYER_MOVE_RIGHT_KEY)){this._rightMovementPressed = true;}

        if (this._leftMovementPressed && this._rightMovementPressed)
        { // Stay

            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
        }
        else if (this._leftMovementPressed)
        { // Lateral left

            transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
            this._player._lookingRight = false;
            rb.velocity = new Vector3(-this._player._horizontalMovementSpeed, rb.velocity.y, 0f);
        }
        else if (this._rightMovementPressed)
        { // Lateral right

            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            this._player._lookingRight = true;
            rb.velocity = new Vector3(this._player._horizontalMovementSpeed, rb.velocity.y, 0f);
        }
        else
        { // Stay

            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
        }
        /*if (Input.GetKey(Constants.PLAYER_MOVE_LEFT_KEY) && Input.GetKey(Constants.PLAYER_MOVE_RIGHT_KEY))
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
		}*/

    }

    protected void jump() {

        Rigidbody rb = this.GetComponent<Rigidbody>();
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
        if (Input.GetKeyDown(Constants.PLAYER_CROUCH_KEY) && !this._crouched)
        { // Crouch
            this._crouched = true;

            foreach (Transform child in this.gameObject.transform) {
                if (child.name.Equals("Body") || child.name.Equals("Neck") || child.name.Equals("HeadPoint") || child.name.Equals("RightArmPoint") || child.name.Equals("LeftArmPoint"))
                {
                    child.transform.position  = new Vector3(child.transform.position.x, child.transform.position.y - 0.5f, child.transform.position.z);
                }
            }
            this.GetComponent<BoxCollider>().center = new Vector3(this.GetComponent<BoxCollider>().center.x, this.GetComponent<BoxCollider>().center.y - 0.25f, this.GetComponent<BoxCollider>().center.z);
        }
    }

    protected void standUp() {
        if (Input.GetKeyUp(Constants.PLAYER_CROUCH_KEY) && this._crouched)
        { // Stand up
            this._crouched = false;

            foreach (Transform child in this.gameObject.transform)
            {
                if (child.name.Equals("Body") || child.name.Equals("Neck") || child.name.Equals("HeadPoint") || child.name.Equals("RightArmPoint") || child.name.Equals("LeftArmPoint"))
                {
                    child.transform.position = new Vector3(child.transform.position.x, child.transform.position.y + 0.5f, child.transform.position.z);
                }
            }
            this.GetComponent<BoxCollider>().center = new Vector3(this.GetComponent<BoxCollider>().center.x, this.GetComponent<BoxCollider>().center.y + 0.25f, this.GetComponent<BoxCollider>().center.z);
        }
    }

    protected void animations() {

        Rigidbody rb = this.GetComponent<Rigidbody>();
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
