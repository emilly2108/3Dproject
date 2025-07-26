using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{


    public Item item; // ȹ���� ������
    public int itemCount; // ȹ���� �������� ����
    public Image itemImage; // �������� �̹���


    // �ʿ��� ������Ʈ


    private ItemEffectDatabase theItemEffectDatabase;
    private Rect baseRect;
    private SlotToolTip theSlot;

    void Start()
    {
        theItemEffectDatabase = FindObjectOfType<ItemEffectDatabase>();
        baseRect = transform.parent.parent.GetComponent<RectTransform>().rect;
    }

    // �̹����� ���� ����
    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }

    // ������ ȹ��
    public void AddItem(Item _item, int _count = 1)
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.itemImage;

        SetColor(1);
    }

    // ������ ���� ����
    public void SetSlotCount(int _count)
    {
        itemCount += _count;

        if (itemCount <= 0)
            ClearSlot();
    }

    // ���� �ʱ�ȭ
    private void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetColor(0);

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (item != null)
            {
                theItemEffectDatabase.UseItem(item);

                if (item.itemType == Item.ItemType.Used)
                    SetSlotCount(-1);
            }
        }
    }


    // ���콺�� ���Կ� �� �� �ߵ�
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null)
            theItemEffectDatabase.ShowToolTop(item, transform.position);
    }

    // ���Կ��� �������� �� �ߵ�
    public void OnPointerExit(PointerEventData eventData)
    {
        theItemEffectDatabase.HideToolTip();
    }


}
