using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [Range(0,1)]
    [SerializeField]
    private float _slowedTimeScale;

    [Range(0, 1)]
    [SerializeField]
    private float _normalTimeScale;

    public void SlowTime()
    {
        Time.timeScale = _slowedTimeScale;
    }

    public void NormalizeTime()
    {
        Time.timeScale = _normalTimeScale;
    }
}
