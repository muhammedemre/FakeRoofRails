using System;
using System.Collections;
using UnityEngine;

public class PlayerInteractionOfficer : MonoBehaviour
{
    [SerializeField] private PlayerActor playerActor;
    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bonus")
        {
            triggered = true;
            playerActor.stickActor.stickSizeOfficer.ScaleUpTheStick();
            Destroy(other.gameObject);
            StartCoroutine(ResetTrigger());
        }

        if (other.tag == "Road")
        {
            playerActor.playerMoveOfficer.flying = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Road")
        {
            playerActor.playerMoveOfficer.flying = true;
        }
    }


    IEnumerator ResetTrigger()
    {
        yield return new WaitForSeconds(0.3f);
        triggered = false;
    }
}
