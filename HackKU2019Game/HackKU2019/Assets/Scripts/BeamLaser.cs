using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamLaser : MonoBehaviour
{
    LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
        line.enabled = false;

        //Screen.lockCursor = true;
    }

    void Update() {
        if(Input.GetButtonDown("Fire1")) {
            StopCoroutine("Fire");
            StartCoroutine("Fire");
        }
    }

    public void shootLaser()
    {
        StopCoroutine("Fire");
        StartCoroutine("Fire");

    }



    IEnumerator Fire() {
        line.enabled = true;
        //Debug.Log("LASE");
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            //Debug.Log("LASER1");
            line.SetPosition(0, ray.origin);

            if(Physics.Raycast(ray, out hit, 100)) {
                line.SetPosition(1, hit.point);
                //Debug.Log("LASER32");
                if(hit.rigidbody) {
                    hit.rigidbody.AddForceAtPosition(transform.forward * 5, hit.point);
                }
            } else {
                line.SetPosition(1, ray.GetPoint(100));
            }
            yield return new WaitForSeconds(1f);
        
        line.enabled = false;
    }
}
