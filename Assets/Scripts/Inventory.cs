using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    public Sprite blankSprite;
    List<Item> items = new List<Item>();
    public List<ItemSlot> itemSlots = new List<ItemSlot>();
    [SerializeField]
    string[] haveitems;
    int index;

    void Start()
    {
        foreach(string s in haveitems)
        {
            AddItem(GameManager.Instance.GetItem(s));
        }
        UpdateItemSlot();
    }
    void Update()
    {
    }
    void UpdateItemSlot()
    {
        for (int i = 0; i < 5; i++)
        {
            if (i < items.Count)
            {
                int d = (i + index) % items.Count;
                itemSlots[i].SetItem(items[d]);
            }
            else
                itemSlots[i].SetItem(null);
        }
    }
    public void RemoveItem(Item item)
    {
        items.Remove(item);
        UpdateItemSlot();
    }
    public void AddItem(Item item)
    {
        items.Add(item);
        UpdateItemSlot();
    }
    public void RightArrow()
    {
        index--;
        if (index <= 0)
            index = items.Count;
        UpdateItemSlot();

    }
    public void LeftArrow()
    {
        index++;
        UpdateItemSlot();
    }
}
