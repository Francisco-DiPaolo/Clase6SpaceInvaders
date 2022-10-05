using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }
    public static Action<string> instanceSound;

    [SerializeField] AudioSource shoot;
    [SerializeField] AudioSource invaderKilled;

    void Start()
    {
        if (instance != null && instance != this) Destroy(this.gameObject);
        else instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void InstantiateSound(string nameSound)
    {
        if (nameSound == "shoot") shoot.Play();
        else if (nameSound == "invaderKilled") invaderKilled.Play();
    }

    private void OnEnable()
    {
        instanceSound += InstantiateSound;
    }

    private void OnDisable()
    {
        instanceSound -= InstantiateSound;
    }
}
