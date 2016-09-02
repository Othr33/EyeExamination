using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

    // Use this for initialization
    public SteamVR_TrackedObject rightController;
    public Camera scopeCamera;
    public Light spotLight;

    public int iter = 10;
    public const float minInt = 0.0f;
    public const float maxInt = 3.0f;
    public const float minFOV = 1.0f;
    public const float maxFOV = 10.0f;

	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
        var device = SteamVR_Controller.Input((int)rightController.index);

        if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            float touchY = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).y;
            float fov = scopeCamera.fieldOfView - touchY*0.05f;
            float touchX = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).x;
            float intensity = spotLight.intensity + touchX*0.05f;

            if (fov < minFOV)
                scopeCamera.fieldOfView = minFOV;
            else if (fov > maxFOV)
                scopeCamera.fieldOfView = maxFOV;
            else
                scopeCamera.fieldOfView = fov;

            if (intensity < minInt)
                spotLight.intensity = minInt;
            else if (intensity > maxInt)
                spotLight.intensity = maxInt;
            else
                spotLight.intensity = intensity;
           
        }
        if (device.GetPress(SteamVR_Controller.ButtonMask.Grip))
        {
            iter -= 1;
        }
        else
        {
            iter = 5;
        }
        
        
	}
}
