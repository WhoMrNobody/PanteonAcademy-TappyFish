using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] float _speed;

    int angle;
    int maxAngle= 30;
    int minAngle=-40;

    public ObstacleSpawner obstacleSpawner;
    [SerializeField] Score score;
    [SerializeField] GameManager gameManager;
    [SerializeField] Sprite fishDied;
    SpriteRenderer _spriteRenderer;
    Animator _anim;

    bool _touchedGround;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        FishSwim();

        
    }

    void FixedUpdate()
    {
        FishRotation();

    }

    void FishSwim()
    {
        if (Input.GetMouseButtonDown(0))
        {   
            if(GameManager.isGameStarted == false)
            {
                _rb.gravityScale = 5f;
                _rb.velocity = Vector2.zero;
                _rb.velocity = new Vector2(_rb.velocity.x, _speed);
                obstacleSpawner.InstantiateObstacle();
                gameManager.GameHasStarted();
            }
            _rb.velocity = Vector2.zero;
            _rb.velocity = new Vector2(_rb.velocity.x, _speed);
        }
    }

    void FishRotation()
    {
        if (_rb.velocity.y > 0)
        {
            if (angle <= maxAngle)
            {
                angle += 4;
            }

        }
        else if (_rb.velocity.y < -2.5f)
        {
            if (angle > minAngle)
            {
                angle -= 2;
            }
        }

        if (_touchedGround == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            score.Scored();

        }
        else if (collision.CompareTag("Column"))
        {
            gameManager.GM_GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if(GameManager.gameOver == false)
            {
                gameManager.GM_GameOver();
                GameOver();
            } 
        }
    }

    void GameOver()
    {
        _touchedGround = true;
        _spriteRenderer.sprite = fishDied;
        _anim.enabled = false;
        transform.rotation = Quaternion.Euler(0, 0, -90);
    }
}
