using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    [SerializeField] private TerrainGenerator terrainGenerator;
    [SerializeField] private Text scoreText;
    private int score;
    private Animator animator;
    private bool isHopping;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
     
        
    }


    private void Update()
    {
        scoreText.text = "Score: " + score;  
        if (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.UpArrow)) && !isHopping)
        {
            score++;
            float zDifference = 0;
            if (transform.position.z % 1 != 0)
            {
                zDifference = Mathf.Round(transform.position.z) - transform.position.z;
            }
            MoveCharacter(new Vector3(1, 0, zDifference));
        }
        else if (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.LeftArrow)) && !isHopping)
        {
            MoveCharacter(new Vector3(0, 0, 1));
        }
        else if (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.RightArrow)) && !isHopping)
        {
            MoveCharacter(new Vector3 (0, 0, -1));
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<MovingObject>() != null)
        {
            if (collision.collider.GetComponent<MovingObject>().isLog)
            {
                transform.parent = collision.collider.transform;
            }
        }
        else
        {
            transform.parent = null;   
        }
    }
    private void MoveCharacter(Vector3 difference)
    {
        animator.SetTrigger("hop");
        isHopping = true;
        transform.position = (transform.position + difference);
        terrainGenerator.SpawnTerrain(false, transform.position);
    }
    public void FinishHop()
    {
        isHopping = false;
    }
}