using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title_Fade : MonoBehaviour
{
    public Button btn;

    public Typing typ;

    public GameObject Title_Canvas;
    public Animator picture_anim;
    public Animator Title_Text_Anim;
    public Animator Touch_Text_Anim;

    public GameObject Fade_Canvas;
    public Animator Fade_Anim;

    public GameObject Story_Canvas;

    public static Title_Fade instance;

    public void Start()
    {
        instance = this;

        //typ.Delete_Data();
        Story_Canvas.SetActive(false);//스토리 관련 캔버스 안 보이도록

        btn.enabled = true;
    }

    public void FixedUpdate()
    {
       /* if(Winter_Music.instance.Title.activeSelf==false)
        {
            Story_Canvas.SetActive(true);//0104
        }*/
    }

    public void Go_Game()
    {

        if (picture_anim.GetCurrentAnimatorStateInfo(0).IsName("Show_Picture0"))
        {
            //현재 실행중인 애니메이션 이름이 Show_Picture0 라면
            //즉 아직 애니메이션이 다 나오지 않았다면
            picture_anim.SetTrigger("Show_P");

            Title_Text_Anim.SetTrigger("Continue");
            Touch_Text_Anim.SetTrigger("Two");
        }

        if(picture_anim.GetCurrentAnimatorStateInfo(0).IsName("Show_Picture1"))
        {
            //정상적으로 애니메이션이 끝까지 진행되었다면
            //페이드 실행 및 게임 진행 고고
            btn.enabled = false;

            Fade_Anim.SetTrigger("Go_Black");

            StartCoroutine(Go_Black());
            IEnumerator Go_Black()
            {
                yield return new WaitForSeconds(1.5f);
                Title_Canvas.SetActive(false);
            }


            //여기서 게임을 불러와야 하나?
            StartCoroutine(Go_Game());
            IEnumerator Go_Game()
            {
                yield return new WaitForSeconds(2.25f);
                Fade_Anim.SetTrigger("Go_Empty");
                Story_Canvas.SetActive(true);//스토리 관련 캔버스 보이도록

                Winter_Music.instance.Setting.SetActive(false);//설정 비활성 0104

                //챕터1으로...
                if (Typing.instance.Sentences_0 >= 140)
                {

                    Typing.instance.Dia.SetActive(false);

                    Typing.instance.Chapter_1.SetActive(true);

                    //StartCoroutine(Wait_First_Sentence());
                    //IEnumerator Wait_First_Sentence()
                    //{
                        //yield return new WaitForSeconds(1.3f);
                    Typing.instance.Chapter_1_Pro_Typ.SetActive(true);

                    //Pro_Typing.instance.Load_Sentences_0();

                    Typing.instance.Sentences_0 = 142;
                    //Pro_Typing.instance.Load_Sentences_0();


                    //}
                }
                //스토리 중에 페이드 인 & 아웃 사용했을 때, 불러오는 기능
                //Typing코드에서 사용하면 대화창이 나오지 않는 문제 발생

                if (Typing.instance.Sentences_0 == 33)//Typing.instance.Sentences_0 == 34)
                {
                    Typing_Fade.instance.Sentences_0_33();//Typing_Fade.instance.Sentences_0_34();
                    //Fade_Anim.SetTrigger("Go_Empty");
                    //StartCoroutine(SetActive_False());

                }


                else
                {
                    Debug.Log("없음");
                }

                /*else if(Typing.instance.Sentences_0 != 33)
                {
                    Fade_Anim.SetTrigger("Go_Empty");
                    StartCoroutine(SetActive_False());
                }*/


                StartCoroutine(SetActive_False());
                //Pro_Typing.instance.Load_Sentences_0();
            }

            IEnumerator SetActive_False()
            {
                yield return new WaitForSeconds(1.35f);
                Fade_Canvas.SetActive(false);

                /*if (Typing.instance.Sentences_0 == 33)
                {
                    Typing_Fade.instance.Sentences_0_33();
                }*/

               
            }
        }
    }

    /*public void Go_Fade()
    {

    }*/
}
