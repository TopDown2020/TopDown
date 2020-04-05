using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailBehaviour : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    public GameObject trailEffect;
    public GameObject trailEffectPrefab;
    private SpriteRenderer[] _trailSprites;
    private MoveBehaviour _moveBehaviour;
    private float _trailSpacer = 0.05f;
    private float _fadeTrail = 0.05f;
    private bool _looping = false;
    public bool Looping { get => _looping; set => _looping = value; }
    
    public void Awake()
    {
        if (trailEffect == null)
        {
            trailEffect = Instantiate(trailEffectPrefab, transform.position, Quaternion.identity);
            trailEffect.name = trailEffectPrefab.name;
            trailEffect.SetActive(true);
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _trailSprites = trailEffect.GetComponentsInChildren<SpriteRenderer>();
        }
        DontDestroyOnLoad(trailEffect.gameObject);
    }

    IEnumerator DashTrail()
    {
        for (int i = 0 ; i < _trailSprites.Length ; i++)
        {
            _trailSprites[i].enabled = true;
            _trailSprites[i].sprite = _spriteRenderer.sprite;
            _trailSprites[i].flipX = _spriteRenderer.flipX;
            _trailSprites[i].transform.position = transform.position;
            StartCoroutine(FadeDash(_trailSprites[i]));
            yield return new WaitForSecondsRealtime(_trailSpacer);
        }
        
        if (_looping)
        {
            yield return DashTrail();
        }
        else
        {
            yield return new WaitForSeconds(_trailSprites.Length);
        }
    }

    IEnumerator FadeDash(SpriteRenderer spriterender)
    {
        for (float fade = 0.9f ; fade >= 0 ; fade -= _fadeTrail)
        {
            Color c = spriterender.color;
            c.a = fade;
            spriterender.color = c;
            yield return null;
        }
        spriterender.enabled = false;
    }
}