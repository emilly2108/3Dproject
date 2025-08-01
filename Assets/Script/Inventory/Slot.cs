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
    public void AddItem(Item _item)
    {
        item = _item;
        itemCount = 1;
        itemImage.sprite = item.itemImage;

        SetColor(1);
    }

    // ������ ���� ����
    /*public void SetSlotCount(int _count)
    {
        itemCount += _count;

        if (itemCount <= 0)
            ClearSlot();
    }*/

    // ���� �ʱ�ȭ
    public void ClearSlot()
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
                theItemEffectDatabase.UseItem(item, this);
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