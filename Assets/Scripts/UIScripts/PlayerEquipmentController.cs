using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipmentController : MonoBehaviour
{
    [SerializeField] public Inventory inventory;
    [SerializeField] private Transform inventoryUIParent;

    [Header("Anchors")]
    [SerializeField] private Transform helmetAnchor;
    [SerializeField] private Transform leftHandAnchor;
    [SerializeField] private Transform rightHandAnchor;
    [SerializeField] private Transform armorAnchor;

    private GameObject currentHelmetObj;
    private GameObject currentLeftHandObj;
    private GameObject currentRightHandObj;
    private GameObject currentArmorObj;

    [Header("Items")]
    [SerializeField] private WoodInventoryItem woodItem;

    //Get update to add item
    //public bool chopComplete = false;
    private void Start()
    {
        inventory.InitInventory(this);
        inventory.OpenInventoryUI();
    }

    private void Update()
    {
        /*if (chopComplete)
        {
            AssignWoodItem(woodItem);
            chopComplete = false;
            Debug.Log(chopComplete);
        }*/
    }

    public void AssignHelmetItem(HelmetInventoryItem item)
    {
        DestroyIfNotNull(currentHelmetObj);
        currentHelmetObj = CreateNewItemInstance(item, helmetAnchor);
    }

    public void AssignHandItem(HandInventoryItem item)
    {
        switch (item.hand)
        {
            case Hand.LEFT:
                DestroyIfNotNull(currentLeftHandObj);
                currentLeftHandObj = CreateNewItemInstance(item, leftHandAnchor);
                break;
            case Hand.RIGHT:
                DestroyIfNotNull(currentRightHandObj);
                currentLeftHandObj = CreateNewItemInstance(item, rightHandAnchor);
                break;
            default:
                break;
        }
    }
    public void AssignArmorItem(ArmorInventoryItem item)
    {
        DestroyIfNotNull(currentArmorObj);
        currentArmorObj = CreateNewItemInstance(item, armorAnchor);
    }
    public void AssignWoodItem(WoodInventoryItem item)
    {
        inventory.AddItem(item, 1);
        Debug.Log("Received 1 wood.");
    }

    private GameObject CreateNewItemInstance(InventoryItem item, Transform anchor)
    {
        var itemInstance = Instantiate(item.GetPrefab(), anchor);
        itemInstance.transform.localPosition = item.GetLocalPosition();
        itemInstance.transform.localRotation = item.GetLocalRotation();
        return itemInstance;
    }

    private void DestroyIfNotNull(GameObject obj)
    {
        if (obj)
        {
            Destroy(obj);
        }
    }

    public Transform GetUIParent()
    {
        return inventoryUIParent;
    }



}
