using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeScreenCapture : MonoBehaviour
{
    public void SimplePrintScreen()
    {
        // TODO : tester android ! 

        string fileName = "screen" + ScreenCaptureTool.GetDateToString() + ".png";
        
#if UNITY_IOS || UNITY_ANDROID
        Application.CaptureScreenshot(fileName);
#else
        StartCoroutine(ScreenCaptureTool.CaptureToFile(fileName, ""));
#endif
    }

    public void MyPrintToPDF()
    {
        string fileName = "screen" + ScreenCaptureTool.GetDateToString() + ".pdf";
        
        StartCoroutine(ScreenCaptureTool.CaptureToPdf(fileName, ""));
    }

    public void PrintToPDF()
    {
        StartCoroutine(GetScreenshot());
    }

    IEnumerator GetScreenshot()
    {
        Cursor.visible = false;
        yield return new WaitForEndOfFrame();
        
        List<byte[]> imageByte = new List<byte[]>();

        Texture2D screenImage = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenImage.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenImage.Apply();
        byte[] tmpImageBytes = screenImage.EncodeToJPG();
        imageByte.Add(tmpImageBytes);
        
        yield return new WaitForEndOfFrame();
        
        StartCoroutine(ScreenCaptureToolBis.CaptureToFile(imageByte, "Historique_de_partie.pdf"));
        
        Cursor.visible = true;
    }
}
