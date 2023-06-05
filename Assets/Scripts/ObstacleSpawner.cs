using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstacle;
    [SerializeField] float maxTime;
    [SerializeField] float minY;
    [SerializeField] float maxY;
    float _randomY;
    float _timer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(GameManager.gameOver == false && GameManager.isGameStarted == true)
        {
            _timer += Time.deltaTime;

            if (_timer >= maxTime)
            {
                InstantiateObstacle();
                _timer = 0;
            }
        }
        
    }

    public void InstantiateObstacle()
    {   
        _randomY = Random.Range(minY, maxY);
        GameObject newObstacle = Instantiate(obstacle);
        newObstacle.transform.position = new Vector2(transform.position.x, _randomY);

    }
}
