using UnityEngine;
using System.Collections;

public class Sciencist : CharacterBehaviour
{

    public float _lastAttack;
    public float _attackSpeed;

	// Use this for initialization
	void Start () {

        base.start();

        this._attackSpeed = 0.5f;
        this._lastAttack = Time.time;

	}
	
	// Update is called once per frame
	void Update () {

        this.horizontalMove();

        this.jump();

        this.animations();

        this.punch();

	}

    protected void punch() {

        if (Input.GetMouseButtonDown(0) && (Time.time - this._lastAttack) >= this._attackSpeed)
        {

            this._lastAttack = Time.time;
            this._animator.Play(Constants.PLAYER_PUNCH_ANIMATION);
            //this._animator.SetBool("Punch", true);
            /*Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            foreach(Transform child in this.gameObject.transform){
                if (child.name == "RightArmPoint") {
                    Vector3 mousePosition = new Vector3(mouse.x, mouse.y, 0);
                    Vector3 normalized = new Vector3(
                        mousePosition.x - child.position.x,
                        mousePosition.y - child.position.y,
                        0).normalized;
                    float angle = (Mathf.Atan2(normalized.y, normalized.x) / Mathf.PI * 180 + 90 + 360) % 360;
                    Debug.Log(this._player._lookingRight + " " + angle);
                    if ((this._player._lookingRight && angle <= 180 && angle >= 0) || (!this._player._lookingRight && angle >= 180 && angle < 360)) {
                        Vector3 direction = new Vector3(child.rotation.x, child.rotation.y, angle);
                        child.rotation = Quaternion.Euler(direction);
                    }
                }
            }*/

        } else {

            this._animator.SetBool(Constants.PLAYER_PUNCH_ANIMATION, false);

        }

    }

}
