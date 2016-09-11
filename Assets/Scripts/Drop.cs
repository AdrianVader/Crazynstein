using UnityEngine;
using System.Collections;

public class Drop : MonoBehaviour {

	// Use this for initialization
	/*void Start () {
        
	}*/
	
	// Update is called once per frame
	void Update () {

        this.turn();

        //this.hover();

	}

    public void turn() {
        this.transform.Rotate(0, Constants.DROP_ROTARION_SPEED, 0);
    }

    public void hover() {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        if (rb.velocity.y == 0) {
            rb.velocity = new Vector3(0, Constants.DROP_JUMP, 0);
        }
    }

    void OnMouseEnter () {
        GameObject player = GameObject.FindGameObjectWithTag(Constants.PLAYER_TAG);
        float distance = Mathf.Abs(Vector3.Distance(player.transform.position, this.gameObject.transform.position));
        if (distance <= Constants.DROP_TAKE_MININUM_DISTANCE) {
            this.GetComponent<Behaviour>().enabled = true;
        }
        else {
            this.GetComponent<Behaviour>().enabled = false;
        }
    }

    void OnMouseExit () {
        this.GetComponent<Behaviour>().enabled = false;
    }

    void OnMouseOver() {

        GameObject player = GameObject.FindGameObjectWithTag(Constants.PLAYER_TAG);
        float distance = Mathf.Abs(Vector3.Distance(player.transform.position, this.gameObject.transform.position));
        if (Input.GetKeyDown(Constants.PLAYER_USE_KEY) && distance <= Constants.DROP_TAKE_MININUM_DISTANCE)
        { // Use

            
            player.GetComponent<Player>()._inventory.Add(this.gameObject);

            this.gameObject.SetActive(false);
        }

    }

}
