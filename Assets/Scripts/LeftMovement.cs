using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{
    [SerializeField] float _speed;

    BoxCollider2D _boxCollider;
    float _groundWidth;
    // Start is called before the first frame update
    void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _groundWidth = _boxCollider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x - _speed * Time.deltaTime, transform.position.y);

        if(transform.position.x <= -_groundWidth)
        {
            transform.position = new Vector2(transform.position.x + 2 * _groundWidth, transform.position.y);
        }
    }
}
