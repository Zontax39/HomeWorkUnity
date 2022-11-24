using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUp : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.TryGetComponent<PlayerMover>(out PlayerMover player))
      {
         Destroy(gameObject);
      }
   }
}
