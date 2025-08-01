using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotToolTip : MonoBehaviour
{

    // �ʿ��� ������Ʈ
    [SerializeField]
    private GameObject go_Base;

    [SerializeField]
    private TextMeshProUGUI txt_ItemName;
    [SerializeField]
    private TextMeshProUGUI txt_ItemDesc;
    [SerializeField]
    private TextMeshProUGUI txt_ItemHowtoUsed;


    public void ShowToolTip(Item _item, Vector3 _pos)
    {
        go_Base.SetActive(true);
        _pos += new Vector3(go_Base.GetComponent<RectTransform>().rect.width * 0.5f, -go_Base.GetComponent<RectTransform>().rect.height, 0f);
        go_Base.transform.position = _pos;

        txt_ItemName.text = _item.itemName;
        txt_ItemDesc.text = _item.itemDesc;


        if (_item.itemType == Item.ItemType.Used)
            txt_ItemHowtoUsed.text = "��Ŭ�� - ����ϱ�";
        else
            txt_ItemHowtoUsed.text = "";
    }

    public void HideToolTip()
    {
        go_Base.SetActive(false);
    }
}