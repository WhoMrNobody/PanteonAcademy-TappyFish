using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{
    [SerializeField] float _speed;

    BoxCollider2D _boxCollider;
    float _groundWidth;
    float _obstacleWidth;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.CompareTag("Ground"))
        {
            _boxCollider = GetComponent<BoxCollider2D>();
            _groundWidth = _boxCollider.size.x;

        }
        else if (gameObject.CompareTag("Obstacle"))
        {
            _obstacleWidth = GameObject.FindGameObjectWithTag("Column").GetComponent<BoxCollider2D>().size.x;
        }
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(GameManager.gameOver == false)
        {
            transform.position = new Vector2(transform.position.x - _speed * Time.deltaTime, transform.position.y);
        }
        

        if (gameObject.CompareTag("Ground"))
        {
            if (transform.position.x <= -_groundWidth)
            {
                transform.position = new Vector2(transform.position.x + 2 * _groundWidth, transform.position.y);
            }
        }
        else if (gameObject.CompareTag("Obstacle"))
        {
            if(transform.position.x < GameManager.bottomLeft.x - _obstacleWidth)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
