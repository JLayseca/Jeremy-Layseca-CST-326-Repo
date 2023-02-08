using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotCrontroller : MonoBehaviour
{
        public int slotNumber;
        public int pointValue;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Entered {slotNumber} worth {pointValue} points");
    }
}
