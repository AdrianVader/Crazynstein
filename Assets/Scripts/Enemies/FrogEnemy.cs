using UnityEngine;
using System.Collections;

public class FrogEnemy : Enemy {

    public GameObject _frogDNA;
    public Vector3 _initialPoint;
    public float _timeSinceLastJump;

	// Use this for initialization
	void Start () {
        base.start();

        this._initialPoint = this.transform.position;

        this._timeSinceLastJump = 0;
	}
	
	// Update is called once per frame
	void Update () {
        base.update();

        this.behaviour();

	}

    public void behaviour () {
        const int MAX_VALUE = 100;
        float randomDir = Random.Range(0, MAX_VALUE);

        this._timeSinceLastJump += Time.deltaTime;

        if (this._timeSinceLastJump >= Constants.ENEMY_FROG_TIME_BETWEEN_JUMPS) {
            this._timeSinceLastJump = 0;
            Rigidbody rb = this.GetComponent<Rigidbody>();
            float distanceFromInitialPoint = Vector3.Distance(this._initialPoint, this.transform.position);
            if ((randomDir < (MAX_VALUE / 2) && distanceFromInitialPoint > -Constants.ENEMY_FROG_MAXIMUM_DISTANCE_FROM_INITIAL_POINT) || distanceFromInitialPoint > Constants.ENEMY_FROG_MAXIMUM_DISTANCE_FROM_INITIAL_POINT)
            {

                float randomPower = (randomDir < (MAX_VALUE / 2))? randomDir / (MAX_VALUE / 2) : 1.0f;
                this.transform.localScale = new Vector3(1, 1, 1);
                rb.velocity = new Vector3(randomPower * Constants.ENEMY_FROG_JUMP_HEIGHT, randomPower * Constants.ENEMY_FROG_JUMP_HEIGHT, 0);

            }
            else if ((randomDir >= (MAX_VALUE / 2) && distanceFromInitialPoint < Constants.ENEMY_FROG_MAXIMUM_DISTANCE_FROM_INITIAL_POINT) || distanceFromInitialPoint < -Constants.ENEMY_FROG_MAXIMUM_DISTANCE_FROM_INITIAL_POINT)
            {

                float randomPower = (randomDir >= (MAX_VALUE / 2))? ((randomDir - (MAX_VALUE / 2)) / (MAX_VALUE / 2)) : 1.0f;
                this.transform.localScale = new Vector3(-1, 1, 1);
                rb.velocity = new Vector3(-randomPower * Constants.ENEMY_FROG_JUMP_HEIGHT, randomPower * Constants.ENEMY_FROG_JUMP_HEIGHT, 0);

            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        Damage damage = collider.GetComponent<Damage>();

        if (damage != null)
        {
            this._life -= damage._damage;
        }

        if (this._life <= 0)
        {
            GameObject drop = Instantiate<GameObject>(this._frogDNA);
            drop.transform.position = this.gameObject.transform.position;
            Rigidbody rb = drop.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0, Constants.DROP_JUMP, 0);

            Destroy(this.gameObject);
        }
    }
}
