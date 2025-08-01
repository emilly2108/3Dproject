using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemEffect
{
    public string itemName; // �������� �̸�(Ű��)
    [Tooltip("HP, SP�� �����մϴ�")]
    public string[] part; // ����
    public int[] num; // ��ġ
}

public class ItemEffectDatabase : MonoBehaviour
{
    [SerializeField]
    PlayerController playerController;
    [SerializeField] LifeSystem lifeSystem;
    [SerializeField]
    private ItemEffect[] itemEffects;

    //�ʿ��� ������Ʈ

    [SerializeField]
    private SlotToolTip theSlotToolTip;

    private const string HP = "HP", SP = "SP";

    public void ShowToolTop(Item _item, Vector3 _pos)
    {
        theSlotToolTip.ShowToolTip(_item, _pos);
    }

    public void HideToolTip()
    {
        theSlotToolTip.HideToolTip();
    }

    public void UseItem(Item _item, Slot _slot)
    {
        if (_item.itemType == Item.ItemType.Used)
        {

            for (int x = 0; x < itemEffects.Length; x++)
            {

                if (itemEffects[x].itemName == _item.itemName)
                {

                    for (int y = 0; y < itemEffects[x].part.Length; y++)
                    {

                        switch (itemEffects[x].part[y])
                        {
                            case HP:
                                lifeSystem. ChangeHP(1);
                                //thePlayerStatus.IncreaseHP(itemEffects[x].num[y]);
                                break;
                            case SP:
                                playerController.StartSpeedBoost(10f);

                                break;
                        }
                        Debug.Log(_item.itemName + " �� ����߽��ϴ�");
                        //_slot.SetSlotCount(-1);
                        _slot.ClearSlot();

                    }
                    return;
                }


            }
            Debug.Log("ItemEffectDatabase�� ��ġ�ϴ� itemName �����ϴ�");
        }

    }
}