using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Inventory System/Inventory")]

public class Inventory : ScriptableObject
{
    [SerializeField] private List<InventoryItemWrapper> items = new List<InventoryItemWrapper>();
    [SerializeField] private InventoryUI inventoryUIPrefab;
    private InventoryUI _inventoryUI;

    private InventoryUI inventoryUI
    {
        get
        {
            if (!_inventoryUI)
            {
                _inventoryUI = Instantiate(inventoryUIPrefab, playerEquipment.GetUIParent());
            }
            return _inventoryUI;
        }
    }

    private Dictionary<InventoryItem, int> itemToCountMap = new Dictionary<InventoryItem, int>();
    private PlayerEquipmentController playerEquipment;




    public void InitInventory(PlayerEquipmentController playerEquipment)
    {
        this.playerEquipment = playerEquipment;
        for (int i = 0; i < items.Count; i++)
        {
            itemToCountMap.Add(items[i].GetItem(), items[i].GetItemCount());
        }
    }

    
    public void OpenInventoryUI() // open inventory
    {
        inventoryUI.gameObject.SetActive(true);
        inventoryUI.InitInventoryUI(this);
    }
    


    public void AssignItem(InventoryItem item)
    {
        item.AssignItemToPlayer(playerEquipment);
    }

    public Dictionary<InventoryItem, int> GetAllItemsMap()
    {
        return itemToCountMap;
    }

    public void AddItem(InventoryItem item, int count)
    {
        int currentItemCount;
        if(itemToCountMap.TryGetValue(item, out currentItemCount)) //Check if item exists. If it does, get the count if there is one. If no count, add entrance to item dictionary.
        {
            Debug.Log(currentItemCount);
            itemToCountMap[item] = currentItemCount + count;
        }
        else
        {
            itemToCountMap.Add(item, count);
        }
        inventoryUI.CreateOrUpdateSlot(this, item, currentItemCount + count);
    }

    public void RemoveItem(InventoryItem item, int count)
    {
        int currentItemCount;
        if(itemToCountMap.TryGetValue(item, out currentItemCount)) //Check if item exists. If it does, get the count if there is one. If no count, debug error.
        {
            itemToCountMap[item] = currentItemCount - count;
            if(currentItemCount <= 0)
            {
                inventoryUI.DestroySlot(item);
            }
            else
            {
                inventoryUI.UpdateSlot(item, currentItemCount - count);
            }
        }
        else
        {
            Debug.Log(string.Format("Cannot remove nonexistent item."));
        }
    }

}

