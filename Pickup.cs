using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInteract manager = collision.GetComponent<PlayerInteract>();
        if(manager)
        {
            manager.PickupItem(gameObject);
            Destroy(gameObject);
            
        }
    }
}
