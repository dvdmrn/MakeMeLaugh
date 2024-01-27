using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCvSharp;

public class FaceDetector : MonoBehaviour
{
    // Start is called before the first frame update
    WebCamTexture _webCamTexture;
    CascadeClassifier faceCascade;
    CascadeClassifier smileCascade;
    OpenCvSharp.Rect detectedFace;

    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;

        _webCamTexture = new WebCamTexture(devices[0].name);
        _webCamTexture.Play();

        faceCascade = new CascadeClassifier(Application.dataPath + @"/haarcascade_frontalface_default.xml");
        smileCascade = new CascadeClassifier(Application.dataPath + @"/haarcascade_smile.xml");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().material.mainTexture = _webCamTexture;
        Mat frame = OpenCvSharp.Unity.TextureToMat(_webCamTexture);
        findNewFace(frame);
        display(frame);
    }

    void findNewFace(Mat frame)
    {
        var faces = faceCascade.DetectMultiScale(frame, 1.1, 2, HaarDetectionType.ScaleImage);
        if (faces.Length >= 1)
        {
            detectedFace = faces[0];
            Debug.Log(detectedFace.Location);

            // Extract the region of interest (ROI) for smile detection
            Mat faceROI = frame[detectedFace];

            // Convert the face ROI to grayscale for smile detection
            Mat faceGray = new Mat();
            Cv2.CvtColor(faceROI, faceGray, ColorConversionCodes.BGR2GRAY);

            // Detect smiles in the face ROI
            var smiles = smileCascade.DetectMultiScale(faceGray, 1.7, 20);
            if (detectedFace != null) {
                frame.Rectangle(detectedFace, new Scalar(250,0,0),2);
            }
            // If smiles are detected, log and mark the face as smiling
            if (smiles.Length > 0)
            {
                Debug.Log("Smile detected!");
                Cv2.PutText(frame, "Smiling", new Point(detectedFace.X, detectedFace.Y + detectedFace.Height + 40),
                    HersheyFonts.HersheySimplex, 3, new Scalar(255, 255, 255), 2);
            }
        }
    }

    void display(Mat frame)
    {
        Texture newTexture = OpenCvSharp.Unity.MatToTexture(frame);
        GetComponent<Renderer>().material.mainTexture = newTexture;
    }
}
