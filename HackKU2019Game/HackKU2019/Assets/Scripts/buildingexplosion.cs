using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingexplosion : MonoBehaviour {
    //public Material boom;
    public GameObject bewmboom;

    public GameObject buildingMesh;
    public GameObject buildingMesh2;
    GameObject fire;
    public GameObject parent;

    public AudioSource explosionSound;

    public GameObject laser1;

    public GameObject laser2;

    // Use this for initialization
    void Start () {

        //GameObject fire = Instantiate(bewmboom, this.transform.position, this.transform.rotation);
        //fire.GetComponent<ParticleSystem>().loop = false;

        //StartCoroutine(wait());
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

        //GameObject projectile = Instantiate(laser) as GameObject;
        //projectile.transform.position = Camera.main.transform.forward;
        //Rigidbody rb = projectile.GetComponent<Rigidbody>();
        //rb.velocity = Camera.main.transform.forward * 40;

        if (Vector3.Distance(Camera.main.transform.position, this.parent.transform.position) <= 3f)
        {

            GameObject newFire = Instantiate(bewmboom, this.transform.position, this.transform.rotation);
            fire = newFire;
            buildingMesh.GetComponent<MeshRenderer>().enabled = false;
            buildingMesh2.GetComponent<MeshRenderer>().enabled = false;


            laser1.GetComponent<BeamLaser>().shootLaser();
            laser2.GetComponent<BeamLaser>().shootLaser();

            explosionSound.Play();
            fire.GetComponent<ParticleSystem>().loop = false;
            StartCoroutine(wait());
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(5.0f);

        //Destroy(fire);
        //laser1.GetComponent<BeamLaser>().shootLaser();
        //laser2.GetComponent<BeamLaser>().shootLaser();

        Destroy(parent);

    }
}
