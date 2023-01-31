using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using TMPro;
using System;
using System.Text;

public class test_con : MonoBehaviour
{
    StringBuilder sb = new StringBuilder();
    Process proc = null;
    public TMP_Text txt;
    // Start is called before the first frame update
    void Start()
    {
        ProcessStartInfo psi = new ProcessStartInfo();
        psi.FileName = Environment.CurrentDirectory + "/Assets/test_con/test_con.exe";
        psi.UseShellExecute= false;
        psi.CreateNoWindow= true;
        psi.RedirectStandardOutput = true;
        proc = Process.Start(psi);
        proc.OutputDataReceived += Proc_OutputDataReceived;
        proc.Start();
        proc.BeginOutputReadLine();
        //proc.WaitForExit();
        
    }

    private void Proc_OutputDataReceived(object sender, DataReceivedEventArgs e)
    {
        Process p = sender as Process;
        printmsg(e.Data);
        //p.BeginOutputReadLine();
    }

    bool isRefresh = false;
    void printmsg(string msg)
    {
        isRefresh = true;
        sb.AppendLine(msg);
        UnityEngine.Debug.Log(msg);
    }
    private void OnDestroy()
    {
        if( proc?.HasExited == false)
        {
            proc?.Kill();
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (isRefresh == true)
        {
            txt.text = sb.ToString();
            isRefresh = false;
        }
            
    }
}
