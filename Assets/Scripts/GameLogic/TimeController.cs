using UnityEngine;

using Chronos;

public class TimeController : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField]
    private float _slowedTimeScale;

    [Range(0, 1)]
    [SerializeField]
    private float _normalTimeScale;

    [Range(1, 10)]
    [SerializeField]
    private float _hastenTimeScale;

    [SerializeField]
    private string _clockToControlName = "GameTime";

    private Clock _gameTimeClock;

    private void Awake()
    {
        _gameTimeClock = Timekeeper.instance.Clock(_clockToControlName);
    }

    public void SlowTime()
    {
        _gameTimeClock.localTimeScale = _slowedTimeScale;
    }

    public void NormalizeTime()
    {
        _gameTimeClock.localTimeScale = _normalTimeScale;
    }

    public void HastenTime()
    {
        _gameTimeClock.localTimeScale = _hastenTimeScale;
    }

    public void Pause()
    {
        _gameTimeClock.paused = true;
    }

    public void Unpause()
    {
        _gameTimeClock.paused = false;
    }
}
