using UnityEngine;
using TMPro;
using System;

public class TimerCanvas : MonoBehaviour
{
    // This script is based off of the medium page.
    // https://medium.com/@eveciana21/creating-a-stopwatch-timer-in-unity-f4dff748030d
    private bool _timerActive;
    private float _currentTime;
    [SerializeField] private int _startMinutes;
    [SerializeField] private TMP_Text _text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentTime = _startMinutes * 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (_timerActive)
        {
            _currentTime = _currentTime - Time.deltaTime;
            if (_currentTime <= 0)
            {
                _timerActive = false;
            }
        }
        // _text.text = _currentTime.ToString();
        TimeSpan time = TimeSpan.FromSeconds(_currentTime);
        _text.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }

    public void StartTimer()
    {
        _timerActive = true;
    }
    public void StopTimer()
    {
        _timerActive = false;
    }
}
