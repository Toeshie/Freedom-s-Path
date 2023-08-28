
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    [SerializeField] private Item item1 = null;
    [SerializeField] private Item item2 = null;
    [SerializeField] private Item item3 = null;

    public List<Item> items = new(2);

    [SerializeField] private Transform itemContent;
    [SerializeField] private GameObject inventoryItem;
    
    [SerializeField] private InventoryItemControler[] inventoryItems;
    
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
    
    
    public void FinalCutsceneConditions()
    {
        if (items.Contains(item1))
        {
            CutSceneManager.instance.PlayCutSceneItem1();
        }

        if (items.Contains(item1) && items.Contains(item2))
        {
            CutSceneManager.instance.PlayCutSceneItem1N2();
        }

        if (items.Contains(item1) && items.Contains(item3))
        {
            CutSceneManager.instance.PlayCutSceneItem1N3();
        }

        if (items.Contains(item2))
        {
            CutSceneManager.instance.PlayCutSceneItem2();
        }

        if (items.Contains(item2) && items.Contains(item3))
        {
            CutSceneManager.instance.PlayCutSceneItem2N3();
        }

        if (items.Contains(item3))
        {
            CutSceneManager.instance.PlayCutSceneItem3();
        }
        else
        {
            CutSceneManager.instance.PlayNoItemCutScene();
        }
    }

    private void Start()
    {
       ClearItems();
       ClearInventory();
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

    public void ClearInventory()
    {
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }
    }

    public void ClearItems()
    {
        items.Clear();  
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
