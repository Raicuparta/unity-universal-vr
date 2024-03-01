﻿using UnityEngine;

namespace Uuvr;

// Since changing camera pitch and roll in VR is more nauseating,
// we can use this to allow only yaw rotations, which preserve the horizon line.
// TODO: add config toggle for this.
public class UuvrRotationNullifier: UuvrBehaviour
{
#if CPP
    protected UuvrRotationNullifier(System.IntPtr pointer) : base(pointer)
    {
    }
#endif
    
    public static UuvrRotationNullifier Create(Transform parent)
    {
        return new GameObject(nameof(UuvrPoseDriver))
        {
            transform =
            {
                parent = parent,
                localPosition = Vector3.zero,
                localRotation = Quaternion.identity
            }
        }.AddComponent<UuvrRotationNullifier>();
    }

    protected override void OnBeforeRender()
    {
        UpdateTransform();
    }

    private void Update()
    {
        UpdateTransform();
    }
    
    private void LateUpdate()
    {
        UpdateTransform();
    }

    private void UpdateTransform()
    {
        Vector3 forward = Vector3.ProjectOnPlane(transform.parent.forward, Vector3.up);
        transform.LookAt(transform.position + forward, Vector3.up);
    }
}