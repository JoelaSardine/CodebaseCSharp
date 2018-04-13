#define HAS_SHARP_PDF_PLUGIN

using System.Collections;
using UnityEngine;
#if HAS_SHARP_PDF_PLUGIN
using sharpPDF;
#endif

namespace Sardine.Tools.Image
{
    public static partial class ScreenCaptureTool
    {
        /// <summary>Capture screenshot and save it to a file. 'path' is ignored in WebGL.</summary>
        public static IEnumerator CaptureToFile(string fileName = "", string path = "")
        {
            yield return new WaitForEndOfFrame();

            Texture2D screenImage = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

            // Get Image from screen
            screenImage.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
            screenImage.Apply();

            // Convert to png
            byte[] imageBytes = screenImage.EncodeToPNG();

            // Build file name
            if (string.IsNullOrEmpty(fileName)) fileName = "screenshot_" + GetDateToString() + ".png";
            else if (!fileName.Contains(".png")) fileName = fileName + ".png";

#if UNITY_WEBGL && !UNITY_EDITOR
		    //Send data to javascript for download
		    WebGLCapture(imageBytes, fileName);
#else
            //Save image to file
            System.IO.File.WriteAllBytes(path + fileName, imageBytes);
            Debug.Log("File successfully saved to " + Application.dataPath + "/" + path + fileName);
#endif
        }

#if UNITY_WEBGL
        private static void WebGLCapture(byte[] imageBytes, string fileName)
        {
            string data = System.Convert.ToBase64String(imageBytes);

            System.Text.StringBuilder js = new System.Text.StringBuilder();
            js.Append("function saveAs(uri, filename) {");
            js.Append("  var link = document.createElement('a');");
            js.Append("	 if (typeof link.download === 'string') {");
            js.Append("	   link.href = uri;	link.download = filename;");
            js.Append("    document.body.appendChild(link);"); //Firefox requires the link to be in the body
            js.Append("    link.click();"); //simulate click
            js.Append("    document.body.removeChild(link);"); //remove the link when done
            js.Append("  } else { window.open(uri); }");
            js.Append("}");
            js.Append("var file = 'data:image/gif;base64," + data + "';");
            js.Append("window.alert(\"Hello\");");
            js.Append("saveAs(file, '" + fileName + "');");

            Application.ExternalEval(js.ToString());
        }
#endif

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

#if HAS_SHARP_PDF_PLUGIN

        const int PDF_MAX_WIDTH = 1024;
        const int PDF_MAX_HEIGHT = 768;

        /// <summary>Capture screenshot and save it to a file. 'path' is ignored in WebGL.</summary>
        public static IEnumerator CaptureToPdf(string fileName = "", string path = "")
        {
            yield return new WaitForEndOfFrame();

            Texture2D screenImage = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
            int width = Screen.width;
            int height = Screen.height;

            // Get Image from screen
            screenImage.ReadPixels(new Rect(0, 0, width, height), 0, 0);
            screenImage.Apply();

            if (width > PDF_MAX_WIDTH || height > PDF_MAX_HEIGHT)
            {
                float ratio = width / (float)height;
                if (width > PDF_MAX_WIDTH)
                {
                    width = PDF_MAX_WIDTH;
                    height = Mathf.FloorToInt(width / ratio);
                }
                if (height > PDF_MAX_HEIGHT)
                {
                    height = PDF_MAX_HEIGHT;
                    width = Mathf.FloorToInt(height * ratio);
                }
                TextureScaler.scale(screenImage, width, height);
            }


            // Convert to JPG (don't work if png)
            byte[] imageBytes = screenImage.EncodeToJPG();

            // Build file name
            if (string.IsNullOrEmpty(fileName)) fileName = "screenshot_" + GetDateToString() + ".pdf";
            else if (!fileName.Contains(".pdf")) fileName = fileName + ".pdf";

            yield return new WaitForEndOfFrame();

            // And now, convert into a pdf

            pdfDocument myDoc = new pdfDocument("Historique des parties", "KTM Advance", false);
            pdfPage myPage = myDoc.addPage();
            myPage.addImage(imageBytes, 0, 0, height, width);

            string data = myDoc.createPDFToString();
            byte[] pdfBytes = System.Convert.FromBase64String(data);

#if UNITY_WEBGL && !UNITY_EDITOR
        		WebGLCapture(pdfBytes, fileName);
#else
            System.IO.File.WriteAllBytes(fileName, pdfBytes);
            Debug.Log("File successfully saved to " + Application.dataPath + "/" + path + fileName);
#endif
        }
#else
        /// <summary>Must have sharpPDF plugin and enabled the HAS_SHARP_PDF_PLUGIN define.</summary>
        public static IEnumerator CaptureToPdf(string fileName = "", string path = "")
        {
            throw new System.MissingMemberException("Must have sharpPDF plugin and enabled the HAS_SHARP_PDF_PLUGIN define.");
        }
#endif
    }
}