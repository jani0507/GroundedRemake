using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public ItemDatabase database;

    PlayerController player;

    int maxAmount = 32;
    int slotAmount = 7;
    int storageAmount = 37;

    public GameObject InvCanvas;
    public GameObject slot;
    public GameObject invitem;
    public GameObject hotbarPanel;
    public GameObject inventoryPanel;

    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
        database = gameObject.GetComponent<ItemDatabase>();

        for (int i = 0; i < slotAmount; i++)
        {
            items.Add(database.GetItemByID(-1));
            slots.Add(Instantiate(slot));
            slots[i].GetComponent<Slots>().slotNumber = i;
            slots[i].transform.SetParent(hotbarPanel.transform);
            slots[i].GetComponent<RectTransform>().transform.localScale = Vector3.one;
        }
        for (int i = slotAmount; i < storageAmount; i++)
        {
            items.Add(database.GetItemByID(-1));
            slots.Add(Instantiate(slot));
            slots[i].GetComponent<Slots>().slotNumber = i;
            slots[i].transform.SetParent(inventoryPanel.transform);
            slots[i].GetComponent<RectTransform>().transform.localScale = Vector3.one;
        }

        AddItem(1);

        ToggleInventory();
    }

   

    public void AddItem(int id)
    {
        Item itemToAdd = database.GetItemByID(id);
        if (itemToAdd.Stackable && CheckInventory(itemToAdd))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if(items[i].ID == id)
                {
                    if (slots[i].transform.GetChild(0).GetComponent<ItemData>().amount < maxAmount)
                    {
                        ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                        data.amount++;
                        data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < items.Count; i++)
            {
                if(items[i].ID == -1)
                {
                    items[i] = itemToAdd;
                    GameObject itemObj = Instantiate(invitem);
                    itemObj.GetComponent<ItemData>().item = itemToAdd;
                    itemObj.GetComponent<ItemData>().curSlot = i;
                    itemObj.transform.SetParent(slots[i].transform);
                    itemObj.name = itemToAdd.Name;
                    itemObj.transform.localScale = Vector3.one;
                    itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                    break;
                }
            }
        }
    }

    bool CheckInventory(Item item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if(items[i].ID == item.ID)
            {
                if (slots[i].transform.GetChild(0).GetComponent<ItemData>().amount < maxAmount)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void ToggleInventory()
    {
        InvCanvas.SetActive(!InvCanvas.active);
        
    }
}
