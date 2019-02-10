using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingexplosion : MonoBehaviour {
    //public Material boom;
    public GameObject bewmboom;

	// Use this for initialization
	void Start () {
        //StartCoroutine(wait());
        //GameObject fire = Instantiate(bewmboom, this.transform.position, this.transform.rotation);
        //Destroy(this.transform.parent.gameObject);
        //StartCoroutine(wait(fire));

    }

    // Update is called once per frame
    /*void Update () {
		
	}*/

    void OnSelect()
    {
        // If the sphere has no Rigidbody component, add one to enable physics.
        /*if (!this.GetComponent<Rigidbody>())
        {
            var rigidbody = this.gameObject.AddComponent<Rigidbody>();
            rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        }

        this.GetComponent<MeshRenderer>().material = boom;*/
        GameObject fire = Instantiate(bewmboom, this.transform.position, this.transform.rotation);
        Destroy(this.transform.parent.gameObject);
        StartCoroutine(wait(fire));
    }

    IEnumerator wait(GameObject fire)
    {
        yield return new WaitForSeconds(7.0f);

        Destroy(fire);
    }
}
