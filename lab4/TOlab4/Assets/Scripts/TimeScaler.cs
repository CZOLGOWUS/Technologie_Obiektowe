using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaler : MonoBehaviour
{
    public void TimeScaleForwardQuarter()
    {
        Time.timeScale *= 1.25f;
    }

    public void TimeScaleBackQuarter()
    {
        Time.timeScale *= 0.75f;

    }

    public void normalizeTimeScale()
    {
        Time.timeScale *= 1f;
    }
}
