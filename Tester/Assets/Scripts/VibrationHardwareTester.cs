using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VibrationHardwareTester : MonoBehaviour
{
    public Text VibrationFeaturesText;
    public Button VibrationCustom;
    public Slider VibrationTimeSlider;

    private bool hasVibrator;
    private bool hasAmplitudeControl;
    private bool hasFrequencyControl;
    private float qFactor;
    private float resonantFrequency;

    private void Start()
    {
        VibrationCustom.onClick.AddListener(() =>
        {
            var value = (long)VibrationTimeSlider.value;
            long[] pattern = { 0, value };
            Vibration.Vibrate ( pattern, -1 );
            Debug.Log($"VibrationCustom : {value}");
        });
        
        hasVibrator = Vibration.HasVibrator();
        hasAmplitudeControl = Vibration.HasAmplitudeControl();
        hasFrequencyControl = Vibration.HasFrequencyControl();
        qFactor = Vibration.getQFactor();
        resonantFrequency = Vibration.getResonantFrequency();

        
    }

    private void Update()
    {
        hasVibrator = Vibration.HasVibrator();
        hasAmplitudeControl = Vibration.HasAmplitudeControl();
        hasFrequencyControl = Vibration.HasFrequencyControl();
        qFactor = Vibration.getQFactor();
        resonantFrequency = Vibration.getResonantFrequency();
    }

    private void LateUpdate()
    {
        VibrationFeaturesText.text = $"hasVibrator = {hasVibrator}\nhasAmplitudeControl = {hasAmplitudeControl}\nhasFrequencyControl = {hasFrequencyControl}\nQFactor = {qFactor}\nresonantFrequency = {resonantFrequency}\nCustom Vibration Duration = {VibrationTimeSlider.value}(ms)";
    }
}