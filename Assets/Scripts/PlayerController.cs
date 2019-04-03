using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10f;

    [SerializeField] Animator animator;

    private static PlayerController instance;
    private string areaTransitionName;

    public static PlayerController Instance { get => instance; set => instance = value; }
    public string AreaTransitionName { get => areaTransitionName; set => areaTransitionName = value; }

    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        } else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }


    void Update()
    {
        
        float moveX = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        transform.Translate(moveX, moveY, 0f);

        animator.SetFloat("moveX", moveX);
        animator.SetFloat("moveY", moveY);

        if (Input.GetAxisRaw("Horizontal") == 1 || 
            Input.GetAxisRaw("Horizontal") == -1 || 
            Input.GetAxisRaw("Vertical") == 1 || 
            Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }
    }
}
