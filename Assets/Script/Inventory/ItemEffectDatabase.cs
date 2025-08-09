using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemEffect
{
    public string itemName; // 아이템의 이름(키값)
    [Tooltip("HP, SP만 가능합니다")]
    public string[] part; // 부위
    public int[] num; // 수치
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
    //필요한 컴포넌트

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
                        Debug.Log(_item.itemName + " 을 사용했습니다");
                        _slot.ClearSlot();
                    }

                    break;
                }
            }

            if (!found)
            {
                Debug.Log("ItemEffectDatabase에 일치하는 itemName 없습니다");
            }
        }

        else if (_item.itemType == Item.ItemType.QizeItem)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
                RaycastHit hit;
                monitor.IsTouch = Physics.Raycast(ray, out hit, 1.5f);
            if (_item.itemName == "알콜올병")
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
                if (_item.itemName == "의문의 퍼즐 조각1")
                {
                    puzzle.Puzzle1();
                    _slot.ClearSlot();
                }
                else if (_item.itemName == "의문의 퍼즐 조각2")
                {
                    puzzle.Puzzle2();
                    _slot.ClearSlot();
                }
                else if (_item.itemName == "의문의 퍼즐 조각3")
                {
                    puzzle.Puzzle3();
                    _slot.ClearSlot();
                }
                else if (_item.itemName == "의문의 퍼즐 조각4")
                {
                    puzzle.Puzzle4();
                    _slot.ClearSlot();
                }
            }
            else if (_item.itemName == "루미놀 병")
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
            else if (_item.itemName == "열쇠")
            {
                if (hit.transform.CompareTag("MainDoor"))
                {
                    Debug.Log("탈출, 엔딩");
                }
            }
        }
    }

}
