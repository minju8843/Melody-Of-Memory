using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class NotePositionData
{
    public float PositionX;
    public float PositionY;
    public float PositionZ;
}

[System.Serializable]
public class AllInitialPositionsData
{
    public List<NotePositionData> InitialPositions = new List<NotePositionData>();
}

public class Win_Note_Pos : MonoBehaviour
{
    public Note_1105[] Win_0_Note;
    public Long_Note[] Win_0_Long;
    public Long_Col[] Win_0_Long_Fin;

    public static Win_Note_Pos instance;

    public void Start()
    {
        instance = this;
        Save_AllPositions();  // 초기 위치 저장 (필요할 경우 주석 처리)
        //Load_AllPositions();  // 위치 데이터 불러오기
    }

    public void Load_AllPositions()
    {
        string filePath = Application.persistentDataPath + "/Win_NotePositions.json";

        if (!File.Exists(filePath))
        {
            //Debug.LogWarning("저장된 위치 데이터 파일이 없습니다.");
            return;
        }

        // JSON 파일 읽기
        string jsonData = File.ReadAllText(filePath);
        AllInitialPositionsData allData = JsonUtility.FromJson<AllInitialPositionsData>(jsonData);

        int dataIndex = 0;

        // 1. 일반 노트 위치 불러오기
        var NoteArrays = new List<Note_1105[]>()
    {
        Win_0_Note,
        // Win_1_Note,
        // Win_2_Note,
        // Win_3_Note,
        // Win_4_Note
    };

        foreach (var array in NoteArrays)
        {
            foreach (var note in array)
            {
                if (note.rect != null && dataIndex < allData.InitialPositions.Count)
                {
                    float posX = allData.InitialPositions[dataIndex].PositionX;
                    float posY = allData.InitialPositions[dataIndex].PositionY;
                    float posZ = allData.InitialPositions[dataIndex].PositionZ;

                    note.rect.localPosition = new Vector3(posX, posY, posZ);

                    //Debug.Log($"일반 노트 위치 복원 - X: {posX}, Y: {posY}, Z: {posZ}");
                    dataIndex++;
                }
            }
        }

        // 2. 롱 노트 위치 불러오기
        var Long_NoteArrays = new List<Long_Note[]>()
    {
        Win_0_Long,
        // Win_1_Long,
        // Win_2_Long,
        // Win_3_Long,
        // Win_4_Long
    };

        foreach (var array in Long_NoteArrays)
        {
            foreach (var longNote in array)
            {
                if (longNote.rect != null && dataIndex < allData.InitialPositions.Count)
                {
                    float posX = allData.InitialPositions[dataIndex].PositionX;
                    float posY = allData.InitialPositions[dataIndex].PositionY;
                    float posZ = allData.InitialPositions[dataIndex].PositionZ;

                    longNote.rect.localPosition = new Vector3(posX, posY, posZ);

                    //Debug.Log($"롱 노트 위치 복원 - X: {posX}, Y: {posY}, Z: {posZ}");
                    dataIndex++;
                }
            }
        }

        // 3. 롱 노트 끝부분 위치 불러오기
        var Long_Col_NoteArrays = new List<Long_Col[]>()
    {
        Win_0_Long_Fin,
        // Win_1_Long_Fin,
        // Win_2_Long_Fin,
        // Win_3_Long_Fin,
        // Win_4_Long_Fin
    };

        foreach (var array in Long_Col_NoteArrays)
        {
            foreach (var longNoteFin in array)
            {
                if (longNoteFin.rect != null && dataIndex < allData.InitialPositions.Count)
                {
                    float posX = allData.InitialPositions[dataIndex].PositionX;
                    float posY = allData.InitialPositions[dataIndex].PositionY;
                    float posZ = allData.InitialPositions[dataIndex].PositionZ;

                    longNoteFin.rect.localPosition = new Vector3(posX, posY, posZ);

                   // Debug.Log($"롱 노트 끝부분 위치 복원 - X: {posX}, Y: {posY}, Z: {posZ}");
                    dataIndex++;
                }
            }
        }

        //Debug.Log("모든 위치가 복원되었습니다.");
    }


    public void Save_AllPositions()
    {
        var allData = new AllInitialPositionsData();

        // 일반 노트 위치 저장
        var NoteArrays = new List<Note_1105[]>()
    {
        Win_0_Note,
        // Win_1_Note,
        // Win_2_Note,
        // Win_3_Note,
        // Win_4_Note
    };

        foreach (var array in NoteArrays)
        {
            foreach (var note in array)
            {
                if (note.rect != null)
                {
                    NotePositionData data = new NotePositionData
                    {
                        PositionX = note.rect.localPosition.x,
                        PositionY = note.rect.localPosition.y,
                        PositionZ = note.rect.localPosition.z // Z 값 저장
                    };
                    allData.InitialPositions.Add(data);
                    //Debug.Log($"노트 위치 저장 - X: {data.PositionX}, Y: {data.PositionY}, Z: {data.PositionZ}");
                }
            }
        }

        // 롱 노트 위치 저장
        var Long_NoteArrays = new List<Long_Note[]>()
    {
        Win_0_Long,
        // Win_1_Long,
        // Win_2_Long,
        // Win_3_Long,
        // Win_4_Long
    };

        foreach (var array in Long_NoteArrays)
        {
            foreach (var longNote in array)
            {
                if (longNote.rect != null)
                {
                    NotePositionData data = new NotePositionData
                    {
                        PositionX = longNote.rect.localPosition.x,
                        PositionY = longNote.rect.localPosition.y,
                        PositionZ = longNote.rect.localPosition.z // Z 값 저장
                    };
                    allData.InitialPositions.Add(data);
                    //Debug.Log($"롱 노트 위치 저장 - X: {data.PositionX}, Y: {data.PositionY}, Z: {data.PositionZ}");
                }
            }
        }

        // 롱 노트 끝부분 위치 저장
        var Long_Col_NoteArrays = new List<Long_Col[]>()
    {
        Win_0_Long_Fin,
        // Win_1_Long_Fin,
        // Win_2_Long_Fin,
        // Win_3_Long_Fin,
        // Win_4_Long_Fin
    };

        foreach (var array in Long_Col_NoteArrays)
        {
            foreach (var longNoteFin in array)
            {
                if (longNoteFin.rect != null)
                {
                    NotePositionData data = new NotePositionData
                    {
                        PositionX = longNoteFin.rect.localPosition.x,
                        PositionY = longNoteFin.rect.localPosition.y,
                        PositionZ = longNoteFin.rect.localPosition.z // Z 값 저장
                    };
                    allData.InitialPositions.Add(data);
                    //Debug.Log($"롱 노트 끝부분 위치 저장 - X: {data.PositionX}, Y: {data.PositionY}, Z: {data.PositionZ}");
                }
            }
        }

        // JSON 파일로 저장
        string jsonData = JsonUtility.ToJson(allData, true);
        File.WriteAllText(Application.persistentDataPath + "/Win_NotePositions.json", jsonData);

        //Debug.Log("모든 위치가 저장되었습니다.");
    }



    /*public void Save_AllPositions()
    {
        AllInitialPositionsData allData = new AllInitialPositionsData();

        // 일반 노트 초기 위치 저장
        var NoteArrays = new List<Note_1105[]>()
    {
        Win_0_Note,
        // Win_1_Note,
        // Win_2_Note,
        // Win_3_Note,
        // Win_4_Note
    };

        foreach (var array in NoteArrays)
        {
            foreach (var note in array)
            {
                if (note.rect != null)
                {
                    NotePositionData data = new NotePositionData
                    {
                        PositionX = note.rect.localPosition.x,
                        PositionY = note.rect.localPosition.y,
                        PositionZ = note.rect.localPosition.z
                    };
                    allData.InitialPositions.Add(data);
                    Debug.Log($"일반 노트 위치 - X: {data.PositionX}, Y: {data.PositionY},  Z: {data.PositionZ}");
                }
            }
        }

        // 롱 노트 초기 위치 저장
        var Long_NoteArrays = new List<Long_Note[]>()
    {
        Win_0_Long,
        // Win_1_Long,
        // Win_2_Long,
        // Win_3_Long,
        // Win_4_Long
    };

        foreach (var array2 in Long_NoteArrays)
        {
            foreach (var longNote in array2)
            {
                if (longNote.rect != null)
                {
                    NotePositionData data = new NotePositionData
                    {
                        PositionX = longNote.rect.anchoredPosition.x,
                        PositionY = longNote.rect.anchoredPosition.y,
                        PositionZ = longNote.rect.localPosition.z
                    };
                    allData.InitialPositions.Add(data);
                    Debug.Log($"롱노트 위치 - X: {data.PositionX}, Y: {data.PositionY},  Z: {data.PositionZ}");
                }
            }
        }

        // 롱노트 끝부분 위치 저장 (NotePositionData로 저장)

        var Long_Col_NoteArrays = new List<Long_Col[]>
    {
        Win_0_Long_Fin
    };

        foreach (var array3 in Long_Col_NoteArrays)
        {
            foreach (var longNote_Fin in array3)
            {
                if (longNote_Fin.rect != null)
                {
                    NotePositionData data = new NotePositionData
                    {
                        PositionX = longNote_Fin.rect.anchoredPosition.x,
                        PositionY = longNote_Fin.rect.anchoredPosition.y,
                        PositionZ = longNote_Fin.rect.localPosition.z
                    };
                    allData.InitialPositions.Add(data);
                    Debug.Log($"롱노트 끝부분 위치 - X: {data.PositionX}, Y: {data.PositionY},  Z: {data.PositionZ}");
                }
            }
        }

        

        // JSON으로 변환 후 파일로 저장
        string jsonData = JsonUtility.ToJson(allData, true);
        File.WriteAllText(Application.persistentDataPath + "/Win_NotePositions.json", jsonData);

        Debug.Log("위치 데이터가 JSON 파일로 저장되었습니다.");
    }*/



    /*public void Load_AllPositions()
    {
        string filePath = Application.persistentDataPath + "/Win_NotePositions.json";

        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            AllInitialPositionsData allData = JsonUtility.FromJson<AllInitialPositionsData>(jsonData);

            int dataIndex = 0;

            // 일반 노트 위치 불러오기
            var NoteArrays = new List<Note_1105[]>()
        {
            Win_0_Note,
            // Win_1_Note,
            // Win_2_Note,
            // Win_3_Note,
            // Win_4_Note
        };

            foreach (var array in NoteArrays)
            {
                foreach (var note in array)
                {
                    if (note.rect != null && dataIndex < allData.InitialPositions.Count)
                    {
                        float posX = allData.InitialPositions[dataIndex].PositionX;
                        float posY = allData.InitialPositions[dataIndex].PositionY;
                        float posZ = allData.InitialPositions[dataIndex].PositionZ;
                        note.rect.anchoredPosition = new Vector3(posX, posY, posZ);

                        Debug.Log($"원래 일반 노트 위치n - X: {posX}, Y: {posY}, Z: {posZ}");

                        dataIndex++;
                    }
                }
            }

            // 롱 노트 위치 불러오기
            var Long_NoteArrays = new List<Long_Note[]>()
        {
            Win_0_Long,
            // Win_1_Long,
            // Win_2_Long,
            // Win_3_Long,
            // Win_4_Long
        };

            foreach (var array2 in Long_NoteArrays)
            {
                foreach (var longNote in array2)
                {
                    if (longNote.rect != null && dataIndex < allData.InitialPositions.Count)
                    {
                        float posX = allData.InitialPositions[dataIndex].PositionX;
                        float posY = allData.InitialPositions[dataIndex].PositionY;
                        float posZ = allData.InitialPositions[dataIndex].PositionZ;
                        longNote.rect.anchoredPosition = new Vector3(posX, posY, posZ);

                        Debug.Log($"원래 롱노트 위치 - X: {posX}, Y: {posY}, Z: {posZ}");

                        dataIndex++;
                    }
                }
            }

            var Long_Col_NoteArrays = new List<Long_Col[]>
{
    Win_0_Long_Fin
};

            //int dataIndex = 0; // Initial position data index

            foreach (var array3 in Long_Col_NoteArrays)
            {
                foreach (var longNote_Fin in array3)
                {
                    if (longNote_Fin.rect != null && dataIndex < allData.InitialPositions.Count)
                    {
                        float posX = allData.InitialPositions[dataIndex].PositionX;
                        float posY = allData.InitialPositions[dataIndex].PositionY;
                        float posZ = allData.InitialPositions[dataIndex].PositionZ;
                        longNote_Fin.rect.anchoredPosition = new Vector3(posX, posY, posZ);

                        Debug.Log($"원래 롱노트 끝부분 위치 - X: {posX}, Y: {posY}, Z {posZ}");

                        dataIndex++;
                    }
                }
            }
       

        }

        else
        {
            Debug.LogError("Position data file not found.");
        }
    }*/

}


/*[System.Serializable]
public class NotePositionData
{
    public float PositionX; // x 좌표
    public float PositionY; // y 좌표
}

[System.Serializable]
public class AllNotesData
{
    public List<NotePositionData> NotesPositions = new List<NotePositionData>(); // 모든 Note의 위치를 저장
}

public class Win_Note_Pos : MonoBehaviour
{
    public static Win_Note_Pos instance;
    //public Note_1105[] Win_0_Note; // 위치를 저장할 Note 배열

    public void Start()
    {
        instance = this;

       
    }

    public void Save_LongNote_Fin_Pos()
    {
        //롱 노트 끝부분
        AllNotesData allData2 = new AllNotesData();

        for (int i = 0; i < Winter_Music.instance.Win_0_Long_Fin.Length; i++)
        {
            // 각 Note의 현재 위치 데이터를 저장
            foreach (var note2 in Winter_Music.instance.Win_0_Long_Fin)
            {
                NotePositionData data2 = new NotePositionData
                {
                    PositionX = note2.rect[i].anchoredPosition.x,
                    PositionY = note2.rect[i].anchoredPosition.y
                };
                allData2.NotesPositions.Add(data2);
            }
        }

        // JSON 문자열로 변환 후 파일로 저장 (루프 밖에서 실행)
        string jsonData2 = JsonUtility.ToJson(allData2);
        File.WriteAllText(Application.persistentDataPath + "/Win_0_FinNote_Pos.json", jsonData2);
    }

    public void Save_LongNote_Pos()
    {
        //롱 노트
        AllNotesData allData1 = new AllNotesData();

        // 각 Note의 현재 위치 데이터를 저장
        foreach (var note1 in Winter_Music.instance.Win_0_Long)
        {
            NotePositionData data1 = new NotePositionData
            {
                PositionX = note1.rect.anchoredPosition.x,
                PositionY = note1.rect.anchoredPosition.y
            };
            allData1.NotesPositions.Add(data1);
        }

        // JSON 문자열로 변환 후 저장
        string jsonData1 = JsonUtility.ToJson(allData1);
        File.WriteAllText(Application.persistentDataPath + "/Win_0_LongNote_Pos.json", jsonData1);
    }

    public void Save_Note_Pos()
    {
        AllNotesData allData = new AllNotesData();

        // 각 Note의 현재 위치 데이터를 저장
        foreach (var note in Winter_Music.instance.Win_0_Note)
        {
            NotePositionData data = new NotePositionData
            {
                PositionX = note.rect.anchoredPosition.x,
                PositionY = note.rect.anchoredPosition.y
            };
            allData.NotesPositions.Add(data);
        }

        // JSON 문자열로 변환 후 저장
        string jsonData = JsonUtility.ToJson(allData);
        File.WriteAllText(Application.persistentDataPath + "/Win_0_Note_Pos.json", jsonData);


    }

    public bool Load_Note_Pos()
    {
        string path = Application.persistentDataPath + "/Win_0_Note_Pos.json";
        //string path1 = Application.persistentDataPath + "/Win_0_LongNote_Pos.json";
        //string path2 = Application.persistentDataPath + "/Win_0_FinNote_Pos.json";

        // 파일이 존재하는지 확인
        if (File.Exists(path)) //|| File.Exists(path1) || File.Exists(path2))
        {
            // 파일이 존재하면 JSON 문자열을 읽어와서 적용
            string json = File.ReadAllText(path);
            AllNotesData allData = JsonUtility.FromJson<AllNotesData>(json);

            // 데이터 개수와 배열 크기 확인 후 위치 적용
            if (allData.NotesPositions.Count == Winter_Music.instance.Win_0_Note.Length)
            {
                for (int i = 0; i < Winter_Music.instance.Win_0_Note.Length; i++)
                {
                    Vector2 loadedPosition = new Vector2(
                        allData.NotesPositions[i].PositionX,
                        allData.NotesPositions[i].PositionY
                    );
                    Winter_Music.instance.Win_0_Note[i].rect.anchoredPosition = loadedPosition;
                    Debug.Log($"일반 Note {i} 위치: X = {loadedPosition.x}, Y = {loadedPosition.y}");
                }
                return true;
            }
            else
            {
                Debug.LogWarning("노트 없소.");
            }

            
        }

        return false;
        //롱 노트
        /* if (File.Exists(path1))
         {
             // 파일이 존재하면 JSON 문자열을 읽어와서 적용
             string json1 = File.ReadAllText(path1);
             AllNotesData allData1 = JsonUtility.FromJson<AllNotesData>(json1);

             // 데이터 개수와 배열 크기 확인 후 위치 적용
             if (allData1.NotesPositions.Count == Winter_Music.instance.Win_0_Note.Length)
             {
                 for (int i = 0; i < Winter_Music.instance.Win_0_Long.Length; i++)
                 {
                     Vector2 loadedPosition1 = new Vector2(
                         allData1.NotesPositions[i].PositionX,
                         allData1.NotesPositions[i].PositionY
                     );
                     Winter_Music.instance.Win_0_Long[i].rect.anchoredPosition = loadedPosition1;
                     Debug.Log($"롱 Note {i} 위치: X = {loadedPosition1.x}, Y = {loadedPosition1.y}");
                 }
                 return true;
             }
             else
             {
                 Debug.LogWarning("롱 노트 없소.");
             }
         }

         //롱 노트 끝부분
         if (File.Exists(path2))
         {
             // 파일이 존재하면 JSON 문자열을 읽어와서 적용
             string json2 = File.ReadAllText(path2);
             AllNotesData allData2 = JsonUtility.FromJson<AllNotesData>(json2);

             // 데이터 개수와 배열 크기 확인 후 위치 적용
             if (allData2.NotesPositions.Count == Winter_Music.instance.Win_0_Long_Fin.Length)
             {
                 for (int i = 0; i < Winter_Music.instance.Win_0_Long_Fin.Length; i++)
                 {
                     Vector2 loadedPosition2 = new Vector2(
                         allData2.NotesPositions[i].PositionX,
                         allData2.NotesPositions[i].PositionY
                     );
                     Winter_Music.instance.Win_0_Long_Fin[i].rect[i].anchoredPosition = loadedPosition2;
                     Debug.Log($"롱 끝부분 Note {i} 위치: X = {loadedPosition2.x}, Y = {loadedPosition2.y}");
                 }
                 return true;
             }
             else
             {
                 Debug.LogWarning("롱 노트 끝부분 없소.");
             }
         }
        */
// 파일이 없거나 데이터가 일치하지 않을 경우 false 반환

//}

/*public void Load_LongNote_Pos()
{
    string path1 = Application.persistentDataPath + "/Win_0_LongNote_Pos.json";
    //string path2 = Application.persistentDataPath + "/Win_0_FinNote_Pos.json";

    // 파일이 존재하는지 확인
    if (File.Exists(path1)) //|| File.Exists(path1) || File.Exists(path2))
    {
        // 파일이 존재하면 JSON 문자열을 읽어와서 적용
        string json1 = File.ReadAllText(path1);
        AllNotesData allData1 = JsonUtility.FromJson<AllNotesData>(json1);

        // 데이터 개수와 배열 크기 확인 후 위치 적용
        if (allData.NotesPositions.Count == Winter_Music.instance.Win_0_Note.Length)
        {
            for (int i = 0; i < Winter_Music.instance.Win_0_Note.Length; i++)
            {
                Vector2 loadedPosition = new Vector2(
                    allData.NotesPositions[i].PositionX,
                    allData.NotesPositions[i].PositionY
                );
                Winter_Music.instance.Win_0_Note[i].rect.anchoredPosition = loadedPosition;
                Debug.Log($"일반 Note {i} 위치: X = {loadedPosition.x}, Y = {loadedPosition.y}");
            }
            return true;
        }
        else
        {
            Debug.LogWarning("노트 없소.");
        }


    }

    return false;
}*/

/*public void Reset_AllPositions()
{
    string path = Application.persistentDataPath + "/Win_0_Note_Positions.json";

    // 파일이 존재할 경우 삭제
    if (File.Exists(path))
    {
        File.Delete(path);
        Debug.Log("모든 Note 위치 데이터 삭제 완료");
    }

    // 모든 Note의 위치를 현재 위치로 초기화하여 다시 저장
    Save_AllPositions();
    Debug.Log("모든 Note 위치 현재 위치로 초기화 및 저장 완료");
}*/
//}
