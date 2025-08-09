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
    public Metal metal;
    public Monitor monitor;
    public Puzzle puzzle;
    public Luminol_Paper paper;
    //�ʿ��� ������Ʈ

    [SerializeField]
    private SlotToolTip theSlotToolTip;

    private const string HP = "HP", SP = "SP", Alchol = "Alchol", Puzzle = "Puzzle";

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
            bool found = false;

            for (int x = 0; x < itemEffects.Length; x++)
            {
                if (itemEffects[x].itemName == _item.itemName)
                {
                    found = true;

                    for (int y = 0; y < itemEffects[x].part.Length; y++)
                    {
                        switch (itemEffects[x].part[y])
                        {
                            case HP:
                                lifeSystem.ChangeHP(1);
                                break;
                            case SP:
                                playerController.StartSpeedBoost(10f);
                                break;
                        }
                        Debug.Log(_item.itemName + " �� ����߽��ϴ�");
                        _slot.ClearSlot();
                    }

                    break;
                }
            }

            if (!found)
            {
                Debug.Log("ItemEffectDatabase�� ��ġ�ϴ� itemName �����ϴ�");
            }
        }

        else if (_item.itemType == Item.ItemType.QizeItem)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
                RaycastHit hit;
                monitor.IsTouch = Physics.Raycast(ray, out hit, 1.5f);
            if (_item.itemName == "���ݿú�")
            {
                if (metal.Show_before == true)
                {
                    metal.ClearMetal();
                    metal.Show_after = true;
                    metal.Show_before = false;
                    playerController.SetCanMove(false);
                    metal.monitor.Text_UI.SetActive(false);
                    metal.monitor.Crosshair.SetActive(false);

                    _slot.ClearSlot();
                }
            }
            else if( puzzle.Showing == true)
            {
                if (_item.itemName == "�ǹ��� ���� ����1")
                {
                    puzzle.Puzzle1();
                    _slot.ClearSlot();
                }
                else if (_item.itemName == "�ǹ��� ���� ����2")
                {
                    puzzle.Puzzle2();
                    _slot.ClearSlot();
                }
                else if (_item.itemName == "�ǹ��� ���� ����3")
                {
                    puzzle.Puzzle3();
                    _slot.ClearSlot();
                }
                else if (_item.itemName == "�ǹ��� ���� ����4")
                {
                    puzzle.Puzzle4();
                    _slot.ClearSlot();
                }
            }
            else if (_item.itemName == "��̳� ��")
            {
                if (paper.Paper_before == true)
                {
                    paper.ClearPaper();
                    paper.Paper_after = true;
                    paper.Paper_before = false;
                    playerController.SetCanMove(false);
                    paper.monitor.Text_UI.SetActive(false);
                    paper.monitor.Crosshair.SetActive(false);

                    _slot.ClearSlot();
                }
            }
            else if (_item.itemName == "����")
            {
                if (hit.transform.CompareTag("MainDoor"))
                {
                    Debug.Log("Ż��, ����");
                }
            }
        }
    }

}
