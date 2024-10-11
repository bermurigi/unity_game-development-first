using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorColl : MonoBehaviour
{
    private bool isOpen;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && isOpen == false && GameManager.instance.isOpen==true)
        {
            Debug.Log("¸Ó¾ß");
            if (Input.GetKey(KeyCode.E))
            {
                GameManager.instance.ShowKey();
                isOpen = true;
            }
        }
                
    }
}
