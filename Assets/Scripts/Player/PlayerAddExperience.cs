using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAddExperience : LevelScaling
{
    public static event Action<float> UpdateExperienceUI;
    public static event Action IncreasePlayerLevel;

    private void Update()
    {
        _playerStats = GetComponent<PlayerStats>();
        _playerStats.ExperienceRequired = CalculateRequiredExp();
    }

    private void OnEnable()
    {
        ExperienceOrb.ExperienceCollected += AddExperience;
    }
    private void AddExperience(float experience)
    {
        UpdateExperienceUI?.Invoke(experience);
        Debug.Log($"XP: {_playerStats.Experience} / {_playerStats.ExperienceRequired}");
        if (_playerStats.Experience >= _playerStats.ExperienceRequired)
        {
            _playerStats.Experience = 0;
            IncreasePlayerLevel?.Invoke();
        }
    }
}
