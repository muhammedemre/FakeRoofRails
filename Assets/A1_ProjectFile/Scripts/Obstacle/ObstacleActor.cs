using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleActor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBody")
        {
            PlayerManager.instance.playerActor.playerDeathOfficer.DeathProcess();
        }
    }
}
