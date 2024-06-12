using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
        // Velocidade de movimento do personagem
    public float moveSpeed = 5f;
    // Sensibilidade da câmera
    public float lookSensitivity = 2f;
    // Referência ao CharacterController
    private CharacterController characterController;
    // Referência ao Animator
    private Animator animator;
    // Variável para armazenar o movimento da câmera
    private Vector3 moveDirection;
    private float verticalLookRotation;

    void Start()
    {
        // Obtém os componentes necessários
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Chama as funções de movimento e controle de câmera
        Move();
        Look();
    }

    void Move()
    {
        // Obtém a entrada de movimento
        float moveX = Input.GetAxis("Horizontal"); // A/D ou Seta esquerda/direita
        float moveZ = Input.GetAxis("Vertical");   // W/S ou Seta cima/baixo

        // Define a direção do movimento
        moveDirection = transform.right * moveX + transform.forward * moveZ;
        // Move o personagem
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

        // Ativa ou desativa a animação "isWalking"
        bool isWalking = moveX != 0 || moveZ != 0;
        animator.SetBool("isWalking", isWalking);
    }

    void Look()
    {
        // Obtém a entrada do mouse
        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;

        // Roda o personagem horizontalmente
        transform.Rotate(Vector3.up * mouseX);

        // Roda a câmera verticalmente
        verticalLookRotation -= mouseY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
        Camera.main.transform.localEulerAngles = new Vector3(verticalLookRotation, 0f, 0f);
    }
}
