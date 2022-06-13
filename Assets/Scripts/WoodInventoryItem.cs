using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Inventory System/Items/Wood Item")]
public class WoodInventoryItem : InventoryItem
{
    public override void AssignItemToPlayer(PlayerEquipmentController playerEquipment)
    {
        playerEquipment.AssignWoodItem(this);
    }

    public void WoodInteraction()
    {
      //TODO: Add combinations for wood inventory item with other items.
    }

}
