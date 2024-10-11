    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int number;

    private void Update()
    {
        if (GameManager.instance.itemNumber >= number)
        {
            GameManager.instance.isOpen = true;

        }
    }



}
