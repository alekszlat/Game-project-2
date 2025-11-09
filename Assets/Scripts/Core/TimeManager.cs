using System;
using UnityEngine;

/// <summary>
/// Manages the flow of in-game time and related time-based events.
/// </summary>
/// <remarks>
/// This component follows the <b>Singleton</b> pattern to ensure that only one instance 
/// of the <see cref="TimeManager"/> exists in the scene.
/// <para>
/// Responsible for tracking the passage of time, pausing, resuming, 
/// and triggering scheduled events (e.g., day/night cycles, timed tasks).
/// </para>
/// </remarks>
///
/// Author: H. Hristov (milkeles)
/// Created: 09/11/2025 (dd/mm/yyyy)
/// Updated: 09/11/2025 (dd/mm/yyyy)
/// Changelog:
namespace Game.Core.TimeSystem
{
    public class TimeManager : MonoBehaviour
    {
        private static TimeManager _instance;
        public static TimeManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<TimeManager>();
                    if (_instance == null)
                    {
                        var go = new GameObject("TimeManager");
                        _instance = go.AddComponent<TimeManager>();
                    }
                }
                return _instance;
            }
            private set => _instance = value;
        }

        [SerializeField] private float startingTime = 15f;

        private TimeManagerCore _core;

        public float RemainingTime => _core.RemainingTime;
        public bool IsPaused => _core.IsPaused;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);

            _core = new TimeManagerCore(startingTime);
        }

        private void Update()
        {
            _core.Tick(Time.deltaTime);
        }

        // Wrapper functions
        public void AddTime(float seconds) => _core.AddTime(seconds);
        public void SubtractTime(float seconds) => _core.SubtractTime(seconds);
        public void Pause() => _core.Pause();
        public void Resume() => _core.Resume();
        public void ResetTime() => _core.Reset(startingTime);
    }

    public class TimeManagerCore
    {
        public float RemainingTime { get; private set; }
        public bool IsPaused { get; private set; }

        public TimeManagerCore(float startTime)
        {
            RemainingTime = startTime;
        }

        public void Tick(float deltaTime)
        {
            if (IsPaused) return;

            RemainingTime -= deltaTime;
            if (RemainingTime < 0f)
                RemainingTime = 0f;
        }

        public void AddTime(float seconds)
        {
            RemainingTime += seconds;
        }

        public void SubtractTime(float seconds)
        {
            RemainingTime = Math.Max(0f, RemainingTime - seconds);
        }

        public void Reset(float startTime)
        {
            RemainingTime = startTime;
        }

        public void Pause() => IsPaused = true;
        public void Resume() => IsPaused = false;
    }
}
