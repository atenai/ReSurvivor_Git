using UnityEngine;
using UnityEngine.Advertisements;

//�Q�l�T�C�g
//https://www.youtube.com/watch?v=tzgOTVPXC-I
//https://www.youtube.com/watch?v=gzTs3WpzhWg

//�K��ADS�̃o�[�W������4.3.0�ɂ��邱�ƁI�I

//�L���S�̂̏�����
public class AdsInitialize : MonoBehaviour, IUnityAdsInitializationListener
{

    [SerializeField] string _androidGameId;
    [SerializeField] string _iOSGameId;
    [SerializeField] bool _testMode = false;
    private string _gameId;

    //[SerializeField] AdsRewarded adsRewardedButton;
    [SerializeField] AdsInterstitial adsInterstitialButton;

    void Awake()
    {
        InitializeAds();
    }

    //�L���̏���������
    public void InitializeAds()
    {
        Debug.Log("<color=yellow>UnityAds���������J�n</color>");
        //iOS��Android�̂ǂ���̃v���b�g�t�H�[�������擾���čL��ID���擾����
        _gameId = (Application.platform == RuntimePlatform.IPhonePlayer) ? _iOSGameId : _androidGameId;
        //�L���̏���������(�������ɍL��ID, �������Ƀe�X�g���[�h���ǂ���?, ��O�����͂킩��Ȃ�)
        Advertisement.Initialize(_gameId, _testMode, this);
    }

    //���������������������ۂɎ��s����
    public void OnInitializationComplete()
    {
        Debug.Log("<color=blue>UnityAds���������̐���</color>");
        //�����[�h�L�������[�h����
        //adsRewardedButton.LoadAd();
        //�C���^�[�X�e�[�V���i���L�������[�h����
        adsInterstitialButton.LoadAd();
    }

    //���������������s�����ꍇ�Ɏ��s����
    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("<color=red>UnityAds�������������Ɏ��s</color>");
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
}