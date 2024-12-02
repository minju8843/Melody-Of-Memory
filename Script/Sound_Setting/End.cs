using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    public GameObject[] End_Panel;//게임 종료 화면
    public Image[] End_Panel_Image;//게임 종료 화면의 UI

    private void Start()
    {
        End_Panel[0].SetActive(false);//검은색
        End_Panel[1].SetActive(false);//갈색
    }

    private void Update()
    {
        //검은색 게임 종료

        //Esc키를 누른 상태인데, 현재 지도가 비활성화된 상태라면
        if (Input.GetButtonDown("Cancel") && Map.instance.map[0].activeSelf == false)
        {
            //게임을 종료하시겠습니까? 검은창 나오기, 갈색창 비활성
            End_Panel[0].SetActive(true);
            End_Panel[1].SetActive(false);

            //근데, 게임 종료 창 이전에 검은 화면이 있는 다른 창을 열었다면
            if (Setting.instance.Game_Reset.activeSelf == true || Hint.instance.Go_Hint.activeSelf == true
                    || Hint_Array_Active() || Map.instance.How_Map.activeSelf == true
                    || Bag_Item.instance.How_To_Use.activeSelf == true || Person_Btn.instance.Hint.activeSelf == true
                    || Change_Music.instance.Question.activeSelf == true || Item_Hint.instance.Hint_Panel.activeSelf == true
                    || Item_Hint.instance.Show_Panel.activeSelf == true 
                    || Select_Album.instance.Quest1.activeSelf == true || Select_Album.instance.Quest2.activeSelf == true)
            //게임 리셋하시겠습니까? 화면이 나와있는 상태라면
            //혹은 힌트를 보시겠습니까? 화면이 나와있는 상태라면
            {

                End_Panel_Image[0].color = new Color(0, 0, 0, 0);//색을 투명하게
            }

            else//그렇지 않다면 본래 색 유지
            {

                End_Panel_Image[0].color = new Color(0, 0, 0, 200f / 255f);
            }
        }

        //Esc키를 누른 상태인데, 현재 지도가 활성화된 상태라면

        if (Input.GetButtonDown("Cancel") && Map.instance.map[0].activeSelf == true)
        {
            //게임을 종료하시겠습니까? 갈색창 나오기, 검은창 비활성
            End_Panel[0].SetActive(false);
            End_Panel[1].SetActive(true);

            //근데, 게임 종료 창 이전에 검은 화면이 있는 다른 창을 열었다면
            if (Setting.instance.Game_Reset.activeSelf == true || Hint.instance.Go_Hint.activeSelf == true
                    || Hint_Array_Active() || Map.instance.How_Map.activeSelf == true
                    || Bag_Item.instance.How_To_Use.activeSelf == true|| Person_Btn.instance.Hint.activeSelf == true
                     || Change_Music.instance.Question.activeSelf == true || Item_Hint.instance.Hint_Panel.activeSelf == true
                     || Item_Hint.instance.Show_Panel.activeSelf == true
                     || Select_Album.instance.Quest1.activeSelf == true || Select_Album.instance.Quest2.activeSelf == true)
            //게임 리셋하시겠습니까? 화면이 나와있는 상태라면
            //혹은 힌트를 보시겠습니까? 화면이 나와있는 상태라면
            {
                End_Panel_Image[1].color = new Color(0, 0, 0, 0);//색을 투명하게
            }

            else//그렇지 않다면 본래 색 유지
            {

                End_Panel_Image[1].color = new Color(0, 0, 0, 200f / 255f);
            }
        }

    }


    bool Hint_Array_Active()//Hints배열 중 하나라도 활성화되어 있다면
    {
        foreach(GameObject hint in Hint.instance.Hints)
        {
            if(hint.activeSelf)
            {
                return true;//하나라도 활성화되어 있으면 true
            }
        }

        //끝까지 실행된 후에 아래 코드 실행됨
        return false;//모두 비활성화되어 있으면 false
    }

    public void End_Game_Yes()
    {
        //게임 종료 - 예
        //End_Panel[0].SetActive(false);
        //End_Panel[1].SetActive(false);

        End_Game();
    }

    public void End_Game_No()//
    {
        //게임 종료 - 아니오
        End_Panel[0].SetActive(false);
        End_Panel[1].SetActive(false);
    }

    public void End_Game()
    {
#if UNITY_EDITOR//유니티 에디터일 경우
        UnityEditor.EditorApplication.isPlaying = false;
#else//실제 어플일 경우
        Application.Quit(); // 어플리케이션 종료
#endif
    }

}
