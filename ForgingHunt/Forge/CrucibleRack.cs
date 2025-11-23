using System;
using System.Collections;
using System.Collections.Generic;
using ForgingHunt.Forge.ForgeItems;
using UnityEngine;

namespace ForgingHunt.Forge
{
    public class CrucibleRack : MonoBehaviour
    {
        private Crucible activeCrucible;
        private Coroutine activeMelt;

        private void OnTriggerStay(Collider other)
        {
            //add code similar to how crystal holders work
            
            activeMelt = StartCoroutine(activeCrucible.Melt());
        }
    }
}