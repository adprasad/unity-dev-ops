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
        Quaternion expectedFocus = Quaternion.Euler(new Vector3(30,30,0));
        float acceptableDifference = 0.02f;
        cameraMotor.Focus(expectedFocus);

        yield return new WaitForFixedUpdate();

        Assert.AreEqual(expectedFocus.w, cameraMotor.transform.rotation.w, acceptableDifference, "Should look at requested position w");
        Assert.AreEqual(expectedFocus.x, cameraMotor.transform.rotation.x, acceptableDifference, "Should look at requested position x");
        Assert.AreEqual(expectedFocus.y, cameraMotor.transform.rotation.y, acceptableDifference, "Should look at requested position y");
        Assert.AreEqual(expectedFocus.z, cameraMotor.transform.rotation.z, acceptableDifference, "Should look at requested position z");
    }
}
