using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;


public static class UIEngineHelper
{
    public static void WateAdmissionComplete(Action callback)
    {
        CoroutineManager.Create(_WateAdmissionCompleteTask(callback));
    }

    private static IEnumerator _WateAdmissionCompleteTask(Action callback)
    {
        while(AdmissionManager.busing)
        {
            yield return null;
        }
        callback();
    }
}