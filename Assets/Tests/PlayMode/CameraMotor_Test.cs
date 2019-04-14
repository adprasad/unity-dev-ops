using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class CameraMotor_Test {

    
    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator CameraMotor_CanBeInstatiatedAsNewMainCamera() {
        CameraMotor cameraMotor = new GameObject().AddComponent<CameraMotor>();
        yield return null;
        Assert.NotNull(cameraMotor);
        Assert.AreEqual(cameraMotor.Current, Camera.main);
    }

    [UnityTest]
    public IEnumerator CameraMotor_ChangesTransformRotationWhenProvidedVector()
    {
        CameraMotor cameraMotor = new GameObject().AddComponent<CameraMotor>();
        Vector3 expectedFocus = new Vector3(100, 100, 0);

        cameraMotor.Focus(expectedFocus);
        yield return new WaitForFixedUpdate();

        Assert.AreEqual(expectedFocus, cameraMotor.transform.localRotation.eulerAngles, "Should look at requested position");
    }
}
