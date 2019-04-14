using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine;

public class CameraInScene_Test {

    [Test]
    public void TrackMouse_OnlyOneCameraActiveInScene() {
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
    

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator TrackMouse_TestWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }
}
