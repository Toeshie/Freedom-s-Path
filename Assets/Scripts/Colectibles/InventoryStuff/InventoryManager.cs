
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    //[SerializeField] private Item item1 = null;
    //[SerializeField] private Item item2 = null;
    //[SerializeField] private Item item3 = null;
    
    
    
    public List<Item> items = new(2);

    public Transform itemContent;
    public GameObject inventoryItem;
    
    public InventoryItemControler[] inventoryItems;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        /*
        if (items.Contains(item1))
        {
            print($"Item1");
        }

        if (items.Contains(item2))
        {
            print($"Item2");
        }

        if (items.Contains(item3))
        {
            print($"Item3");
        }

        if (items.Contains(item1) && items.Contains(item2))
        {
            print($"Item1 e Item2");
        }
        if (items.Contains(item1) && items.Contains(item3))
        {
            print($"Item1 e Item3");
        }
        if (items.Contains(item2) && items.Contains(item3))
        {
            print($"Item2 e Item3");
        }
        */
    }

    private void Start()
    {
       items.Clear();
    }

    public void Add(Item item)
    {
        items.Add(item);
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }

    public void ListItems()
    {
        ClearInventory();
        foreach (var item in items)
        {
            GameObject obj = Instantiate(inventoryItem, itemContent);
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            
            itemIcon.sprite = item.icon;
        }
        SetInventoryItems();
    }

    private void ClearInventory()
    {
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }
    }


    private void SetInventoryItems()
    {
        inventoryItems = itemContent.GetComponentsInChildren<InventoryItemControler>();
        for (int i = 0; i < items.Count; i++)
        {
           inventoryItems[i].AddItem(items[i]); 
        }
    }
}
