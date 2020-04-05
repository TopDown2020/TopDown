using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    private AudioSource _audioPlayer;

    public void Awake()
    {
        _audioPlayer = GetComponent<AudioSource>();
    }

    public void AttackSound(AnimationEvent animEvent)
    {
        if (animEvent.animatorClipInfo.weight > 0.5f)
        {
            _audioPlayer.PlayOneShot(AudioList.Instance.swordSwing, 0.7f);
            if (animEvent.intParameter == 1)
                _audioPlayer.PlayOneShot(AudioList.Instance.playerAttack01, 0.5f);
            if (animEvent.intParameter == 2)
                _audioPlayer.PlayOneShot(AudioList.Instance.playerAttack02, 0.5f);
        }
    }

    public void StepSound(AnimationEvent animEvent)
    {
        if (animEvent.animatorClipInfo.weight > 0.5f)
        {
            if (animEvent.intParameter == 1)
            _audioPlayer.PlayOneShot(AudioList.Instance.step01, 0.5f);
            else
            _audioPlayer.PlayOneShot(AudioList.Instance.step02, 0.5f);
        }
    }

    public void HitSound(AnimationEvent animEvent)
    {
        if (animEvent.animatorClipInfo.weight > 0.5f)
        {
            _audioPlayer.PlayOneShot(AudioList.Instance.gethit, 0.5f);
        }
    }       

    public void DashingSound(AudioClip thissound)
    {
        _audioPlayer.PlayOneShot(thissound, 0.2f);
    }   
}
