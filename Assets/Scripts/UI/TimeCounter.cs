using TMPro;
using UnityEngine;

namespace UI
{
    public class TimeCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text timeText;
        
        private int _secondsInMinute = 60;
        private int _minutesInHour = 60;
        private int _hoursInDay = 24;
        private int _totalDays;
        private int _totalSeconds;
        private int _totalHours;
        private int _totalMinutes;
        private float _totalTime;
        
        private void Update()
        {
            _totalTime += Time.deltaTime;

            if (_totalTime > 1)
            {
                _totalTime--;
                _totalSeconds++;
            }

            if (_totalSeconds >= _secondsInMinute)
            {
                _totalSeconds -= _secondsInMinute;
                _totalMinutes++;
            }

            if (_totalMinutes >= _minutesInHour)
            {
                _totalMinutes -= _minutesInHour;
                _totalHours++;
            }

            if (_totalHours >= _hoursInDay)
            {
                _totalHours -= _hoursInDay;
                _totalHours++;
            }

            timeText.text = $"{_totalDays}d {_totalHours}h {_totalMinutes}m {_totalSeconds}s";
        }
    }
}