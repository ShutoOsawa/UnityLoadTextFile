using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //string textPath = Path.Combine(Application.streamingAssetsPath, "test.txt");
        //List<string> pathList = TextLoad(textPath);
        //Debug.Log(pathList[0]);
        StartCoroutine(loadStreamingAsset("test.txt"));
        
    }
    
     public List<string> TextLoad(string textPath)
        {
        
            StreamReader inp_stm = new StreamReader(textPath);
            List<string> pathList = new List<string>();
    
            while(!inp_stm.EndOfStream)
            {
                string inp_ln = inp_stm.ReadLine( );
                pathList.Add(inp_ln);
            }
    
            inp_stm.Close( );
            return pathList;
        }
     public string result = "";
     

     IEnumerator loadStreamingAsset(string fileName)
     {
         string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, fileName);

         string result;
         if (filePath.Contains("://") || filePath.Contains(":///"))
         {
             WWW www = new WWW(filePath);
             yield return www;
             result = www.text;
         }
         else
             result = System.IO.File.ReadAllText(filePath);
         Debug.Log(result);
     }

     // Update is called once per frame
    void Update()
    {
        
    }
}
