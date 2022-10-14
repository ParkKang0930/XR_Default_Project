using System.Collections.Generic;
using System.Net;
using System.IO;
using UnityEngine;

[System.Serializable]
public class Input_GetMbr
{
    public string mbrNo;
}


[System.Serializable]
public class Output_GetMbr
{
    public string result;
    public List<Output_GetMbr_List> mbrList = new List<Output_GetMbr_List>();
}

[System.Serializable]
public class Output_GetMbr_List
{
    public string mbrNo;
    public string mbrGbn;
    public string mbrAuth;
    public string mbrId;
    public string mbrPw;
    public string mbrXrPw;
    public string mbrNicknm;
    public string mbrProImgUrl;
    public string langCd;
    public string grapConfig;
    public string volAdjust;
    public string movSpeed;
    public string eyeLevel;
    public string joinDt;
    public string secsnDt;
    public string secsnResnCd;
    public string secsnResnDetailCont;
    public string emailRecptnAgrYn;
    public string emailRecptnAgrDt;
    public string smsRecptnAgrYn;
    public string smsRecptnAgrDt;
    public string dmRecptnAgrYn;
    public string dmRecptnAgrDt;
    public string tmRecptnAgrYn;
    public string tmRecptnAgrDt;
    public string regId;
    public string regDt;
    public string udtId;
    public string udtDt;
}

[System.Serializable]
public class Output_UpdateMbr
{
    public string result;
}

public class RQ_Sample : MonoBehaviour
{
    public Output_GetMbr OG_GetMbr(string mbrNo)
    {
        Input_GetMbr data = new Input_GetMbr();

        data.mbrNo = mbrNo;

        string str = JsonUtility.ToJson(data);
        var bytes = System.Text.Encoding.UTF8.GetBytes(str);

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:8080/getMbr.json");
        request.Method = "POST";
        request.ContentType = "application/json";
        request.Headers.Add("loginKey", "로그인 키 데이터 입력부분");
        request.ContentLength = bytes.Length;

        using (var stream = request.GetRequestStream())
        {
            stream.Write(bytes, 0, bytes.Length);
            stream.Flush();
            stream.Close();
        }

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string json = reader.ReadToEnd();
        Output_GetMbr info = JsonUtility.FromJson<Output_GetMbr>(json);
        
        //Output Data 적용 부분

        return info;
    }
   
}
