using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button : MonoBehaviour
{
    //public GameObject[] Main_False;//비활성해야 할 것

    public Button[] btn;

    public GameObject Show_Three_Btn;//버튼 3개 모여있는 거
    //public Animator Menu_anim;//메뉴 버튼을 눌렀을 때, 위/아래로 내려올 애니메이션
    public int Menu_Touch_Count = 0;//메뉴 버튼을 몇 번 눌렀는지 -> 게임 시작하면 리셋됨

    //public GameObject HeadPhone;//음악 바꾸기 내용물
    //public GameObject Setting;//설정 내용물

    public static UI_Button instance;

    public Map map;
    public GameObject Bag; //Piano, Piano_Btn;//, Piano_Content;

    //public Swipe_1_fin swipe_1;

    //public GameObject album_bgm;

    private void Start()
    {
        Show_Three_Btn.SetActive(false);

        Winter_Music.instance.HeadPhone.SetActive(false);
        Winter_Music.instance.Setting.SetActive(false);//설정

        Bag.SetActive(false);//가방

        instance = this;
    }

    public void Go_Setting()
    {
        //설정란으로 이동
        SFX_Manager.instance.SFX_Button();
        Winter_Music.instance.Setting.SetActive(true);
    }

    public void Will_Go_Hint()
    {
        //힌트를 보시겠습니까? 화면
        SFX_Manager.instance.SFX_Button();
        Hint.instance.Go_Hint.SetActive(true);
    }

    public void Will_Sleep()
    {
        //잠을 잘 것인지? 즉, 꿈의 세상으로 갈 것인지에 대한 버튼
    }

    public void Go_Map()
    {
        SFX_Manager.instance.SFX_Button();

        //지도란으로 이동
        map.map[0].SetActive(true);
        map.map[1].SetActive(true);

        for (int i = 0; i < map.Nine_Image.Length; i++)
        {
            map.Nine_Image[i].SetActive(false);//아직 아무것도 선택되지 않은 걸로
        }

    }

    public void Go_HeadPhone()
    {
        SFX_Manager.instance.SFX_Button();
        //헤드폰 음악 바꾸는 창을 보여주기
        Winter_Music.instance.HeadPhone.SetActive(true);
    }

    public void Touch_Menu()
    {
        SFX_Manager.instance.SFX_Button();
        //메뉴 버튼을 눌렀을 때
        Menu_Touch_Count++;//횟수 추가

        if(Menu_Touch_Count % 2 == 0)
        {
            //만약에 횟수가 짝수라면
            //Menu_anim.SetTrigger("Up");
            //위로 올리기

            Show_Three_Btn.SetActive(false);
        }

        else if(Menu_Touch_Count % 2 == 1)
        {
            //만약에 횟수가 홀수라면
            //Menu_anim.SetTrigger("Down");
            //아래로 내려오기

            Show_Three_Btn.SetActive(true);
        }
    }

    public void Reset_Btn_Count()
    {
        Menu_Touch_Count = 0;
        Show_Three_Btn.SetActive(false);
    }

    public void Go_Bag()
    {
        SFX_Manager.instance.SFX_Button();
        //가방란으로 이동, 저장한 아이템 개수 제외 다 초기화
        Bag.SetActive(true);

       /* Bag_Item.instance.Current_Page = 0;//처음엔 0페이지
        for (int i = 1; i < Bag_Item.instance.Category.Length; i++)
        {
            Bag_Item.instance.Category[i].SetActive(false);
        }
        Bag_Item.instance.Category[0].SetActive(true);
        */
        //0페이지일 때는 0페이지 제외하고 나머지 페이지 비활성



        for (int i = 0; i < Bag_Item.instance.Select_Item.Length; i++)//오른쪽 이미지 나오는 거 비활성
        {
            Bag_Item.instance.Select_Item[i].SetActive(false);
        }

        for (int i = 0; i < Bag_Item.instance.item_color.Length; i++)//선택된거 다 초기화
        {
            Bag_Item.instance.item_color[i].Gray_Image.color = new Color32(255, 255, 255, 255);
        }

        //Bag_Item.instance.Category_Name.text = "과일";
        Bag_Item.instance.Item_Count.text = "보유: ?개";
        Bag_Item.instance.Item_Name.text = "???";

        for (int i = 0; i < Bag_Item.instance.item_color.Length; i++)
        {
            //아이템별로 몇 개 있는지에 따라 색 변하는 거
            Bag_Item.instance.item_color[i].Color_Chage();
        }
    }

    public void Go_Ch()
    {
        SFX_Manager.instance.SFX_Button();
        //캐릭터 정보란으로 이동
        for (int i = 0; i < Person_Btn.instance.Person_info.Length; i++)
        {
            Person_Btn.instance.Person_info[i].SetActive(true);//인물 정보 관련 모두 활성
        }

        Name_Image.instance.Update_TextAndImagePosition();//이름에 따라 깃털 위치 이동
    }

    public void Go_Play_Piano()
    {
        SFX_Manager.instance.SFX_Button();
        //페이드 인 & 아웃
        Rhythm_Fade.instance.Fade.SetActive(true);
        Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Black");

        StartCoroutine(Go_Game());
        IEnumerator Go_Game()
        {
            yield return new WaitForSeconds(0.9f);
            //피아노 연주란으로 이동
            Winter_Music.instance.Piano.SetActive(true);
            Winter_Music.instance.Piano_Btn.SetActive(true);
            //swipe_1.Reset();

            
            //swipe_1.previousBtnNumber = -1;
            //swipe_1.btnNumber = 0;
            //swipe_1.scrollbar.GetComponent<Scrollbar>().value = 0.0f;

            //swipe_1.GecisiDuzenle();

            // Piano_Content.SetActive(true);
            //Select_Album.instance.select_Album.SetActive(true);


            StartCoroutine(SetActive_Middle());
            //Title_Fade.instance.Fade_Anim.SetTrigger("Go_Empty");
            //StartCoroutine(SetActive_False());
        }

        IEnumerator SetActive_Middle()
        {
            yield return new WaitForSeconds(0.5f);
            Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Empty");

            //swipe_1.Load();
            //Debug.Log("리셋 되나?" + swipe_1.btnNumber);

            Change_Music.instance.Music_Col_Parent.SetActive(false);//일반 배경 음악 비활성
            //Select_Album.instance.BGM.SetActive(true);
            Winter_Music.instance.album_bgm.SetActive(true);

            StartCoroutine(SetActive_False());
        }

        IEnumerator SetActive_False()
        {
            yield return new WaitForSeconds(0.9f);//1.4
           // Title_Fade.instance.Fade_Canvas.SetActive(false);
            //Debug.Log("페이드 꺼져");
        }

       
    }
    
}
