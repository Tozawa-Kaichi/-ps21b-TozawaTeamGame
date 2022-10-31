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

    public void SoundVolumeOnValueChanged(float value)  //�X���C�_�[�̐��l���ύX���ꂽ����s
    {
        _volumeText.text = (value * 100).ToString("0");
        _audioSource.volume = value;
    }

    public void ChangeGameScene()
    {
        //�^�C�g���V�[������Q�[���V�[���֑J��
        SceneManager.LoadScene("GameScene");
    }

    public void OpenVolumeSettingScreen()
    {
        //���ʒ����p�l����\��
        _volumeSettingScreen.SetActive(true);
    }

    public void ExitVolumeSettingScreen()
    {
        //���ʒ����p�l�������
        _volumeSettingScreen.SetActive(false);
    }

    public void OpenHowToPlayScreen()
    {
        //�V�ѕ��p�l����\��
        _HowToScreen.SetActive(true);
    }

    public void ExitHowToScreenSettingScreen()
    {
        //���ʒ����p�l�������
        _HowToScreen.SetActive(false);
    }
}
