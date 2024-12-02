using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;
using System.Linq;//LINQ를 사용하기 위해 필요

//1
[System.Serializable]
public class Item_1_Person//아이템 이름과 수량을 저장하기 위함
{
    public string itemName;//아이템 이름 저장
    public int item_quantity;//아이템 수량 저장

    public Item_1_Person(string name, int quantity)//객체가 생성될 때 호출되는 함수
    {//itemName과 item_quantity의 초기값을 설정할 수 있음.
        itemName = name;
        item_quantity = quantity;
    }
}

[System.Serializable]
public class List_1_Person
{
    public List<Item_1_Person> items_1;

    public List_1_Person(List<Item_1_Person> items_1)
    {
        this.items_1 = items_1;
    }
}

//2
[System.Serializable]
public class Item_2_Person//아이템 이름과 수량을 저장하기 위함
{
    public string itemName;//아이템 이름 저장
    public int item_quantity;//아이템 수량 저장

    public Item_2_Person(string name, int quantity)//객체가 생성될 때 호출되는 함수
    {//itemName과 item_quantity의 초기값을 설정할 수 있음.
        itemName = name;
        item_quantity = quantity;
    }
}

[System.Serializable]
public class List_2_Person
{
    public List<Item_2_Person> items_2;

    public List_2_Person(List<Item_2_Person> items_2)
    {
        this.items_2 = items_2;
    }
}

//3
[System.Serializable]
public class Item_3_Person//아이템 이름과 수량을 저장하기 위함
{
    public string itemName;//아이템 이름 저장
    public int item_quantity;//아이템 수량 저장

    public Item_3_Person(string name, int quantity)//객체가 생성될 때 호출되는 함수
    {//itemName과 item_quantity의 초기값을 설정할 수 있음.
        itemName = name;
        item_quantity = quantity;
    }
}

[System.Serializable]
public class List_3_Person
{
    public List<Item_3_Person> items_3;

    public List_3_Person(List<Item_3_Person> items_3)
    {
        this.items_3 = items_3;
    }
}

//4
[System.Serializable]
public class Item_4_Person//아이템 이름과 수량을 저장하기 위함
{
    public string itemName;//아이템 이름 저장
    public int item_quantity;//아이템 수량 저장

    public Item_4_Person(string name, int quantity)//객체가 생성될 때 호출되는 함수
    {//itemName과 item_quantity의 초기값을 설정할 수 있음.
        itemName = name;
        item_quantity = quantity;
    }
}

[System.Serializable]
public class List_4_Person
{
    public List<Item_4_Person> items_4;

    public List_4_Person(List<Item_4_Person> items_4)
    {
        this.items_4 = items_4;
    }
}

//5
[System.Serializable]
public class Item_5_Person//아이템 이름과 수량을 저장하기 위함
{
    public string itemName;//아이템 이름 저장
    public int item_quantity;//아이템 수량 저장

    public Item_5_Person(string name, int quantity)//객체가 생성될 때 호출되는 함수
    {//itemName과 item_quantity의 초기값을 설정할 수 있음.
        itemName = name;
        item_quantity = quantity;
    }
}

[System.Serializable]
public class List_5_Person
{
    public List<Item_5_Person> items_5;

    public List_5_Person(List<Item_5_Person> items_5)
    {
        this.items_5 = items_5;
    }
}

public class Gift_Item : MonoBehaviour
{
    public Bag_Item bag_item;

    public bool Person_1 = false;
    public bool Person_2 = false;
    public bool Person_3 = false;
    public bool Person_4 = false;
    public bool Person_5 = true;

    public TextMeshProUGUI Gift_Text;



    //사람별로 아이템을 주었을 때
    //특정 아이템의 경우 호감되는 아이템을 선물했을 경우, "오와!"를 출력하고
    //나머지 그냥 아이템을 선물했을 경우, "잘 받을게."
    //싫어하는 아이템을 받았을 경우, "윽..." 을 출력한다.

    //사람별로 받은 아이템을 저장한다.

    //아이템 수량 저장 딕셔너리(아이템 이름-수량)
    public Dictionary<string, int> Person_1_Item = new Dictionary<string, int>();
    public Dictionary<string, int> Person_2_Item = new Dictionary<string, int>();
    public Dictionary<string, int> Person_3_Item = new Dictionary<string, int>();
    public Dictionary<string, int> Person_4_Item = new Dictionary<string, int>();
    public Dictionary<string, int> Person_5_Item = new Dictionary<string, int>();

    public void Gift()
    {
        SFX_Manager.instance.SFX_Button();

        if (Gift_Text.text == "선물하기")
        {
            if (Person_1 == true)
            {
                // Gray 이미지 색상이 있는 Item_Color 배열에서 해당 아이템 찾기
                foreach (var item in bag_item.item_color)
                {
                    if (item.Gray_Image.color.Equals(new Color32(253, 170, 170, 255)))
                    {
                        // 해당 아이템의 이름 가져오기
                        string itemName = item.itemName;

                        // 해당 아이템이 존재하는지 확인하고 개수를 가져옴
                        int itemQuantity = bag_item.GetItemQuantity(itemName);

                        if (itemQuantity > 0)
                        {
                            // 아이템 개수 1 감소
                            bag_item.AddItem(itemName, -1);

                            // 감소한 개수로 Gift_Save에 저장
                            Gift_1_Save(itemName, 1);

                            Debug.Log($"{itemName}이(가) 1만큼 감소되었습니다. 남은 개수: { bag_item.itemQuantities[itemName]}");
                            item.Item_Click();

                        }
                        else
                        {
                            Debug.Log($"{itemName}의 수량이 부족합니다.");
                        }

                        break; // 찾았으면 반복 종료
                    }
                }

                //개수에 따른 색 업데이트
                for (int i = 0; i < Bag_Item.instance.item_color.Length; i++)
                {
                    //버튼 누를 때, 아이템별로 몇 개 있는지에 따라 색 변하는 걸로
                    //Update에 코드가 있으니 이상해서 이 스크립트로 옮김
                    Bag_Item.instance.item_color[i].Color_Chage();
                }
            }

            //2
            if (Person_2 == true)
            {
                // Gray 이미지 색상이 있는 Item_Color 배열에서 해당 아이템 찾기
                foreach (var item in bag_item.item_color)
                {
                    if (item.Gray_Image.color.Equals(new Color32(253, 170, 170, 255)))
                    {
                        // 해당 아이템의 이름 가져오기
                        string itemName = item.itemName;

                        // 해당 아이템이 존재하는지 확인하고 개수를 가져옴
                        int itemQuantity = bag_item.GetItemQuantity(itemName);

                        if (itemQuantity > 0)
                        {
                            // 아이템 개수 1 감소
                            bag_item.AddItem(itemName, -1);

                            // 감소한 개수로 Gift_Save에 저장
                            Gift_2_Save(itemName, 1);

                            Debug.Log($"{itemName}이(가) 1만큼 감소되었습니다. 남은 개수: { bag_item.itemQuantities[itemName]}");
                            item.Item_Click();

                        }
                        else
                        {
                            Debug.Log($"{itemName}의 수량이 부족합니다.");
                        }

                        break; // 찾았으면 반복 종료
                    }
                }

                //개수에 따른 색 업데이트
                for (int i = 0; i < Bag_Item.instance.item_color.Length; i++)
                {
                    //버튼 누를 때, 아이템별로 몇 개 있는지에 따라 색 변하는 걸로
                    //Update에 코드가 있으니 이상해서 이 스크립트로 옮김
                    Bag_Item.instance.item_color[i].Color_Chage();
                }
            }

            //3
            if (Person_3 == true)
            {
                // Gray 이미지 색상이 있는 Item_Color 배열에서 해당 아이템 찾기
                foreach (var item in bag_item.item_color)
                {
                    if (item.Gray_Image.color.Equals(new Color32(253, 170, 170, 255)))
                    {
                        // 해당 아이템의 이름 가져오기
                        string itemName = item.itemName;

                        // 해당 아이템이 존재하는지 확인하고 개수를 가져옴
                        int itemQuantity = bag_item.GetItemQuantity(itemName);

                        if (itemQuantity > 0)
                        {
                            // 아이템 개수 1 감소
                            bag_item.AddItem(itemName, -1);

                            // 감소한 개수로 Gift_Save에 저장
                            Gift_3_Save(itemName, 1);

                            Debug.Log($"{itemName}이(가) 1만큼 감소되었습니다. 남은 개수: { bag_item.itemQuantities[itemName]}");
                            item.Item_Click();

                        }
                        else
                        {
                            Debug.Log($"{itemName}의 수량이 부족합니다.");
                        }

                        break; // 찾았으면 반복 종료
                    }
                }

                //개수에 따른 색 업데이트
                for (int i = 0; i < Bag_Item.instance.item_color.Length; i++)
                {
                    //버튼 누를 때, 아이템별로 몇 개 있는지에 따라 색 변하는 걸로
                    //Update에 코드가 있으니 이상해서 이 스크립트로 옮김
                    Bag_Item.instance.item_color[i].Color_Chage();
                }
            }

            //4
            if (Person_4 == true)
            {
                // Gray 이미지 색상이 있는 Item_Color 배열에서 해당 아이템 찾기
                foreach (var item in bag_item.item_color)
                {
                    if (item.Gray_Image.color.Equals(new Color32(253, 170, 170, 255)))
                    {
                        // 해당 아이템의 이름 가져오기
                        string itemName = item.itemName;

                        // 해당 아이템이 존재하는지 확인하고 개수를 가져옴
                        int itemQuantity = bag_item.GetItemQuantity(itemName);

                        if (itemQuantity > 0)
                        {
                            // 아이템 개수 1 감소
                            bag_item.AddItem(itemName, -1);

                            // 감소한 개수로 Gift_Save에 저장
                            Gift_4_Save(itemName, 1);

                            Debug.Log($"{itemName}이(가) 1만큼 감소되었습니다. 남은 개수: { bag_item.itemQuantities[itemName]}");
                            item.Item_Click();

                        }
                        else
                        {
                            Debug.Log($"{itemName}의 수량이 부족합니다.");
                        }

                        break; // 찾았으면 반복 종료
                    }
                }

                //개수에 따른 색 업데이트
                for (int i = 0; i < Bag_Item.instance.item_color.Length; i++)
                {
                    //버튼 누를 때, 아이템별로 몇 개 있는지에 따라 색 변하는 걸로
                    //Update에 코드가 있으니 이상해서 이 스크립트로 옮김
                    Bag_Item.instance.item_color[i].Color_Chage();
                }
            }

            //5
            if (Person_5 == true)
            {
                // Gray 이미지 색상이 있는 Item_Color 배열에서 해당 아이템 찾기
                foreach (var item in bag_item.item_color)
                {
                    if (item.Gray_Image.color.Equals(new Color32(253, 170, 170, 255)))
                    {
                        // 해당 아이템의 이름 가져오기
                        string itemName = item.itemName;

                        // 해당 아이템이 존재하는지 확인하고 개수를 가져옴
                        int itemQuantity = bag_item.GetItemQuantity(itemName);

                        if (itemQuantity > 0)
                        {
                            // 아이템 개수 1 감소
                            bag_item.AddItem(itemName, -1);

                            // 감소한 개수로 Gift_Save에 저장
                            Gift_5_Save(itemName, 1);

                            Debug.Log($"{itemName}이(가) 1만큼 감소되었습니다. 남은 개수: { bag_item.itemQuantities[itemName]}");
                            item.Item_Click();

                        }
                        else
                        {
                            Debug.Log($"{itemName}의 수량이 부족합니다.");
                        }

                        break; // 찾았으면 반복 종료
                    }
                }

                //개수에 따른 색 업데이트
                for (int i = 0; i < Bag_Item.instance.item_color.Length; i++)
                {
                    //버튼 누를 때, 아이템별로 몇 개 있는지에 따라 색 변하는 걸로
                    //Update에 코드가 있으니 이상해서 이 스크립트로 옮김
                    Bag_Item.instance.item_color[i].Color_Chage();
                }
            }
        }

        else
        {
            Debug.Log("선물을 줄 사람을 만나지 않은 상태입니다.");
        }

    }

    // Gift_Save: 감소된 아이템을 저장하는 함수
    //1
    public void Gift_1_Save(string itemName, int decreasedQuantity)
    {
        string newItemName = $"{itemName}";
        Person1_AddItem(newItemName, decreasedQuantity);
        Save_Person_1_Item();
        Debug.Log($"감소된 아이템 1번 사람이 받았음: {newItemName}, 수량: {decreasedQuantity}");
        

        /*if(newItemName == "석류")
        {
            Debug.Log($"아닛, 이건...?! {newItemName}잖아! 고마워!!");
        }

        //
        else if(newItemName == "복숭아")
        {
            Debug.Log("윽...");
        }

        else
        {
            Debug.Log($"{newItemName}... 이거 나한테 주는 거야? 고마워, 잘 받을게!");
        }*/

       /* switch (newItemName)
        {
            //좋아하는 거 선물
            case "딸기":
                Debug.Log($"어?! 때마침 {newItemName} 먹고싶었는데, 고마워! 케이크에 올려 ");
                if(decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 3;
                }
                break;
            case "오렌지":
                Debug.Log($"앗, {newItemName}잖아! 진짜 받아도 돼? 음...! 시큼하지만 달달한 이 맛...! 맛있어!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 3;
                }
                break;
            case "키위":
                Debug.Log($"이건... {newItemName}잖아! 마침 키위주스가 먹고 싶었는데, 갈아먹어야 겠다. 고마워!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 3;
                }
                break;
            case "느타리 버섯":
                Debug.Log($"세상에... 내가 {newItemName}먹고싶어했던 거 어떻게 알고! 된장국에 넣어 먹어야지!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 3;
                }
                break;
            case "고구마":
                Debug.Log($"이거... 나한테 주는 거야? 진짜 겨울에 군{newItemName} 없으면 못 사는데, 정말 고마워!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 3;
                }
                break;
            case "옥수수":
                Debug.Log($"{newItemName}잖아! 중얼중얼... 이걸로 팝콘을 해먹을까, 아니면 쪄먹을까... 아...! 맛있게 먹을게!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 3;
                }
                break;
            case "갑오징어":
                Debug.Log($"이게 {newItemName}구나...! 한 번 먹어보고 싶었는데, 잘 먹을게!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 3;
                }
                break;
            case "참치":
                Debug.Log($"{newItemName}는 통조림으로만 봤는데, 정말 크구나...! 헤헤 맛있게 잘 먹을게!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 3;
                }
                break;
            case "등심":
                Debug.Log($"아닛, 이건...?! {newItemName}잖아! 고마워!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 3;
                }
                break;
            case "스테이크":
                Debug.Log($"아닛, 이건...?! {newItemName}잖아! 고마워!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 3;
                }
                break;
            case "갈비살":
                Debug.Log($"아닛, 이건...?! {newItemName}잖아! 고마워!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 3;
                }
                break;
            case "완두콩":
                Debug.Log($"아닛, 이건...?! {newItemName}잖아! 고마워!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 3;
                }
                break;
            case "건포도":
                Debug.Log($"아닛, 이건...?! {newItemName}잖아! 고마워!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 3;
                }
                break;
            case "참깨":
                Debug.Log($"아닛, 이건...?! {newItemName}잖아! 고마워!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 3;
                }
                break;
            case "소금":
                Debug.Log($"아닛, 이건...?! {newItemName}잖아! 고마워!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 3;
                }
                break;

            //싫어하는 것
            case "모과":
                Debug.Log($"이건 ...{newItemName}? 으음...! 잘 받을게.");
                Like_Slider.instance.Person_Like_Slider[0].value -= 5;
                break;
            case "망고":
                Debug.Log($"이건 ...{newItemName}? 으음...! 잘 받을게.");
                Like_Slider.instance.Person_Like_Slider[0].value -= 5;
                break;
            case "레몬":
                Debug.Log($"이건 ...{newItemName}? 으음...! 잘 받을게.");
                Like_Slider.instance.Person_Like_Slider[0].value -= 5;
                break;
            case "블랙베리":
                Debug.Log($"이건 ...{newItemName}? 으음...! 잘 받을게.");
                Like_Slider.instance.Person_Like_Slider[0].value -= 5;
                break;
            case "마늘":
                Debug.Log($"이건 ...{newItemName}? 일단 잘 받을게.");
                Like_Slider.instance.Person_Like_Slider[0].value -= 5;
                break;
            case "셀러리":
                Debug.Log($"이건 ...{newItemName}? 맛있으려나...? 일단 잘 받을게.");
                Like_Slider.instance.Person_Like_Slider[0].value -= 5;
                break;
            case "근대":
                Debug.Log($"이건 ...{newItemName}? 으음...! 잘 받을게.");
                Like_Slider.instance.Person_Like_Slider[0].value -= 5;
                break;
            case "아티초크":
                Debug.Log($"이건 ...{newItemName}? 어떻게 먹어야 하지... 일단 잘 받을게.");
                Like_Slider.instance.Person_Like_Slider[0].value -= 5;
                break;
            case "장어":
                Debug.Log($"이건 ...{newItemName}? 으음...! 잘 받을게.");
                Like_Slider.instance.Person_Like_Slider[0].value -= 5;
                break;
            case "검정콩":
                Debug.Log($"이건 ...{newItemName}? 이걸로 뭘 해먹지... 콩밥은 싫고... 일단 잘 받을게.");
                Like_Slider.instance.Person_Like_Slider[0].value -= 5;
                break;
            case "대추":
                Debug.Log($"이건 ...{newItemName}? 맛있어 보이진 않는데... 일단 잘 받을게.");
                Like_Slider.instance.Person_Like_Slider[0].value -= 5;
                break;
            case "호박씨":
                Debug.Log($"이건 ...{newItemName}? 이 딱딱한 걸 어떻게 먹어야 하려나... 일단 잘 받을게.");
                Like_Slider.instance.Person_Like_Slider[0].value -= 5;
                break;
            case "육두구":
                Debug.Log($"이건 ...{newItemName}? 으음...! 잘 받을게.");
                Like_Slider.instance.Person_Like_Slider[0].value -= 5;
                break;
            case "정향":
                Debug.Log($"이건 ...{newItemName}? 으음...! 잘 받을게.");
                Like_Slider.instance.Person_Like_Slider[0].value -= 5;
                break;
            case "샤프란":
                Debug.Log($"이건...{ newItemName}? 으음...!잘 받을게.");
                Like_Slider.instance.Person_Like_Slider[0].value -= 5;
                break;

            //좋고, 싫고 상관없이 다른 아이템을 줬을 때
            default:
                Debug.Log($"오... 이거 나한테 주는 거야? {newItemName} 잘 받을게!");
                break;
        }*/

       


    }

    //2 -> 제빵사
    public void Gift_2_Save(string itemName, int decreasedQuantity)
    {
        string newItemName = $"{itemName}";
        Person2_AddItem(newItemName, decreasedQuantity);
        Save_Person_2_Item();
        Debug.Log($"감소된 아이템 2번 사람이 받았음: {newItemName}, 수량: {decreasedQuantity}");

        /*switch (newItemName)
        {
            //좋아하는 거 선물
            case "용과":
                Debug.Log($"아닛, 이건...?! {newItemName}잖아! 고마워!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 3;
                }
                break;
            case "코코넛":
                Debug.Log($"아닛, 이건...?! {newItemName}잖아! 고마워!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 3;
                }
                break;
            case "시금치":
                Debug.Log($"아닛, 이건...?! {newItemName}잖아! 고마워!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 3;
                }
                break;
            case "호밀":
                Debug.Log($"아닛, 이건...?! {newItemName}잖아! 고마워!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 3;
                }
                break;
            case "피칸":
                Debug.Log($"아닛, 이건...?! {newItemName}잖아! 고마워!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 3;
                }
                break;
            case "캐슈넛":
                Debug.Log($"아닛, 이건...?! {newItemName}잖아! 고마워!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 3;
                }
                break;
            case "로크포르 치즈":
                Debug.Log($"아닛, 이건...?! {newItemName}잖아! 고마워!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 3;
                }
                break;
            case "파르메산 치즈":
                Debug.Log($"아닛, 이건...?! {newItemName}잖아! 고마워!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 3;
                }
                break;
            case "계피":
                Debug.Log($"아닛, 이건...?! {newItemName}잖아! 고마워!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 3;
                }
                break;
            case "바닐라":
                Debug.Log($"아닛, 이건...?! {newItemName}잖아! 고마워!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 3;
                }
                break;
            case "생강":
                Debug.Log($"아닛, 이건...?! {newItemName}잖아! 고마워!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 3;
                }
                break;
            case "오레가노":
                Debug.Log($"아닛, 이건...?! {newItemName}잖아! 고마워!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 3;
                }
                break;
            case "이스트":
                Debug.Log($"아닛, 이건...?! {newItemName}잖아! 고마워!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 3;
                }
                break;
            case "달걀":
                Debug.Log($"아닛, 이건...?! {newItemName}잖아! 고마워!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 3;
                }
                break;
            case "와인":
                Debug.Log($"아닛, 이건...?! {newItemName}잖아! 고마워!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 3;
                }
                break;

            //싫어하는 것
            case "커런트":
                Debug.Log($"이건 ...{newItemName}? 으음...! 잘 받을게.");
                Like_Slider.instance.Person_Like_Slider[1].value -= 5;
                break;
            case "자몽":
                Debug.Log($"이건 ...{newItemName}? 으음...! 잘 받을게.");
                Like_Slider.instance.Person_Like_Slider[1].value -= 5;
                break;
            case "무화과":
                Debug.Log($"이건 ...{newItemName}? 으음...! 잘 받을게.");
                Like_Slider.instance.Person_Like_Slider[1].value -= 5;
                break;
            case "고추":
                Debug.Log($"이건 ...{newItemName}? 으음...! 잘 받을게.");
                Like_Slider.instance.Person_Like_Slider[1].value -= 5;
                break;
            case "가지":
                Debug.Log($"이건 ...{newItemName}? 일단 잘 받을게.");
                Like_Slider.instance.Person_Like_Slider[1].value -= 5;
                break;
            case "트러플":
                Debug.Log($"이건 ...{newItemName}? 일단 잘 받을게.");
                Like_Slider.instance.Person_Like_Slider[1].value -= 5;
                break;
            case "루꼴라":
                Debug.Log($"이건 ...{newItemName}? 일단 잘 받을게.");
                Like_Slider.instance.Person_Like_Slider[1].value -= 5;
                break;
            case "오이":
                Debug.Log($"이건 ...{newItemName}? 일단 잘 받을게.");
                Like_Slider.instance.Person_Like_Slider[1].value -= 5;
                break;
            case "녹색 렌틸콩":
                Debug.Log($"이건 ...{newItemName}? 일단 잘 받을게.");
                Like_Slider.instance.Person_Like_Slider[1].value -= 5;
                break;
            case "치아시드":
                Debug.Log($"이건 ...{newItemName}? 일단 잘 받을게.");
                Like_Slider.instance.Person_Like_Slider[1].value -= 5;
                break;
            case "겨자":
                Debug.Log($"이건 ...{newItemName}? 일단 잘 받을게.");
                Like_Slider.instance.Person_Like_Slider[1].value -= 5;
                break;
            case "와사비":
                Debug.Log($"이건 ...{newItemName}? 일단 잘 받을게.");
                Like_Slider.instance.Person_Like_Slider[1].value -= 5;
                break;
            case "식초":
                Debug.Log($"이건 ...{newItemName}? 일단 잘 받을게.");
                Like_Slider.instance.Person_Like_Slider[1].value -= 5;
                break;
            case "머스타드":
                Debug.Log($"이건 ...{newItemName}? 일단 잘 받을게.");
                Like_Slider.instance.Person_Like_Slider[1].value -= 5;
                break;
            case "케첩":
                Debug.Log($"이건 ...{newItemName}? 일단 잘 받을게.");
                Like_Slider.instance.Person_Like_Slider[1].value -= 5;
                break;

            //좋고, 싫고 상관없이 다른 아이템을 줬을 때
            default:
                Debug.Log($"오... 이거 나한테 주는 거야? {newItemName} 잘 받을게!");
                break;
               
        }*/
    }

    //3
    public void Gift_3_Save(string itemName, int decreasedQuantity)
    {
        string newItemName = $"{itemName}";
        Person3_AddItem(newItemName, decreasedQuantity);
        Save_Person_3_Item();
        Debug.Log($"감소된 아이템 3번 사람이 받았음: {newItemName}, 수량: {decreasedQuantity}");
    }

    //4
    public void Gift_4_Save(string itemName, int decreasedQuantity)
    {
        string newItemName = $"{itemName}";
        Person4_AddItem(newItemName, decreasedQuantity);
        Save_Person_4_Item();
        Debug.Log($"감소된 아이템 4번 사람이 받았음: {newItemName}, 수량: {decreasedQuantity}");
    }

    //5
    public void Gift_5_Save(string itemName, int decreasedQuantity)
    {
        string newItemName = $"{itemName}";
        Person5_AddItem(newItemName, decreasedQuantity);
        Save_Person_5_Item();
        Debug.Log($"감소된 아이템 5번 사람이 받았음: {newItemName}, 수량: {decreasedQuantity}");
    }


    /// ***************************************************************************************
    private void Person1_AddItem(string itemName, int quantity)
    {
        // 키가 존재하지 않을 경우에만 추가
        if (!Person_1_Item.ContainsKey(itemName))
        {
            Person_1_Item.Add(itemName, quantity); // 새로운 키와 값을 추가

            if (itemName == "딸기" || itemName == "오렌지" || itemName == "키위" || itemName == "느타리 버섯" || itemName == "고구마"
                || itemName == "옥수수" || itemName == "갑오징어" || itemName == "참치" || itemName == "등심" || itemName == "스테이크"
                || itemName == "갈비살" || itemName == "완두콩" || itemName == "건포도" || itemName == "참깨" || itemName == "소금")
            {
                Like_Slider.instance.Person_Like_Slider[0].value += 7;
            }

            else if (itemName == "모과" || itemName == "망고" || itemName == "레몬" || itemName == "블랙베리" || itemName == "마늘"
                || itemName == "셀러리" || itemName == "근대" || itemName == "아트초크" || itemName == "장어" || itemName == "검정콩"
                || itemName == "대추" || itemName == "호박씨" || itemName == "육두구" || itemName == "정향" || itemName == "샤프란")
            {
                Like_Slider.instance.Person_Like_Slider[0].value -= 5;
            }

            else
            {
                Debug.Log("호감도 유지");
            }

        }
        else
        {
            Person_1_Item[itemName] += quantity; // 기존 키의 값을 업데이트

            if (itemName == "딸기" || itemName == "오렌지" || itemName == "키위" || itemName == "느타리 버섯" || itemName == "고구마"
                || itemName == "옥수수" || itemName == "갑오징어" || itemName == "참치" || itemName == "등심" || itemName == "스테이크"
                || itemName == "갈비살" || itemName == "완두콩" || itemName == "건포도" || itemName == "참깨" || itemName == "소금")
            {
                Like_Slider.instance.Person_Like_Slider[0].value += 3;
            }

            else if (itemName == "모과" || itemName == "망고" || itemName == "레몬" || itemName == "블랙베리" || itemName == "마늘"
                || itemName == "셀러리" || itemName == "근대" || itemName == "아트초크" || itemName == "장어" || itemName == "검정콩"
                || itemName == "대추" || itemName == "호박씨" || itemName == "육두구" || itemName == "정향" || itemName == "샤프란")
            {
                Like_Slider.instance.Person_Like_Slider[0].value -= 5;
            }

            else
            {

                return;
                //Debug.Log("호감도 유지");
            }

        }

       

    }

    private void Person2_AddItem(string itemName, int quantity)
    {
        // 키가 존재하지 않을 경우에만 추가
        if (!Person_2_Item.ContainsKey(itemName))
        {
            Person_2_Item.Add(itemName, quantity); // 새로운 키와 값을 추가

            if (itemName == "용과" || itemName == "코코넛" || itemName == "시금치" || itemName == "호밀" || itemName == "피칸"
               || itemName == "케슈넛" || itemName == "로크포르 치즈" || itemName == "파르메산 치즈" || itemName == "계피" || itemName == "바닐라"
               || itemName == "생강" || itemName == "오레가노" || itemName == "이스트" || itemName == "달걀" || itemName == "와인")
            {
                Like_Slider.instance.Person_Like_Slider[1].value += 7;
            }

            else if (itemName == "커런트" || itemName == "자몽" || itemName == "무화과" || itemName == "고추" || itemName == "가지"
                || itemName == "트러플" || itemName == "루꼴라" || itemName == "오이" || itemName == "녹색 렌틸콩" || itemName == "치아시드"
                || itemName == "겨자" || itemName == "와사비" || itemName == "식초" || itemName == "머스타드" || itemName == "케첩")
            {
                Like_Slider.instance.Person_Like_Slider[1].value -= 5;
            }

            else
            {
                return;
               // Debug.Log("호감도 유지");
            }

        }
        else
        {
            Person_2_Item[itemName] += quantity; // 기존 키의 값을 업데이트

            if (itemName == "용과" || itemName == "코코넛" || itemName == "시금치" || itemName == "호밀" || itemName == "피칸"
               || itemName == "케슈넛" || itemName == "로크포르 치즈" || itemName == "파르메산 치즈" || itemName == "계피" || itemName == "바닐라"
               || itemName == "생강" || itemName == "오레가노" || itemName == "이스트" || itemName == "달걀" || itemName == "와인")
            {
                Like_Slider.instance.Person_Like_Slider[1].value += 3;
            }

            else if (itemName == "커런트" || itemName == "자몽" || itemName == "무화과" || itemName == "고추" || itemName == "가지"
                || itemName == "트러플" || itemName == "루꼴라" || itemName == "오이" || itemName == "녹색 렌틸콩" || itemName == "치아시드"
                || itemName == "겨자" || itemName == "와사비" || itemName == "식초" || itemName == "머스타드" || itemName == "케첩")
            {
                Like_Slider.instance.Person_Like_Slider[1].value -= 5;
            }

            else
            {
                return;
                //Debug.Log("호감도 유지");
            }
        }

    }

    private void Person3_AddItem(string itemName, int quantity)
    {
        // 키가 존재하지 않을 경우에만 추가
        if (!Person_3_Item.ContainsKey(itemName))
        {
            Person_3_Item.Add(itemName, quantity); // 새로운 키와 값을 추가
        }
        else
        {
            Person_3_Item[itemName] += quantity; // 기존 키의 값을 업데이트
        }

    }

    private void Person4_AddItem(string itemName, int quantity)
    {
        // 키가 존재하지 않을 경우에만 추가
        if (!Person_4_Item.ContainsKey(itemName))
        {
            Person_4_Item.Add(itemName, quantity); // 새로운 키와 값을 추가
        }
        else
        {
            Person_4_Item[itemName] += quantity; // 기존 키의 값을 업데이트
        }

    }

    private void Person5_AddItem(string itemName, int quantity)
    {
        // 키가 존재하지 않을 경우에만 추가
        if (!Person_5_Item.ContainsKey(itemName))
        {
            Person_5_Item.Add(itemName, quantity); // 새로운 키와 값을 추가
        }
        else
        {
            Person_5_Item[itemName] += quantity; // 기존 키의 값을 업데이트
        }

    }

    //캐릭터별로 받은 아이템 내용 저장
    public void Save_Person_1_Item()
    {
        //아이템 수량 저장

        //딕셔너리를 리스트로 변환
        List<Item_1_Person> items_1 = Person_1_Item.Select(item_1 => new Item_1_Person(item_1.Key, item_1.Value)).ToList();

        string json_1 = JsonUtility.ToJson(new List_1_Person(items_1), true);
        string path_1 = Path.Combine(Application.persistentDataPath, "Person_1_Item.json");
        File.WriteAllText(path_1, json_1);

       // Debug.Log($"1번 사람 아이템 개수 저장됨: {json_1}"); // 저장된 JSON 로그 

        Dictionary<string, int> itemIndexMap = new Dictionary<string, int>
    {     //아이템 이름과 그에 대응하는 인덱스를 매핑하는 딕셔너리


        { "딸기", 0 },
        { "오렌지", 1 },
        { "키위", 2 },
        { "느타리 버섯", 3 },
        { "고구마", 4 },
        { "옥수수", 5 },
        { "갑오징어", 6 },
        { "참치", 7 },
        { "등심", 8 },
        { "스테이크", 9 },
        { "갈비살", 10 },
        { "완두콩", 11 },
        { "건포도", 12 },
        { "참깨", 13 },
        { "소금", 14 },

        { "모과", 15 },
        { "망고", 16 },
        { "레몬", 17 },
        { "블랙베리", 18 },
        { "마늘", 19 },
        { "셀러리", 20 },
        { "근대", 21 },
        { "아티초크", 22 },
        { "장어", 23 },
        { "검정콩", 24 },
        { "대추", 25 },
        { "호박씨", 26 },
        { "육두구", 27 },
        { "정향", 28 },
        { "샤프란", 29 }

    };

        foreach (var item in itemIndexMap)//딕셔너리를 반복하면서
        {
            string itemName = item.Key;  // 아이템 이름
            int index = item.Value;      // 해당 아이템의 인덱스

            // 해당 아이템이 존재하지 않고 타이핑이 11 이상인 경우
            if (!Person_1_Item.ContainsKey(itemName))// && Typing.instance.Sentences_0 > 10)
            {
                Item_Hint.instance.Lock_Image[index].SetActive(true);   // 자물쇠 이미지 활성화
                Item_Hint.instance.Item_Image[index].SetActive(false);  // 아이템 이미지 비활성화
                Item_Hint.instance.Item_Button[index].enabled = true;   // 버튼 활성화
            }
            // 해당 아이템이 존재하지 않고 타이핑이 10 이하인 경우
            else if (!Person_1_Item.ContainsKey(itemName)) //&& Typing.instance.Sentences_0 <= 10)
            {
                Item_Hint.instance.Lock_Image[index].SetActive(true);   // 자물쇠 이미지 활성화
                Item_Hint.instance.Item_Image[index].SetActive(false);  // 아이템 이미지 비활성화
                Item_Hint.instance.Item_Button[index].enabled = false;  // 버튼 비활성화
            }
            // 해당 아이템이 존재하는 경우
            else if (Person_1_Item.ContainsKey(itemName))
            {
                Item_Hint.instance.Lock_Image[index].SetActive(false);  // 자물쇠 이미지 비활성화
                Item_Hint.instance.Item_Image[index].SetActive(true);   // 아이템 이미지 활성화
                Item_Hint.instance.Item_Button[index].enabled = false;  // 버튼 비활성화
            }
        }



    }

    public void Save_Person_2_Item()
    {
        //2번 사람
        //아이템 수량 저장

        //딕셔너리를 리스트로 변환
        List<Item_2_Person> items_2 = Person_2_Item.Select(item_2 => new Item_2_Person(item_2.Key, item_2.Value)).ToList();

        string json_2 = JsonUtility.ToJson(new List_2_Person(items_2), true);
        string path_2 = Path.Combine(Application.persistentDataPath, "Person_2_Item.json");
        File.WriteAllText(path_2, json_2);

        //Debug.Log($"2번 사람 아이템 개수 저장됨: {json_2}"); // 저장된 JSON 로그 

        Dictionary<string, int> itemIndexMap = new Dictionary<string, int>
    {     //아이템 이름과 그에 대응하는 인덱스를 매핑하는 딕셔너리


        { "용과", 30 },
        { "코코넛", 31 },
        { "시금치", 32 },
        { "호밀", 33 },
        { "피칸", 34 },
        { "캐슈넛", 35 },
        { "로크포르 치즈", 36 },
        { "파르메산 치즈", 37 },
        { "계피", 38 },
        { "바닐라", 39 },
        { "생강", 40 },
        { "오레가노", 41 },
        { "이스트", 42 },
        { "달걀", 43 },
        { "와인", 44 },

        { "커런트", 45 },
        { "자몽", 46 },
        { "무화과", 47 },
        { "고추", 48 },
        { "가지", 49 },
        { "트러플", 50 },
        { "루꼴라", 51 },
        { "오이", 52 },
        { "녹색 렌틸콩", 53 },
        { "치아시드", 54 },
        { "겨자", 55 },
        { "와사비", 56 },
        { "식초", 57 },
        { "머스타드", 58 },
        { "케첩", 59 }
        // 여기에 다른 아이템들도 추가
    };

        foreach (var item in itemIndexMap)//딕셔너리를 반복하면서
        {
            string itemName = item.Key;  // 아이템 이름
            int index = item.Value;      // 해당 아이템의 인덱스

            // 해당 아이템이 존재하지 않고 타이핑이 11 이상인 경우
            if (!Person_2_Item.ContainsKey(itemName)) //&& Typing.instance.Sentences_0 > 10)
            {
                Item_Hint.instance.Lock_Image[index].SetActive(true);   // 자물쇠 이미지 활성화
                Item_Hint.instance.Item_Image[index].SetActive(false);  // 아이템 이미지 비활성화
                Item_Hint.instance.Item_Button[index].enabled = true;   // 버튼 활성화
            }
            // 해당 아이템이 존재하지 않고 타이핑이 10 이하인 경우
            else if (!Person_2_Item.ContainsKey(itemName)) // && Typing.instance.Sentences_0 <= 10)
            {
                Item_Hint.instance.Lock_Image[index].SetActive(true);   // 자물쇠 이미지 활성화
                Item_Hint.instance.Item_Image[index].SetActive(false);  // 아이템 이미지 비활성화
                Item_Hint.instance.Item_Button[index].enabled = false;  // 버튼 비활성화
            }
            // 해당 아이템이 존재하는 경우
            else if (Person_2_Item.ContainsKey(itemName))
            {
                Item_Hint.instance.Lock_Image[index].SetActive(false);  // 자물쇠 이미지 비활성화
                Item_Hint.instance.Item_Image[index].SetActive(true);   // 아이템 이미지 활성화
                Item_Hint.instance.Item_Button[index].enabled = false;  // 버튼 비활성화
            }
        }
    }

    public void Save_Person_3_Item()
    {
        //3번 사람
        List<Item_3_Person> items_3 = Person_3_Item.Select(item_3 => new Item_3_Person(item_3.Key, item_3.Value)).ToList();

        string json_3 = JsonUtility.ToJson(new List_3_Person(items_3), true);
        string path_3 = Path.Combine(Application.persistentDataPath, "Person_3_Item.json");
        File.WriteAllText(path_3, json_3);

        //Debug.Log($"3번 사람 아이템 개수 저장됨: {json_3}"); // 저장된 JSON 로그
    }

    public void Save_Person_4_Item()
    {
        //4번 사람
        List<Item_4_Person> items_4 = Person_4_Item.Select(item_4 => new Item_4_Person(item_4.Key, item_4.Value)).ToList();

        string json_4 = JsonUtility.ToJson(new List_4_Person(items_4), true);
        string path_4 = Path.Combine(Application.persistentDataPath, "Person_4_Item.json");
        File.WriteAllText(path_4, json_4);

        //Debug.Log($"4번 사람 아이템 개수 저장됨: {json_4}"); // 저장된 JSON 로그
    }

    public void Save_Person_5_Item()
    { 
        //5번 사람
        List<Item_5_Person> items_5 = Person_5_Item.Select(item_5 => new Item_5_Person(item_5.Key, item_5.Value)).ToList();

        string json_5 = JsonUtility.ToJson(new List_5_Person(items_5), true);
        string path_5 = Path.Combine(Application.persistentDataPath, "Person_5_Item.json");
        File.WriteAllText(path_5, json_5);

        //Debug.Log($"5번 사람 아이템 개수 저장됨: {json_5}"); // 저장된 JSON 로그
    }

    public void Load_Person_Item()
    {
        // 저장된 파일의 경로 설정
        string path_1 = Path.Combine(Application.persistentDataPath, "Person_1_Item.json");
        string path_2 = Path.Combine(Application.persistentDataPath, "Person_2_Item.json");
        string path_3 = Path.Combine(Application.persistentDataPath, "Person_3_Item.json");
        string path_4 = Path.Combine(Application.persistentDataPath, "Person_4_Item.json");
        string path_5 = Path.Combine(Application.persistentDataPath, "Person_5_Item.json");

        // 파일이 존재하는지 확인
        if (File.Exists(path_1))
        {
            // 파일 내용을 읽어옴
            string json_1 = File.ReadAllText(path_1);

            List_1_Person itemList_1 = JsonUtility.FromJson<List_1_Person>(json_1);

            // 아이템 수량을 딕셔너리에 저장
            Person_1_Item = itemList_1.items_1.ToDictionary(item_1 => item_1.itemName, item_1 => item_1.item_quantity);

            // 로드된 내용을 로그에 출력
            //Debug.Log("1번째 사람이 갖고 있는 아이템 로드됨: " + json_1);
        }
        else if(!File.Exists(path_1))
        {
            // 파일이 존재하지 않을 경우 경고 메시지 출력
            //Debug.LogWarning("1번 사람이 받은 아이템이 없음.");

            // 모든 아이템 개수를 0으로 설정
            foreach (var item_1 in Person_1_Item.Keys.ToList())
            {
                Person_1_Item[item_1] = 0;
            }
        }

        //2
        if (File.Exists(path_2))
        {
            // 파일 내용을 읽어옴
            string json_2 = File.ReadAllText(path_2);

            List_2_Person itemList_2 = JsonUtility.FromJson<List_2_Person>(json_2);

            // 아이템 수량을 딕셔너리에 저장
            Person_2_Item = itemList_2.items_2.ToDictionary(item_2 => item_2.itemName, item_2 => item_2.item_quantity);

            // 로드된 내용을 로그에 출력
           // Debug.Log("2번째 사람이 갖고 있는 아이템 로드됨: " + json_2);
        }
        else if (!File.Exists(path_2))
        {
            // 파일이 존재하지 않을 경우 경고 메시지 출력
            //Debug.LogWarning("2번 사람이 받은 아이템이 없음.");

            // 모든 아이템 개수를 0으로 설정
            foreach (var item_2 in Person_2_Item.Keys.ToList())
            {
                Person_2_Item[item_2] = 0;
            }
        }

        //3
        if (File.Exists(path_3))
        {
            // 파일 내용을 읽어옴
            string json_3 = File.ReadAllText(path_3);

            List_3_Person itemList_3 = JsonUtility.FromJson<List_3_Person>(json_3);

            // 아이템 수량을 딕셔너리에 저장
            Person_3_Item = itemList_3.items_3.ToDictionary(item_3 => item_3.itemName, item_3 => item_3.item_quantity);

            // 로드된 내용을 로그에 출력
            //Debug.Log("3번째 사람이 갖고 있는 아이템 로드됨: " + json_3);
        }
        else if (!File.Exists(path_3))
        {
            // 파일이 존재하지 않을 경우 경고 메시지 출력
            //Debug.LogWarning("3번 사람이 받은 아이템이 없음.");

            // 모든 아이템 개수를 0으로 설정
            foreach (var item_3 in Person_3_Item.Keys.ToList())
            {
                Person_1_Item[item_3] = 0;
            }
        }

        //4
        if (File.Exists(path_4))
        {
            // 파일 내용을 읽어옴
            string json_4 = File.ReadAllText(path_4);

            List_4_Person itemList_4 = JsonUtility.FromJson<List_4_Person>(json_4);

            // 아이템 수량을 딕셔너리에 저장
            Person_4_Item = itemList_4.items_4.ToDictionary(item_4 => item_4.itemName, item_4 => item_4.item_quantity);

            // 로드된 내용을 로그에 출력
           // Debug.Log("4번째 사람이 갖고 있는 아이템 로드됨: " + json_4);
        }
        else if (!File.Exists(path_4))
        {
            // 파일이 존재하지 않을 경우 경고 메시지 출력
           // Debug.LogWarning("4번 사람이 받은 아이템이 없음.");

            // 모든 아이템 개수를 0으로 설정
            foreach (var item_4 in Person_4_Item.Keys.ToList())
            {
                Person_4_Item[item_4] = 0;
            }
        }

        //5
        if (File.Exists(path_5))
        {
            // 파일 내용을 읽어옴
            string json_5 = File.ReadAllText(path_5);

            List_5_Person itemList_5 = JsonUtility.FromJson<List_5_Person>(json_5);

            // 아이템 수량을 딕셔너리에 저장
            Person_5_Item = itemList_5.items_5.ToDictionary(item_5 => item_5.itemName, item_5 => item_5.item_quantity);

            // 로드된 내용을 로그에 출력
            //Debug.Log("5번째 사람이 갖고 있는 아이템 로드됨: " + json_5);
        }
        else if (!File.Exists(path_5))
        {
            // 파일이 존재하지 않을 경우 경고 메시지 출력
            //Debug.LogWarning("5번 사람이 받은 아이템이 없음.");

            // 모든 아이템 개수를 0으로 설정
            foreach (var item_5 in Person_5_Item.Keys.ToList())
            {
                Person_5_Item[item_5] = 0;
            }
        }
    }

    public void Reset_Person_Item()
    {
        string path_1 = Application.persistentDataPath + "/Person_1_Item.json";
        string path_2 = Application.persistentDataPath + "/Person_2_Item.json";
        string path_3 = Application.persistentDataPath + "/Person_3_Item.json";
        string path_4 = Application.persistentDataPath + "/Person_4_Item.json";
        string path_5 = Application.persistentDataPath + "/Person_5_Item.json";
        
        /*if (File.Exists(path_1))
        {//파일이 존재하는 경우

            File.Delete(path_1);

            //초기화 내용 적기
            foreach (var item_1 in Person_1_Item.Keys.ToList())
            {
                Person_1_Item[item_1] = 0;
            }

        }
        else if (!File.Exists(path_1))
        {
            Debug.Log("사람 1번 삭제할 아이템 데이터 없음");
        }
        */
        if (File.Exists(path_1))
        {
            // 파일이 존재하는 경우, 파일 삭제
            File.Delete(path_1);

            // 초기화: 아이템 이름과 개수를 모두 삭제
            foreach (var item_1 in Person_1_Item.Keys.ToList())
            {
                Person_1_Item.Remove(item_1); // 아이템 이름과 그에 대응하는 개수 삭제
            }

            Debug.Log("사람 1번의 모든 아이템과 개수 초기화됨");
        }
        else
        {
            Debug.Log("사람 1번 삭제할 아이템 데이터 없음");
        }

        //2
        if (File.Exists(path_2))
        {//파일이 존재하는 경우

            File.Delete(path_2);

            //초기화 내용 적기
            foreach (var item_2 in Person_2_Item.Keys.ToList())
            {
                Person_2_Item.Remove(item_2);//Person_2_Item[item_2] = 0;
            }

        }
        else if (!File.Exists(path_2))
        {
            Debug.Log("사람 2번 삭제할 아이템 데이터 없음");
        }

        //3
        if (File.Exists(path_3))
        {//파일이 존재하는 경우

            File.Delete(path_3);

            //초기화 내용 적기
            foreach (var item_3 in Person_3_Item.Keys.ToList())
            {
                Person_3_Item.Remove(item_3);//Person_3_Item[item_3] = 0;
            }

        }
        else if (!File.Exists(path_3))
        {
            Debug.Log("사람 3번 삭제할 아이템 데이터 없음");
        }

        //4
        if (File.Exists(path_4))
        {//파일이 존재하는 경우

            File.Delete(path_4);

            //초기화 내용 적기
            foreach (var item_4 in Person_4_Item.Keys.ToList())
            {
                Person_4_Item.Remove(item_4);//Person_4_Item[item_4] = 0;
            }

        }
        else if (!File.Exists(path_4))
        {
            Debug.Log("사람 4번 삭제할 아이템 데이터 없음");
        }

        //5
        if (File.Exists(path_5))
        {//파일이 존재하는 경우

            File.Delete(path_5);

            //초기화 내용 적기
            foreach (var item_5 in Person_5_Item.Keys.ToList())
            {
                Person_5_Item.Remove(item_5);//Person_5_Item[item_5] = 0;
            }

        }
        else if (!File.Exists(path_5))
        {
            Debug.Log("사람 5번 삭제할 아이템 데이터 없음");
        }

        Load_Person_Item();
        //Save_Person_1_Item();
        //Save_Person_2_Item();
        //Save_Person_3_Item();
        //Save_Person_4_Item();
        //Save_Person_5_Item();

        //리셋했을 때, 아이템 이미지 모두 비활성
        for (int i = 0; i < Item_Hint.instance.Item_Image.Length; i++)
        {
            Item_Hint.instance.Item_Image[i].SetActive(false);
        }

        //자물쇠 이미지 활성
        for (int i = 0; i < Item_Hint.instance.Lock_Image.Length; i++)
        {
            Item_Hint.instance.Lock_Image[i].SetActive(true);
        }

        //버튼 비활성
        for (int i = 0; i < Item_Hint.instance.Item_Button.Length; i++)
        {
            Item_Hint.instance.Item_Button[i].enabled = false;
        }
    }


    private void Start()
    {
        Load_Person_Item();
        /*Save_Person_1_Item();
        Save_Person_2_Item();
        Save_Person_3_Item();
        Save_Person_4_Item();
        Save_Person_5_Item();*/

    }

    private void FixedUpdate()
    {
        if(Person_1 == false && Person_2 == false & Person_3 == false
            & Person_4 == false & Person_5 == false)
        {
            //현재 아무하고도 만나지 않은 상태라면
            Gift_Text.text = "선물 불가";//텍스트 바꾸기
        }

        else
        {
            Gift_Text.text = "선물하기";//텍스트 바꾸기
        }

        Save_Person_1_Item();
        Save_Person_2_Item();
        Save_Person_3_Item();
        Save_Person_4_Item();
        Save_Person_5_Item();
    }
}
