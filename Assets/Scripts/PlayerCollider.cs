using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cube")
        {
            Destroy(other.gameObject);
            GameManager.instance.haveItemSelf = true;
        }
        if (other.tag == "Sphere")
        {
            GameManager.instance.itemNumber++;
            AudioManager.instance.PlaySfx(AudioManager.Sfx.Get);
            Destroy(other.gameObject);
        }
    }
}
