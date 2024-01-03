using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : Slot, IDragHandler, IEndDragHandler, IPointerClickHandler, IBeginDragHandler
{
    public Item item;
    Image image;
    float doublecheck;
    void Awake()
    {
        image = GetComponent<Image>();
    }
    public void OnPointerClick(PointerEventData data)
    {
        if (GameManager.Instance.Clickable)
        {
            if (data.button == PointerEventData.InputButton.Left)
            {
                if(doublecheck <= 0)
                {
                    doublecheck = 0.5f;
                    return;
                }
                Item asd = item;
                if (!string.IsNullOrEmpty(asd.oneitem))
                {
                    SoundManager.Instance.PlaySound("Metallicclick_by_j1987_Id-107806");
                    Inventory.Instance.RemoveItem(asd);
                    Inventory.Instance.AddItem(GameManager.Instance.GetItem(asd.oneitem).Copy());
                    Inventory.Instance.AddItem(GameManager.Instance.GetItem(asd.twoitem).Copy());
                    if (!string.IsNullOrEmpty(asd.threeitem))
                    {
                        if (asd.threeitem == "Paper")
                        {
                            Stage2Sound.Instance.Show();
                        }
                        else
                        {
                            Inventory.Instance.AddItem(GameManager.Instance.GetItem(asd.threeitem).Copy());
                        }
                    }
                }
            }
        }
    }
    public void OnBeginDrag(PointerEventData data)
    {
        if (GameManager.Instance.Clickable)
        {
            if (item != null && data.button == PointerEventData.InputButton.Left)
            {
                transform.parent.SetAsLastSibling();
            }
        }
    }
    public void OnDrag(PointerEventData data)
    {
        if (GameManager.Instance.Clickable)
        {
            if (item != null && data.button == PointerEventData.InputButton.Left)
            {
                transform.position = Camera.main.ScreenToWorldPoint(data.position) + new Vector3(0, 0, 144);
            }
        }
    }

    void Update()
    {
        if (doublecheck > 0)
            doublecheck -= Time.deltaTime;
    }

    public void SetItem(Item item)
    {
        this.item = item;
        if (item != null)
            GetComponent<Image>().sprite = Resources.Load<Sprite>("Item/" + item.itemText);
        else
            image.sprite = Inventory.Instance.blankSprite;
    }
    public void OnEndDrag(PointerEventData data)
    {
        if (GameManager.Instance.Clickable)
        {
            if (item != null && data.button == PointerEventData.InputButton.Left)
            {
                ItemSlot selectItem = Inventory.Instance.itemSlots.Find((ItemSlot x) => Vector2.Distance(transform.position, x.transform.position) < 0.3f && x != this);
                if (selectItem != null && selectItem.item != null)
                {
                    Item createItem = GameManager.Instance.allItems.Find((Item x) => ((x.oneitem == item.itemText && x.twoitem == selectItem.item.itemText) || (x.twoitem == item.itemText && x.oneitem == selectItem.item.itemText)) && string.IsNullOrEmpty(x.threeitem));
                    if (createItem != null && !string.IsNullOrEmpty(createItem.itemText))
                    {
                        Item asd = item;
                        SoundManager.Instance.PlaySound("Water_Click_by_Mafon2_Id-371274");
                        Inventory.Instance.RemoveItem(selectItem.item);
                        Inventory.Instance.RemoveItem(asd);
                        Inventory.Instance.AddItem(createItem.Copy());
                    }
                }
                else
                {
                    RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
                    if (rayHit.collider != null)
                    {
                        rayHit.collider.GetComponent<Obj>().UseItem(item);
                    }
                }
                transform.localPosition = Vector3.zero;
            }
        }
    }
}
