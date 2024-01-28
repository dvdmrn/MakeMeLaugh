using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCvSharp;


public class FaceDetector : MonoBehaviour
{
    // Start is called before the first frame update
    public int resWidth;
    public int resHeight;
    WebCamTexture _webCamTexture;
    CascadeClassifier faceCascade;
    CascadeClassifier smileCascade;
    OpenCvSharp.Rect detectedFace;
    private Renderer _renderer;

    public RectTransform canvasTransform;
    public Transform trackPoint;
    private Matrix4x4 normalizationMatrix;

    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;

        _webCamTexture = new WebCamTexture(devices[0].name, resWidth, resHeight);
        _webCamTexture.Play();
        _renderer = GetComponent<Renderer>();
        faceCascade = new CascadeClassifier(Application.dataPath + @"/haarcascade_frontalface_default.xml");
        smileCascade = new CascadeClassifier(Application.dataPath + @"/haarcascade_smile.xml");

        this.canvasTransform = gameObject.GetComponentInParent<RectTransform>();
        this.normalizationMatrix = Matrix4x4.Translate(new Vector3(resWidth/2, resHeight/2, 0)) * Matrix4x4.Scale(new Vector3(-1f/resWidth, -1f/resHeight, 1));
    }

    // Update is called once per frame
    void Update()
    {
        _renderer.material.mainTexture = _webCamTexture;
        Mat frame = OpenCvSharp.Unity.TextureToMat(_webCamTexture);
        findNewFace(frame);
        display(frame);

        if (detectedFace != null) {
            var rescaleMatrix = Matrix4x4.Scale(new Vector3(canvasTransform.rect.width, canvasTransform.rect.height, 1));
            var center = detectedFace.Center;
            trackPoint.localPosition = new Vector3((center.X - resWidth/2.5f) * -(canvasTransform.rect.width / resWidth), (center.Y - resHeight/2.2f) * -(canvasTransform.rect.height / resHeight));        }
    }


    void findNewFace(Mat frame)
    {
        var faces = faceCascade.DetectMultiScale(frame, 1.7, 2, HaarDetectionType.ScaleImage);
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

