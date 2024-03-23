﻿using System;
using HarmonyLib;
using UnityEngine;

namespace Uuvr;

[HarmonyPatch]
public static class Patches
{
    public static Vector3 hehe = Vector3.one * 0.5f;
    
    [HarmonyPrefix]
    [HarmonyPatch(typeof(Camera), "set_fieldOfView")]
    // Unity already prevents this, but it also nags you constantly about it.
    // Some games try to change the FOV every frame, and all those logs can reduce performance.
    private static bool PreventChangingFov()
    {
        return false;
    }
    
    // TODO: WorldToViewportPoint might give better results if we use the stereo versions when available.
    // [HarmonyPrefix]
    // [HarmonyPatch(typeof(Camera), nameof(Camera.WorldToViewportPoint), typeof(Vector3))]
    // private static bool FixWorldToViewportPoint(Vector3 position, ref Vector3 __result, Camera __instance)
    // {
    //     var _worldToViewportPointStereoMethod = typeof(Camera).GetMethod("WorldToViewportPoint", new Type[] { typeof(Vector3), typeof(Camera.MonoOrStereoscopicEye) });
    //     if (_worldToViewportPointStereoMethod == null)
    //     {
    //         Debug.LogError("#### FAILED TO FIND THE TYPE!!!");
    //     }
    //
    //     __result = (Vector3) _worldToViewportPointStereoMethod.Invoke(__instance, new object[] { position, Camera.MonoOrStereoscopicEye.Left });
    //     Debug.Log($"Is {__result}");
    //     return false;
    // }
}
