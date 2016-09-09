using UnityEngine;
using System.Collections;

public class FrogEnemy : Enemy {

    public GameObject _frogDNA;

	/*// Use this for initialization
	void Start () {
        base.start();
	}*/
	
	// Update is called once per frame
	void Update () {

        this.behaviour();

	}

    public void behaviour () {

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
            Destroy(this.gameObject);
        }
    }
}
