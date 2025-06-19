using Photon.Pun;
using UnityEngine;

public class Character : MonoBehaviourPun
{
    [SerializeField] float speed;
    [SerializeField] float mouseX;
    [SerializeField] float speed;
    [SerializeField] Vector3 direction;

    [SerializeField] Camera virtualCamera;
    [SerializeField] CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Start()
    {
        DisableCamera();
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            Control();

            Move();

            Rotate();
        }
    }

    public void Control()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");

        direction.Normalize();

        mouseX += Input.GetAxis("Mouse X") * roattionSpeed * Time.deltaTime;

        characterController.transform.transformDirection(direction);

    }

    public void Move()
    {
        // ���� * �ӵ� * �ð�
        characterController.Move(direction * speed * Time.deltaTime);
    }

    public void Rotate()
    {
        // ���� * ��� * ���
        transform.eulerAngles = new Vector3(0, mouseX, 0);
    }

    public void DisableCamera()
    {
        // ���� �÷��̾ �� �ڽ��̶��
        if (photonView.IsMine)
        {
            Camera.main.gameObject.SetActive(false);
        }
        else
        {
            virtualCamera.gameObject.SetActive(false);

            virtualCamera.GetComponent<AudioListener>().enabled = false;
        }
    }
}
