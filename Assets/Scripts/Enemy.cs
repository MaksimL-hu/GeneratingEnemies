using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Animator))]
[RequireComponent (typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Coroutine _movingCoroutine;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    public void Move(Transform target)
    {
        string animatorRun = "Run";

        _animator.SetBool(animatorRun, true);
        _movingCoroutine = StartCoroutine(Moving(target));
    }

    private IEnumerator Moving(Transform target)
    {
        while (transform.position != target.position)
        {
            if(target.position.x - transform.position.x < 0f)
                _spriteRenderer.flipX = true;
            else
                _spriteRenderer.flipX = false;

            transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

            yield return null;
        }
    }
}