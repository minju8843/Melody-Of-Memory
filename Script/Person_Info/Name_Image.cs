using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Name_Image : MonoBehaviour
{
    public TextMeshProUGUI[] tmpText;  // TMP 텍스트 컴포넌트
    public RectTransform[] tmpText_Rect;  // TMP 텍스트 RectTransform
    public RectTransform[] image;      // 이미지 RectTransform
    private float offsetX = 35f;      // 글자 끝에서 이미지까지의 고정 거리 (10px 정도로 설정)

    public static Name_Image instance;

    void Start()
    {
       
        instance = this;
    }

    public void Update_TextAndImagePosition()
    {
        for(int i = 0; i<tmpText.Length; i++)
        {
            // 텍스트의 Preferred Width 가져오기
            tmpText[i].ForceMeshUpdate();  // 텍스트 갱신
            float textWidth = tmpText[i].preferredWidth;

            // TMP 텍스트의 RectTransform 크기 조정
            RectTransform textRectTransform = tmpText_Rect[i];
            textRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, textWidth);

            // 텍스트 중앙 위치 계산
            float centerX = textWidth / 2f;

            // 이미지 위치를 텍스트 중앙에서 offsetX만큼 이동
            image[i].anchoredPosition = new Vector2(centerX + offsetX, image[i].anchoredPosition.y); // Y축 값은 이미지의 위치를 유지
        }

    }

}

