using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public static bool inventoryActivated = false;


    // �ʿ��� ������Ʈ
    [SerializeField]
    private GameObject go_SlotsParent;

    // ���Ե�
    private Slot[] slots;


    void Start()
    {
        slots = go_SlotsParent.GetComponentsInChildren<Slot>();
    }

    void Update()
    {
        TryOpenInventory();
    }

    private void TryOpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryActivated = !inventoryActivated;

            if (inventoryActivated)
                OpenInventory();
            else
                CloseInventory();
        }
    }

    private void OpenInventory()
    {
        go_SlotsParent.SetActive(true);
    }

    private void CloseInventory()
    {
        go_SlotsParent.SetActive(false);
    }

    public void AcquireItem(Item _item)
    {
        List<int> ItemIndexes = new List<int>();

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null && slots[i].item.itemName == _item.itemName)
            {
                ItemIndexes.Add(i);
            }
        }

        if (ItemIndexes.Count >= 1)
        {
            for (int i = 1; i < ItemIndexes.Count; i++)
            {
                slots[ItemIndexes[i]].ClearSlot();
            }
            return;
        }

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                slots[i].AddItem(_item);
                return;
            }
        }
    }

}