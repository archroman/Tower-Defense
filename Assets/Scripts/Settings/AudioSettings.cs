using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Settings
{
    internal sealed class AudioSettingsUI : MonoBehaviour
    {
        private const string MusicKey = "music_vol_lin"; 
        private const string SfxKey = "sfx_vol_lin";
        
        [Header("Mixer & parameters")]
        [SerializeField] private AudioMixer _mainMixer;
        [SerializeField] private string _musicParam = "MusicVolume";
        [SerializeField] private string _sfxParam   = "SFXVolume";

        [Header("UI")]
        [SerializeField] private Slider _sfxSlider;
        [SerializeField] private Slider _musicSlider;


        private void Awake()
        {
            float music = PlayerPrefs.GetFloat(MusicKey, 0.25f);
            float sfx   = PlayerPrefs.GetFloat(SfxKey,   0.75f);

            _musicSlider.SetValueWithoutNotify(music);
            _sfxSlider.SetValueWithoutNotify(sfx);

            ApplyLinearToMixer(music, _musicParam);
            ApplyLinearToMixer(sfx,   _sfxParam);

            _musicSlider.onValueChanged.AddListener(OnMusicChanged);
            _sfxSlider.onValueChanged.AddListener(OnSfxChanged);
        }

        private void OnDestroy()
        {
            _musicSlider.onValueChanged.RemoveListener(OnMusicChanged);
            _sfxSlider.onValueChanged.RemoveListener(OnSfxChanged);
        }

        private void OnMusicChanged(float linear)
        {
            ApplyLinearToMixer(linear, _musicParam);
            PlayerPrefs.SetFloat(MusicKey, linear);
        }

        private void OnSfxChanged(float linear)
        {
            ApplyLinearToMixer(linear, _sfxParam);
            PlayerPrefs.SetFloat(SfxKey, linear);
        }

        private void ApplyLinearToMixer(float linear, string param)
        {
            if (linear <= 0.0001f)
            {
                _mainMixer.SetFloat(param, -80f); 
            }
            else
            {
                float dB = Mathf.Log10(linear) * 20f; 
                _mainMixer.SetFloat(param, dB);
            }
        }
    }
}
