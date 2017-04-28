using UnityEngine;
using System.Collections;
using Vuforia;
using System;
using System.Threading;
using ZXing;
using ZXing.QrCode;
using ZXing.Common;

public class QRCodeRecognition : MonoBehaviour
{
    private bool mAccessCameraImage = true;
    private bool wait;
    private float timeElapsed;
    // The desired camera image pixel format
    private Image.PIXEL_FORMAT mPixelFormat = Image.PIXEL_FORMAT.GRAYSCALE;// or RGBA8888, RGB888, RGB565, YUV
    // Boolean flag telling whether the pixel format has been registered
    private bool mFormatRegistered = false;
    private BarcodeReader barCodeReader;
   
    void Start()
    {
        barCodeReader = new BarcodeReader();
        // Register Vuforia life-cycle callbacks:
        VuforiaARController vuforia = VuforiaARController.Instance;
        vuforia.RegisterVuforiaStartedCallback(OnVuforiaStarted);
        vuforia.RegisterOnPauseCallback(OnPause);
        vuforia.RegisterTrackablesUpdatedCallback(OnTrackablesUpdated);
    }
    /// <summary>
    /// Called when Vuforia is started
    /// </summary>
    private void OnVuforiaStarted()
    {
        // Try register camera image format
        if (CameraDevice.Instance.SetFrameFormat(mPixelFormat, true))
        {
            Debug.Log("Successfully registered pixel format " + mPixelFormat.ToString());
            mFormatRegistered = true;
        }
        else
        {
            Debug.LogError("Failed to register pixel format " + mPixelFormat.ToString() +
            "\n the format may be unsupported by your device;" +
            "\n consider using a different pixel format.");
            mFormatRegistered = false;
        }
    }
    /// <summary>
    /// Called when app is paused / resumed
    /// </summary>
    private void OnPause(bool paused)
    {
        if (paused)
        {
            Debug.Log("App was paused");
            UnregisterFormat();
        }
        else
        {
            Debug.Log("App was resumed");
            RegisterFormat();
        }
    }
    /// <summary>
    /// Called each time the Vuforia state is updated
    /// </summary>
    private void OnTrackablesUpdated()
    {
    }
    private void Update()
    {
        if (mFormatRegistered)
        {
            if (mAccessCameraImage)
            {
                Vuforia.Image image = CameraDevice.Instance.GetCameraImage(mPixelFormat);
                if (image != null)
                {
                    string imageInfo = mPixelFormat + " image: \n";
                    imageInfo += " size: " + image.Width + " x " + image.Height + "\n";
                    imageInfo += " bufferSize: " + image.BufferWidth + " x " + image.BufferHeight + "\n";
                    imageInfo += " stride: " + image.Stride;
                    var data = barCodeReader.Decode(image.Pixels, image.BufferWidth, image.BufferHeight, RGBLuminanceSource.BitmapFormat.RGB24);
                    if (data != null)
                    {
                        // QRCode detected.
                        //Debug.Log(data.Text);
                        //Application.OpenURL(data.Text);      // our function to call and pass url as text
                            GameObject.Find("shooter").GetComponent<SpriteRenderer>().enabled = false;
                        data = null;        // clear data
                    }
                    else
                    {
                        //GameObject.Find("shooter").GetComponent<SpriteRenderer>().enabled = true;
                        //Debug.Log("No QR code detected !");
                    }

                    //Debug.Log(imageInfo);
                    byte[] pixels = image.Pixels;
                    if (pixels != null && pixels.Length > 0)
                    {
                        //Debug.Log("Image pixels: " + pixels[0] + "," + pixels[1] + "," + pixels[2] + ",...");
                    }
                }
            }
        }
    }
    /// <summary>
    /// Unregister the camera pixel format (e.g. call this when app is paused)
    /// </summary>
    private void UnregisterFormat()
    {
        Debug.Log("Unregistering camera pixel format " + mPixelFormat.ToString());
        CameraDevice.Instance.SetFrameFormat(mPixelFormat, false);
        mFormatRegistered = false;
    }
    /// <summary>
    /// Register the camera pixel format
    /// </summary>
    private void RegisterFormat()
    {
        if (CameraDevice.Instance.SetFrameFormat(mPixelFormat, true))
        {
            Debug.Log("Successfully registered camera pixel format " + mPixelFormat.ToString());
            mFormatRegistered = true;
        }
        else
        {
            Debug.LogError("Failed to register camera pixel format " + mPixelFormat.ToString());
            mFormatRegistered = false;
        }
    }
}



//using UnityEngine;
//using System;
//using System.Collections;
//using Vuforia;
//using System.Threading;
//using ZXing;
//using ZXing.QrCode;
//using ZXing.Common;

///*        /////////////////    QR detection does not work in editor    ////////////////    */

//[AddComponentMenu("System/QRScanner")]
//public class QRCodeRecognition : MonoBehaviour
//{
//    private bool cameraInitialized;
//            VuforiaBehaviour.Instance.
//    }

//    private IEnumerator InitializeCamera()
//    {
//        // Waiting a little seem to avoid the Vuforia's crashes.
//        yield return new WaitForSeconds(3f);

//        bool isFrameFormatSet = CameraDevice.Instance.SetFrameFormat(Image.PIXEL_FORMAT.RGB888, true);
//        Debug.Log(String.Format("FormatSet : {0}", isFrameFormatSet));

//        // Force autofocus.
//        //        var isAutoFocus = CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
//        //        if (!isAutoFocus)
//        //        {
//        //            CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_NORMAL);
//        //        }
//        //        Debug.Log(String.Format("AutoFocus : {0}", isAutoFocus));
//        cameraInitialized = true;
//    }

//    private void Update()
//    {
//            catch (Exception e)
//            {
//                Debug.LogError(e.Message);
//            }
//        }
//}
