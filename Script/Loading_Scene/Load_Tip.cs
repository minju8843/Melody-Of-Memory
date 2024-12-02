using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Load_Tip : MonoBehaviour
{
    public TextMeshProUGUI Tip_text;
    public string[] Tip_Collection;
    public float changeInterval = 2.0f; // 텍스트 변경 간격 (초 단위)
    //public string targetSceneName = "Loading_Scene";

    private Coroutine changeTextCoroutine;

    private void Start()
    {
        // 현재 씬 이름이 targetSceneName과 동일한 경우에만 동작
        //if (SceneManager.GetActiveScene().name == targetSceneName)
        //{
            if (Tip_Collection.Length > 0)
            {
                changeTextCoroutine = StartCoroutine(ChangeTextRoutine());
            }
        //}
    }

    private IEnumerator ChangeTextRoutine()
    {
        while (true)
        {
            // 텍스트 목록에서 무작위 선택
            string randomText = Tip_Collection[Random.Range(0, Tip_Collection.Length)];
            Tip_text.text = randomText;

            // 변경 간격 대기
            yield return new WaitForSeconds(changeInterval);
        }
    }

    private void OnDisable()
    {
        // 코루틴 중지 (씬이 변경되거나 오브젝트가 비활성화될 때)
        if (changeTextCoroutine != null)
        {
            StopCoroutine(changeTextCoroutine);
        }
    }
}
