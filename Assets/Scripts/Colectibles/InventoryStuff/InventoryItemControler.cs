
using System;
using UnityEngine;


public class InventoryItemControler : MonoBehaviour
{
   Item item;
   

   public void RemoveItem()
   {
      InventoryManager.instance.Remove(item);
      Destroy(gameObject);
   }
   
   public void AddItem(Item newItem)
   {
      item = newItem;
   }
   
}
