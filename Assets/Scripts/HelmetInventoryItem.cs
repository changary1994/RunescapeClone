using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Inventory System/Items/Helmet Item")]
public class HelmetInventoryItem : InventoryItem
{
    public override void AssignItemToPlayer(PlayerEquipmentController playerEquipment)
    {
        playerEquipment.AssignHelmetItem(this);
    }
}
