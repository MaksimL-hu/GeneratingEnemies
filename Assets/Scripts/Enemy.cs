using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Animator))]
[RequireComponent (typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    public void Move(Vector3 direction)
    {
        _animator.SetBool("Run", true);

        if (direction.x < 0)
            _spriteRenderer.flipX = true;
        else 
            _spriteRenderer.flipX = false;

        StartCoroutine(Moving(direction));
    }

    private IEnumerator Moving(Vector3 direction)
    {
        bool _isMove = true;

        while (_isMove)
        {
            transform.Translate(direction * _speed * Time.deltaTime);
            yield return null;
        }
    }
}