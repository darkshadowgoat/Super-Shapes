using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 600f;

    public Button leftButton;
    public Button rightButton;

    public bool isMovingLeft = false;
    public bool isMovingRight = false;

    public SceneManagement sceneManagement;
    public GameManager gameManager;

    private void Update()
    {
        if (isMovingLeft)
        {
            MoveLeft();
        }
        else if (isMovingRight)
        {
            MoveRight();
        }
    }

    public void StartMovingLeft()
    {
        isMovingLeft = true;
    }

    public void StopMovingLeft()
    {
        isMovingLeft = false;
    }

    public void StartMovingRight()
    {
        isMovingRight = true;
    }

    public void StopMovingRight()
    {
        isMovingRight = false;
    }

    public void MoveLeft()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, Time.fixedDeltaTime * moveSpeed);
    }

    public void MoveRight()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, Time.fixedDeltaTime * -moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Score"))
        {
            gameManager.IncreaseScore();
        }
        
        if (collision.CompareTag("GameOver"))
        {
            sceneManagement.GameOver();
        }

        if (collision.CompareTag("Collectable"))
        {
            gameManager.IncreaseCollectable();
            GameObject tempGo = Instantiate(gameManager.collectableParticleSystem, collision.transform.position, collision.transform.rotation);
            Destroy(tempGo, 3f);
            Destroy(collision.gameObject);
        }
    }
}
