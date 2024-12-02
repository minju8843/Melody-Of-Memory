using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Person_Btn : MonoBehaviour
{
    public int Page_Count = 0;
    public GameObject[] Person_Page;//인물 정보 페이지
    public GameObject[] Arrow;//오, 왼 버튼

    public GameObject Hint;//우측 위에 있는 ? UI -> 같은 아이템 주면 3%호감도 오름

    public GameObject[] Person_info;//인물 정보 관련 처음에 비활성화 해야 할 거

    public static Person_Btn instance;

    public void Start()
    {
        instance = this;

        Page_Count = 0;

        for(int i = 0; i< Person_info.Length; i++)
        {
            Person_info[i].SetActive(false);//인물 정보 관련 처음에는 비활성
        }

        Arrow[0].SetActive(false);//왼쪽 화살표 비활성
    }

    private void FixedUpdate()
    {
        //현재 페이지 카운트에 따른 해당 페이지 활성화
        for(int i = 0; i< Person_info.Length; i++)
        {
            if (i == Page_Count)
            {
                Person_Page[i].SetActive(true);            
            }

            else
            {
                Person_Page[i].SetActive(false);
            }
        }
    }

    public void About_favorability()//호감도 관련 ? 창 열기
    {
        SFX_Manager.instance.SFX_Button();
        Hint.SetActive(true);
    }

    public void Closde_favorability()//호감도 관련 ? 창 닫기
    {
        SFX_Manager.instance.SFX_Button();
        Hint.SetActive(false);
    }

    public void Back()
    {
        SFX_Manager.instance.SFX_Button();

        //뒤로가기 버튼
        for (int i = 0; i < Person_info.Length; i++)
        {
            Person_info[i].SetActive(false);//인물 정보 관련 비활성
        }
    }

    public void Next_Arrow()
    {
        SFX_Manager.instance.SFX_Button();

        //오른쪽 화살표
        if (0 <= Page_Count && Page_Count < Person_Page.Length - 1)
        {
            Page_Count++;
            for (int i = 0; i < Person_Page.Length; i++)
            {
                Person_Page[i].SetActive(false);//인물 정보 페이지
            }

            Person_Page[Page_Count].SetActive(true);

            Arrow[0].SetActive(true);

            Name_Image.instance.Update_TextAndImagePosition();
        }


        //마지막 이전 페이지라면, 다음 버튼 누를 때, 화살표 사라짐
        if (Page_Count == Person_Page.Length-1)
        {
            Arrow[1].SetActive(false);// [0]이 왼쪽 화살표, [1]이 오른쪽 화살표
        }

    }

    public void Back_Arrow()
    {
        SFX_Manager.instance.SFX_Button();

        //왼쪽 화살표
        if (0 < Page_Count && Page_Count < Person_Page.Length)
        {
            Page_Count--;
            for (int i = 0; i < Person_Page.Length; i++)
            {
                Person_Page[i].SetActive(false);//인물 정보 페이지
            }

            Person_Page[Page_Count].SetActive(true);

            Arrow[1].SetActive(true);
            Name_Image.instance.Update_TextAndImagePosition();
        }


        //맨 첫번째 페이지라면, 다음 버튼 누를 때, 화살표 사라짐
        if (Page_Count == 0)
        {
            Arrow[0].SetActive(false);// [0]이 왼쪽 화살표, [1]이 오른쪽 화살표
        }
    }
}
