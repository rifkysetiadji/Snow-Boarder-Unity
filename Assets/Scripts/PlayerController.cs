using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] ParticleSystem boardEffect;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float normalSpeed = 20f;

    SurfaceEffector2D ground;
    bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        ground = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            ResponseToBoost();
            ShowEffectBoard();
        }
        
    }

    public void DisableControls()
    {
        canMove = false;
    }
    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
    void ShowEffectBoard()
    {
        if (Input.GetKey(KeyCode.N))
        {
            boardEffect.Play();
            Invoke("clearBoardEffect", 1f);
        }
    }
    void clearBoardEffect()
    {
        boardEffect.Stop();
    }

    void ResponseToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            ground.speed = boostSpeed;
        }
        else
        {
            ground.speed = normalSpeed;
        }
    }
}
