using System.Collections;
using UnityEngine;

public class CylinderInteractionOfficer : MonoBehaviour
{
    [SerializeField] private CylinderActor cylinderActor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle" && this.tag == "Cylinder")
        {
            print("PLAYER HIT : "+this.name );
            // other.GetComponent<Collider>().enabled = false;
            cylinderActor.stickSizeOfficer.ResizeTheStick(other.transform);
        }
    }
}
