using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public bool[,] buildings;
    //building array dimensions
    public int bAD = 40;
    //building array dimensions divided in half
    private int halfDim;

    public float height;

    public GameObject building; 
    public GameObject gridArray;
    public int buildingSepDistance;
    public float userRad;
    public float WAIT_TIME;
    public Transform userPosition;
    private Vector3 new_position;

    // Start is called before the first frame update
    private void Start()
    {
        //StartCoroutine(WaitForTillStart());
        halfDim = bAD / 2;
        buildings = new bool[bAD, bAD];

        for (int i = 0; i < bAD; i++) {
            for (int j = 0; j < bAD; j++) {
                buildings[i,j] = false;
            }    
        }

        PlaceBuildings(0.0f);
    }

    private void PlaceBuildings (float init_value) {
        new_position = new Vector3(userPosition.position.x - (float)halfDim, height, userPosition.position.z - (float)halfDim);
        // Starting Position of Player
        if(init_value == 0.0f) {

            for (int i = 0; i < bAD; i+=buildingSepDistance) {

                for (int j = 0; j < bAD; j+=buildingSepDistance) {

                    float _x = (float)i;
                    float _z = (float)j;
                    Vector3 set_pos = new Vector3(_x, height, _z);
                    if(buildings[i,j] == false && withinRadius(i,j) && Random.value > 0.5f) {
                        buildings[i,j] = !buildings[i,j];
                        PlaceObjectHere(set_pos);
                    }

                }

            }
            
            gridArray.transform.position = new_position;

        } else if(init_value != 0.0f) {
        }
    }

    private void Update() {
        // Refresh Buildings
    }

    private void PlaceObjectHere(Vector3 slot_pos) {
            var drop_position = gridArray.GetComponent<GridArray>().GetGridPoint(slot_pos);

            if(building != null) {
                var bObject = Instantiate(building, drop_position, Quaternion.identity) as GameObject;
                bObject.transform.SetParent(gridArray.transform);
                // Debug.Log("wtf");
            } else {
                //Debug.Log("ERROR: No gameobject to place..");
            }
    }

    private bool withinRadius(int i, int j) {

        if (((i < halfDim+userRad) && (i > halfDim-userRad)) && ((j < halfDim+userRad) && (j > halfDim-userRad))) {
            return false;
        }
        return true;
    }

    IEnumerator WaitForTillStart() {
        yield return new WaitForSeconds(WAIT_TIME);
    }

}
