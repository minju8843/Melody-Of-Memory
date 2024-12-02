using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item_Color : MonoBehaviour
{
    public string itemName;//아이템 이름
    public TextMeshProUGUI Name_Text;//아이템 이름 나타낼 텍스트

    public Bag_Item bag_item;//아이템 수량관련 스크립트
    public TextMeshProUGUI quantityText;//수량 나타낼 텍스트
    public Image itemImage;//색을 바꿀 아이템 이미지
    
    public Image Gray_Image;//색을 바꿀 회색 이미지
    public GameObject Big_Item_Image;//오른쪽 창에 보일 아이템 이미지

    public static Item_Color Touch_btn;//현재 눌린 버튼 ->
    //현재 버튼이 눌렸으면 색이 변하거나 오른쪽 이미지가 보이고
    //다른 버튼은 원래 색으로 돌아오고 오른쪽 이미지가 보이지 않게 된다.


    public void Update()
    {
        //아이템 수량을 가져온다
        /*int itemQuantity = bag_item.GetItemQuantity(itemName);
        

        //quantityText.text = "보유: " + itemQuantity + "개";

        //보유 개수가 0일 경우, 아이템 회색으로 색 변경
        if (itemQuantity == 0)
        {
            itemImage.color = new Color32(106, 106, 106, 143);
            
        }

        //그렇지 않다면 원래 색으로
        if (itemQuantity > 0)
        {
            itemImage.color = Color.white;
        }*/


    }

    public void Color_Chage()//보유 수에 따라 아이템 색 변경
    {
        //아이템 수량을 가져온다
        int itemQuantity = bag_item.GetItemQuantity(itemName);


        //quantityText.text = "보유: " + itemQuantity + "개";

        //보유 개수가 0일 경우, 아이템 회색으로 색 변경
        if (itemQuantity == 0)
        {
            itemImage.color = new Color32(106, 106, 106, 143);

        }

        //그렇지 않다면 원래 색으로
        if (itemQuantity > 0)
        {
            itemImage.color = Color.white;
        }
    }


    public void Item_Click()
    {
        SFX_Manager.instance.SFX_Button();

        //버튼 눌렀을때
        //아이템 이름 보이기
        Name_Text.text = itemName;


        //회색 이미지 색 변경
        Gray_Image.color = new Color32(253, 170, 170, 255);

        //오른쪽 이미지 나타나도록
        Big_Item_Image.SetActive(true);

        //아이템 수량을 가져온다
        int itemQuantity = bag_item.GetItemQuantity(itemName);
        quantityText.text = "보유: " + itemQuantity + "개";

        
        //이전에 선택된 것이 있으면
        //이전에 터치한 버튼의 색상을 원래대로 변경 + 기존 오른쪽 이미지 비활성화
        if(Touch_btn != null && Touch_btn != this)
        {
            Touch_btn.Gray_Image.color = Color.white;
            Touch_btn.Big_Item_Image.SetActive(false);
        }

        //현재 버튼을 활성화 상태로 설정!
        Touch_btn = this;
        
    }
}
