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
    CascadeClassifier cascade;
    private Renderer _renderer;



    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;

        _webCamTexture = new WebCamTexture(devices[0].name, resWidth, resHeight);
        _webCamTexture.Play();
        _renderer = GetComponent<Renderer>();
        cascade = new CascadeClassifier(Application.dataPath + @"/haarcascade_frontalface_default.xml");
    }

    // Update is called once per frame
    void Update()
    {
        _renderer.material.mainTexture = _webCamTexture;
        Mat frame = OpenCvSharp.Unity.TextureToMat(_webCamTexture);
        findNewFace(frame);
    }

    void findNewFace(Mat frame) {
        var faces = cascade.DetectMultiScale(frame, 1.1, 2, HaarDetectionType.ScaleImage);
        // print(frame);
        // if(faces.Length >= 1){
        //     Debug.Log(faces[0].Location);
        // }
    }
}
