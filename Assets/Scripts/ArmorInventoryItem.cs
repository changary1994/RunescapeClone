using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Inventory System/Items/Armor Item")]
public class ArmorInventoryItem : InventoryItem
{
    public override void AssignItemToPlayer(PlayerEquipmentController playerEquipment)
    {
        playerEquipment.AssignArmorItem(this);
    }
}
