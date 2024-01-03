using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public string itemText;
    public string oneitem;
    public string twoitem;
    public string threeitem;
    public Item(string text)
    {
        itemText = text;
    }
    public Item(string text, string oneitem, string twoitem, string threeitem = "")
    {
        itemText = text;
        this.oneitem = oneitem;
        this.twoitem = twoitem;
        if (!string.IsNullOrEmpty(threeitem))
            this.threeitem = threeitem;
    }
    public Item Copy()
    {
        return new Item(itemText, oneitem, twoitem);
    }
}
