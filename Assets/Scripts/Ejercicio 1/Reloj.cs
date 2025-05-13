using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class Reloj : MonoBehaviour
{

    const string APIURL = "http://worldtimeapi.org/api/ip";
    DateTime actualtime = DateTime.Now;
   
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TiempoReal());
    }

    public DateTime GetStartDateTime()
    {
        return actualtime;
    }
    public DateTime GetDateTimeNow() 
    {
        StartCoroutine (TiempoReal());
        return actualtime;
    }

    IEnumerator TiempoReal()
    {
        UnityWebRequest webrequest = UnityWebRequest.Get(APIURL);
        yield return webrequest.SendWebRequest();
    
        try
        {
            string timedata = webrequest.downloadHandler.text;
            actualtime = ParseDateTime(timedata);
        }
        catch (Exception)
        {
        }
    }

    DateTime ParseDateTime(string datetime)
    {
        string date = Regex.Match(datetime, @"^\d{4}-\d{2}-\d{2}-").Value;
        string time = Regex.Match(datetime, @"\d{2}:\d{2}\d{2}-").Value;
        return DateTime.Parse(string.Format( "{0} {1}", date, time));
    }

   
}
