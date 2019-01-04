using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 파일 입출력-안드로이드 버전 테스트, Android/data/com.PotatopieProject/DURUMI_2019에 저장됨
/// </summary>

public class Test_FileIO : MonoBehaviour
{

#pragma warning disable CS0618  //WWW가 옛날꺼라 경고뜨는거 막기, 어차피 안드로이드는 이렇게해야한다


    void ExampleIO(string filePath, out string result)
    {
        
        if (File.Exists(filePath))
        {
            WWW fileWWW = new WWW(filePath);
            result = fileWWW.text;
        }
        else
        {
            result = File.ReadAllText(filePath);
        }
    }
    private void Start()
    {
        string path = Application.persistentDataPath + "/" + "TestFile.txt";
        string fileResult = "";
        ExampleIO(path, out fileResult);
        Debug.Log(path);
        Debug.Log(fileResult);
    }
}
