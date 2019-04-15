
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.CodeDom;

public class CameraInScene_Test {

    const string EXPECTED_TAG = "MainCamera";

    [Test]
    public void Camera_OnlyOneActiveInScene() {
        // Use the Assert class to test conditions.
        Camera[] camerasInScene = GameObject.FindObjectsOfType<Camera>();
        Assert.IsNotEmpty(camerasInScene);
        int activeCameraCount = 0;
        foreach(Camera go in camerasInScene)
        {
            if (go.isActiveAndEnabled)
            {
                activeCameraCount++;
            }
        }
        Assert.AreEqual(1, activeCameraCount, "More than one active camera in scene");
    }    

    [Test]
    public void Camera_ActiveHasCameraMotor()
    {
        // Use the Assert class to test conditions.
        Camera[] camerasInScene = GameObject.FindObjectsOfType<Camera>();
        Assert.IsNotEmpty(camerasInScene);
        Camera active = null;
        foreach (Camera go in camerasInScene)
        {
            if (go.isActiveAndEnabled)
            {
                active = go;
                break;
            }
        }
        Assert.NotNull(active.GetComponent<CameraMotor>(), "Camera needs a motor");
    }
    [Test]
    public void Camera_ActiveHasCameraController()
    {
        // Use the Assert class to test conditions.
        Camera[] camerasInScene = GameObject.FindObjectsOfType<Camera>();
        Assert.IsNotEmpty(camerasInScene);
        Camera active = null;
        foreach (Camera go in camerasInScene)
        {
            if (go.isActiveAndEnabled)
            {
                active = go;
                break;
            }
        }
        Assert.NotNull(active.GetComponent<CameraController>(), "Camera needs a controller");
    }

    [Test]
    public void Camera_ActiveCameraMotorReferencesCurrentCamera()
    {
        // Use the Assert class to test conditions.
        Camera[] camerasInScene = GameObject.FindObjectsOfType<Camera>();
        Assert.IsNotEmpty(camerasInScene);
        Camera active = null;
        foreach (Camera go in camerasInScene)
        {
            if (go.isActiveAndEnabled)
            {
                active = go;
                break;
            }
        }
        CameraMotor cm = active.GetComponent<CameraMotor>();
        Assert.AreSame(active, cm.Current);
        Assert.True(cm.Current.CompareTag(EXPECTED_TAG));
    }
    
}
