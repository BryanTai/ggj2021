using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSFX : MonoBehaviour
{
    public AudioSource playSound;
    private ItemPickup _currentItem = null;

    void OnTriggerEnter(Collider other)
    {
        //print("other name = " + other.gameObject.name);
        _currentItem = other.gameObject.GetComponent<ItemPickup>();

        if(_currentItem == null)
        {
            return;
            
        }
        playSound.Play();




    }
}
