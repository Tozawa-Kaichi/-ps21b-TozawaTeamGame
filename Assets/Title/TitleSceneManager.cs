using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject _volumeSettingScreen; 
    [SerializeField] private GameObject _HowToScreen;

    [SerializeField] private Text _volumeText;
    [SerializeField] private Slider _volumeSlider;
    private AudioSource _audioSource;


    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _volumeSlider.onValueChanged.AddListener(SoundVolumeOnValueChanged);
    }

    public void SoundVolumeOnValueChanged(float value)  //スライダーの数値が変更されたら実行
    {
        _volumeText.text = (value * 100).ToString("0");
        _audioSource.volume = value;
    }

    public void ChangeGameScene()
    {
        //タイトルシーンからゲームシーンへ遷移
        SceneManager.LoadScene("GameScene");
    }

    public void OpenVolumeSettingScreen()
    {
        //音量調整パネルを表示
        _volumeSettingScreen.SetActive(true);
    }

    public void ExitVolumeSettingScreen()
    {
        //音量調整パネルを閉じる
        _volumeSettingScreen.SetActive(false);
    }

    public void OpenHowToPlayScreen()
    {
        //遊び方パネルを表示
        _HowToScreen.SetActive(true);
    }

    public void ExitHowToScreenSettingScreen()
    {
        //音量調整パネルを閉じる
        _HowToScreen.SetActive(false);
    }
}
