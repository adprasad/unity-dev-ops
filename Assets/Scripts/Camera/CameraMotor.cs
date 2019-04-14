using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraMotor : MonoBehaviour, ICameraMotor
{
    [SerializeField]
    Camera current;

    public Camera Current
    {
        get {
            if (current == null)
            {
                current = gameObject.GetComponent<Camera>();
                current.tag = "MainCamera";
                if ( current != Camera.main)
                {
                    Camera.main.tag = "Untagged";                    
                }
            }
            return current;
        }
    }

    public void Focus(Vector3 focus)
    {
        throw new System.NotImplementedException();
    }
}
