using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System.IO;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RhythmGame_Reset_0 : MonoBehaviour
{
    private bool initialized = false; // 초기화 체크 변수

//윈터 0번 리듬게임 입장 시 리셋

    void Start()
    {
        // 현재 활성화된 씬 확인
        if (SceneManager.GetActiveScene().name == "Go_Rhythm" && !initialized)
        {
            InitializeGameSettings(); // 초기화 메서드 실행
            initialized = true; // 중복 실행 방지
            StartCoroutine(Go_Empty());
            StartCoroutine(Music_Go());
        }

       

        if (SceneManager.GetActiveScene().name == "Go_Rhythm")
        {
            // 애니메이터 상태 초기화
            Rhythm_Fade.instance.Fade_Anim.Rebind();

            // 페이드 아웃 실행
            Rhythm_Fade.instance.Fade.SetActive(true);
            Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Empty");
        }
    }

    void InitializeGameSettings()
    {
        Debug.Log("게임 초기화 시작");

        

        Winter_Music.instance.Winter_Songs[0].SetActive(true);

        for (int k = 0; k < Winter_Music.instance.Pause_Black.Length; k++)
        {
            Winter_Music.instance.Pause_Black[k].SetActive(false);
        }
        Winter_Music.instance.Pause.SetActive(false);

        // 점수 초기화
        foreach (var m in Winter_Music.instance.manager)
        {
            m.currentScore = 0.0f;
            m.Good_Hits = 0;
            m.Perfect_Hits = 0;
            m.Miss_Hits = 0;
            m.Long_Note_Miss = 0;
            m.ScoreText.text = "0.00%"; // 점수 리셋
        }

        // 롱 노트와 콜라이더 활성화
        for (int j = 0; j < Winter_Music.instance.Win_0_Long.Length; j++)
        {
            Winter_Music.instance.Win_0_Long[j].long_note_col[j].enabled = true;
            Winter_Music.instance.Win_0_Long_Fin[j].fin_col.enabled = true;
            ResetLongNotes(j);
        }

        // Winter_0_Note 활성화
        for (int i = 0; i < Winter_Music.instance.Winter_0_Note.Length; i++)
        {
            Winter_Music.instance.Winter_0_Note[i].SetActive(true);
        }

        // 노트 배열 초기화
        InitializeNotes();
    }

    void ResetLongNotes(int j)
    {
        //Winter_Music.instance.Win_0_Long[j].ResetTouchStatus_0();
        Winter_Music.instance.Win_0_Long[j].ResetTouch_Count_0();
        //Winter_Music.instance.Win_0_Long[j].ResetTouchStatus_1();
        Winter_Music.instance.Win_0_Long[j].ResetTouch_Count_1();
        Winter_Music.instance.Win_0_Long[j].ResetTouch_Count_2();
        Winter_Music.instance.Win_0_Long[j].ResetTouch_Count_3();
        Winter_Music.instance.Win_0_Long[j].ResetTouch_Count_4();
        Winter_Music.instance.Win_0_Long[j].ResetTouch_Count_5();
    }

    void InitializeNotes()
    {
        var NoteArrays = new List<Note_1105[]>()
        {
            Winter_Music.instance.Win_0_Note,
            // Win_1_Note, etc.
        };

        foreach (var array in NoteArrays)
        {
            for (int k = 0; k < array.Length; k++)
            {
                array[k].anim.SetTrigger("None");
                array[k].gameObject.SetActive(true);
                array[k].anim_count = 0;
            }
        }
    }

    public IEnumerator Go_Empty()
    {
        yield return new WaitForSecondsRealtime(0.7f);
        //Rhythm_Fade.instance.Fade.SetActive(true);
        //Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Empty");
        Debug.Log("페이드 아웃 되라고");

        // 필요시 추가 작업 (게임 관련 요소 비활성화 등)
    }

    public IEnumerator Music_Go()
    {
        yield return new WaitForSecondsRealtime(11.2f);//11.5보다는 작고
        Winter_Music.instance.Winter_Music_Obj[0].SetActive(true);
        Winter_Music.instance.Winter_Music_Audio[0].time = 0;//퍼즈 시간 초기화
                                                             //Winter_Music_Obj[0].SetActive(true);//윈터 0번째 음악 리듬게임 비활성
        Winter_Music.instance.Winter_Music_Audio[0].Play();

        //Note_1105.instance.YourClassName();//롱노트 미스 모두 초기화
    }


}
