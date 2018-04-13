using sharpPDF;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCaptureToolBis
{
    public delegate void OnCaptureEvent();
    public static OnCaptureEvent OnCaptureToFileOver;

    /// <summary>Capture screenshot and save it to a file. 'path' is ignored in WebGL.</summary>
    public static IEnumerator CaptureToFile(List<byte[]> imageByte, string fileName = "")
    {
        yield return new WaitForEndOfFrame();
        string dataPath = null;
        if (string.IsNullOrEmpty(fileName)) fileName = "screenshot_" + GetDateToString() + ".pdf";
#if UNITY_EDITOR
        dataPath = "file://" + Application.dataPath + "/StreamingAssets/" + fileName;
#elif UNITY_WEBGL
            dataPath = "StreamingAssets/" + fileName;
#endif

        pdfDocument myDoc = new pdfDocument("Historique des parties", "KTM Advance", false);

        foreach (byte[] b in imageByte)
        {
            pdfPage myPage = myDoc.addPage();
            myPage.addImage(b, 0, 0, Screen.height, Screen.width);
        }

        string data = myDoc.createPDFToString();
        byte[] pdfBytes = Convert.FromBase64String(data);

#if UNITY_WEBGL && !UNITY_EDITOR
		//Send data to javascript for download
		WebGLCapture(pdfBytes, fileName);
#else
        //Save image to file
        System.IO.File.WriteAllBytes(fileName, pdfBytes);
        Debug.Log("File successfully saved to " + dataPath);
#endif
        if (OnCaptureToFileOver != null)
        {
            OnCaptureToFileOver();
        }
    }

    private static void WebGLCapture(byte[] pdfBytes, string fileName)
    {
        string data = Convert.ToBase64String(pdfBytes);

        System.Text.StringBuilder js = new System.Text.StringBuilder();

        js.Append("function saveAs(blob, fileName) {");
        js.Append("    var url = window.URL.createObjectURL(blob);");
        js.Append("    var anchorElem = document.createElement(\"a\");");
        js.Append("    anchorElem.style = \"display: none\";");
        js.Append("    anchorElem.href = url;");
        js.Append("    anchorElem.download = fileName;");
        js.Append("    document.body.appendChild(anchorElem);");
        js.Append("    anchorElem.click();");
        js.Append("    document.body.removeChild(anchorElem);}");

        js.Append("function b64toBlob(b64Data, contentType, sliceSize) {");
        js.Append("contentType = contentType || '';");
        js.Append("sliceSize = sliceSize || 512;");
        js.Append("var byteCharacters = atob(b64Data);");
        js.Append("var byteArrays = [];");
        js.Append("for (var offset = 0; offset < byteCharacters.length; offset += sliceSize){");
        js.Append("    var slice = byteCharacters.slice(offset, offset + sliceSize);");
        js.Append("        var byteNumbers = new Array(slice.length);");
        js.Append("    for (var i = 0; i < slice.length; i++) {");
        js.Append("        byteNumbers[i] = slice.charCodeAt(i);}");
        js.Append("    var byteArray = new Uint8Array(byteNumbers);");
        js.Append("    byteArrays.push(byteArray);}");
        js.Append("var blob = new Blob(byteArrays, { type: contentType});");
        js.Append("return blob;}");


        js.Append("var b64Data = '" + data + "';");
        js.Append("var contentType = 'application/octet-stream';");
        js.Append("var blob = b64toBlob(b64Data, contentType);");
        js.Append("var fileName = \"" + fileName + "\";");
        js.Append("saveAs(blob, fileName);");


        Application.ExternalEval(js.ToString());
    }

    /// <summary>Returns the date formatted to "YYYY-MM-DD_hh-mm".</summary>
    public static string GetDateToString()
    {
        System.DateTime date = System.DateTime.Now;
        return date.Year
            + "-" + stringifyInt(date.Month, 2)
            + "-" + stringifyInt(date.Day, 2)
            + "_" + stringifyInt(date.Hour, 2)
            + "-" + stringifyInt(date.Minute, 2);
    }

    /// <summary>Returns a string representing the value with the good number of characters, adding zeros.</summary>
    private static string stringifyInt(int value, int minChars = 1)
    {
        System.Text.StringBuilder builder = new System.Text.StringBuilder();

        int j = (int)Mathf.Pow(10, minChars - 1);
        for (int i = 1; i < minChars; i++)
        {
            if (value >= j) break;
            builder.Append("0");
            j /= 10;
        }

        return builder.Append(value).ToString();
    }
}