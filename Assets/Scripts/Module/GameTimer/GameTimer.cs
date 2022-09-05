using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameTimer
{
    public float _currentCount { private set; get; }
    public System.Action<int> OnChangeTime { get; set; }

    private int count;

    private System.Action onTimeEnd;
    public GameTimer(int count, System.Action timeEndEvent)
    {
        _currentCount = count;
        this.count = count;

        onTimeEnd = timeEndEvent;
    }

    public IEnumerator StartCount()
    {
        while (_currentCount > 0)
        {
            _currentCount -= Time.deltaTime;
            OnChangeTime?.Invoke((int)_currentCount);
            yield return null;
        }
        onTimeEnd?.Invoke();
    }

}
