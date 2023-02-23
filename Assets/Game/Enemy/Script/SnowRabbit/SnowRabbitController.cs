using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowRabbitController : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] SnowRabbitStateMachine _stateMachine = default;
    SnowRabbitStatus _status = default;
    Rigidbody2D _rb2d = default;
    Renderer _renderer;

    // 各種bool
    bool _canMove = false;

    // 以下プロパティ
    public SnowRabbitStateMachine SnowRabbitStateMachine => _stateMachine;

    public SnowRabbitStatus Status => _status;

    public Rigidbody2D Rb2D => _rb2d;

    public Renderer Renderer => _renderer;

    public bool CanMove { get { return _canMove; } set { _canMove = value; } }

    private void Awake()
    {
        _stateMachine.Init(this);
        _rb2d = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<Renderer>();
        _status = GetComponent<SnowRabbitStatus>();
    }

    private void Update()
    {
        _stateMachine.Update();
        if (_canMove)
        {
            Move();
        }
    }

    private void Move()
    {
        _rb2d.velocity = new Vector2(_speed, _rb2d.velocity.y);
    }

    /// <summary>
    /// カメラの範囲内かどうかを判定する
    /// でもSceneViewの範囲内も影響するため後に仕様を変える
    /// </summary>
    /// <returns></returns>
    public bool InCamera()
    {
        if (_renderer.isVisible) return true;
        else return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            _speed *= -1;
        }
    }

    // 以下Raycast関連

}
