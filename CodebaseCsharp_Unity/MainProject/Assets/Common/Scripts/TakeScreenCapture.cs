using UnityEngine;

namespace Sardine.Tools.Image
{
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
    }
}