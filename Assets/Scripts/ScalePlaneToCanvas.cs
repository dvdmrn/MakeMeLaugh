using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalePlaneToCanvas : MonoBehaviour
{

    private Vector2 screenResolution;

    void Start()
    {
        screenResolution = new Vector2(Screen.width, Screen.height);
        MatchPlaneToScreenSize();
    }

    void Update(){
        //Check if screen size changes
        if (screenResolution.x != Screen.width || screenResolution.y != Screen.height)
        {
            MatchPlaneToScreenSize();
            screenResolution.x = Screen.width;
            screenResolution.y = Screen.height;
        }
    }

    //Scale a plane to match 
    private void MatchPlaneToScreenSize()
    {
        float planeToCameraDistance = Vector3.Distance(gameObject.transform.position, Camera.main.transform.position);
        float planeHeightScale = (2.0f * Mathf.Tan(0.5f * Camera.main.fieldOfView * Mathf.Deg2Rad) * planeToCameraDistance) / 10.0f;
        float planeWidthScale = planeHeightScale * Camera.main.aspect;
        float unitsTall = Camera.main.orthographicSize * 2f * (1f - 2*30f / Screen.height * Screen.dpi / 72f); //72=points/pixel
        float unitsWide = Camera.main.orthographicSize * 2f * (1f - 2*30f / Screen.width * Screen.dpi / 72f); //72=points/pixel
        // Set the scale of the plane
        transform.localScale = new Vector3(unitsWide, 1, unitsTall);
        // Set the position of the plane to be centered on the camera
        transform.position = Camera.main.transform.position + Camera.main.transform.forward * planeToCameraDistance;
    }

}