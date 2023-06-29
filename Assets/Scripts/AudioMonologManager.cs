using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMonologManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject Monolog1;
    public GameObject Monolog2;
    public GameObject Monolog3;
    public GameObject Monolog4;
    public GameObject Winning;

    AudioSource MonologAudio1;
    AudioSource MonologAudio2;
    AudioSource MonologAudio3;
    AudioSource MonologAudio4;
    AudioSource WinningAudio;

    public float updateStep = 0.1f;
    public int sampleDataLength = 1024;

    private float currentUpdateTime = 0f;

    public float clipLoudness;
    private float[] clipSampleData;


    [SerializeField] private Material material;
    public float sizeFactor = 1;

    public float minSize = 0;
    public float maxSize = 500;


    bool Mon1Played = false;
    bool Mon2Played = false;
    bool Mon3Played = false;
    bool Mon4Played = false;
    public GameObject ChainManager;
    private void Awake()
    {
        clipSampleData = new float[sampleDataLength];
    }

    // Start is called before the first frame update
    void Start()
    {
        MonologAudio1 = Monolog1.GetComponent<AudioSource>();
        MonologAudio2 = Monolog2.GetComponent<AudioSource>();
        MonologAudio3 = Monolog3.GetComponent<AudioSource>();
        MonologAudio4 = Monolog4.GetComponent<AudioSource>();
        WinningAudio = Winning.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        currentUpdateTime += Time.deltaTime;

        if (ChainManager.GetComponent<EvilFalldown>().chains == 2 && Mon2Played == false)
        {
            MonologAudio1.Pause();
            MonologAudio2.Play(0);
            Mon2Played = true;
            Debug.Log("Monolog2");
        }
        else if (ChainManager.GetComponent<EvilFalldown>().chains == 1 && Mon3Played == false)
        {
            MonologAudio2.Pause();
            MonologAudio3.Play(0);
            Mon3Played = true;
            Debug.Log("Monolog3");
        }
        else if (ChainManager.GetComponent<EvilFalldown>().chains == 0 && Mon4Played == false)
        {
            MonologAudio3.Pause();
            MonologAudio4.Play(0);
            Mon4Played = true;
            Debug.Log("Monolog4");
            StartCoroutine(Wait());

        }

        //Setzt das ShaderMat auf die Lautstärke
        if (currentUpdateTime >= updateStep)
        {
            currentUpdateTime = 0f;

            MonologAudio1.clip.GetData(clipSampleData, MonologAudio1.timeSamples); //I read 1024 samples, which is about 80 ms on a 44khz stereo clip, beginning at the current sample position of the clip.
            clipLoudness = 0f;
            foreach (var sample in clipSampleData)
            {
                clipLoudness += Mathf.Abs(sample);
            }

            MonologAudio2.clip.GetData(clipSampleData, MonologAudio2.timeSamples); //I read 1024 samples, which is about 80 ms on a 44khz stereo clip, beginning at the current sample position of the clip.
            foreach (var sample in clipSampleData)
            {
                clipLoudness += Mathf.Abs(sample);
            }

            MonologAudio3.clip.GetData(clipSampleData, MonologAudio3.timeSamples); //I read 1024 samples, which is about 80 ms on a 44khz stereo clip, beginning at the current sample position of the clip.
            foreach (var sample in clipSampleData)
            {
                clipLoudness += Mathf.Abs(sample);
            }

            MonologAudio4.clip.GetData(clipSampleData, MonologAudio4.timeSamples); //I read 1024 samples, which is about 80 ms on a 44khz stereo clip, beginning at the current sample position of the clip.
            foreach (var sample in clipSampleData)
            {
                clipLoudness += Mathf.Abs(sample);
            }

            clipLoudness /= sampleDataLength; //clipLoudness is what you are looking for

            clipLoudness *= sizeFactor;
            clipLoudness = Mathf.Clamp(clipLoudness, minSize, maxSize);
            material.SetFloat("_DissolveAmount", clipLoudness*9);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player && Mon1Played == false)
        {
            MonologAudio1.Play(0);
            Mon1Played = true;
            Debug.Log("Monolog1");
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(8);
        WinningAudio.Play(0);
    }
}
