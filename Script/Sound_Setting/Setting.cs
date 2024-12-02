using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Setting : MonoBehaviour
{

    public TextMeshProUGUI Credit_Text;
    public TextMeshProUGUI Reset_Text;

    //게임 리셋
    public GameObject Game_Reset;

    public static Setting instance;

    private void Start()
    {
        instance = this;
        Game_Reset.SetActive(false);
    }


    public void FixedUpdate()
    {
        /*if (Title_Fade.instance.Title_Canvas.activeSelf == true)//오류뜸
        {
            UI_Button.instance.Setting.SetActive(false);
        }*/
    }

    public void Go_Back()
    {
        Winter_Music.instance.Setting.SetActive(false);
        SFX_Manager.instance.SFX_Button();
    }

    public void Go_Reset()
    {
        Game_Reset.SetActive(true);
    }

    public void Reset_Btn_Y_N()//리셋 예, 아니오 둘다(리셋하는 건 다른 스크립트에 있음)
    {
        Game_Reset.SetActive(false);
    }


    //크레딧
    public void Credit_Pointer_Enter()//버튼 위에 마우스 올렸을 때
    {
        //200
        Credit_Text.color = new Color(200f / 255f, 200f / 255f, 200f / 255f, 255f / 255f);
    }

    public void Credit_PointerDown()//클릭
    {
        //160
        Credit_Text.color = new Color(160f / 255f, 160f / 255f, 160f / 255f, 255f / 255f);
        //리셋 버튼을 클릭했다면
    }


    public void Credit_Pointer_Click()//클릭하고 난 후
    {
        //255
        Credit_Text.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
    }

    public void Creditt_Pointer_Up()//마우스 내렸다가 올렸을 때
    {
        //255
        Credit_Text.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
    }

    public void Credit_Pointer_Exit()//마우스가 버튼에서 벗어났을 때
    {
        //255
        Credit_Text.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
    }

    //초기화 버튼
    public void Reset_Pointer_Enter()//버튼 위에 마우스 올렸을 때
    {
        //200
        Reset_Text.color = new Color(200f / 255f, 200f / 255f, 200f / 255f, 255f / 255f);
    }

    public void Reset_PointerDown()//클릭
    {
        //160
        Reset_Text.color = new Color(160f / 255f, 160f / 255f, 160f / 255f, 255f / 255f);
        //리셋 버튼을 클릭했다면
    }


    public void Reset_Pointer_Click()//클릭하고 난 후
    {
        //255
        Reset_Text.color = new Color(255f / 255f, 25f / 255f, 255f / 255f, 255f / 255f);
    }

    public void Reset_Pointer_Up()//마우스 내렸다가 올렸을 때
    {
        //255
        Reset_Text.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
    }

    public void Reset_Pointer_Exit()//마우스가 버튼에서 벗어났을 때
    {
        //255
        Reset_Text.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
    }
}
