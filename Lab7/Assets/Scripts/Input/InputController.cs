using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private GameObject go;
    private IMovable moveObj;

    private void Awake()
    {
        if (!go.TryGetComponent<IMovable>(out moveObj))
            throw new System.Exception("Obj don`t have IMovable interface");
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool jump = Input.GetButtonDown("Jump");

        moveObj.Move(horizontal, vertical, jump);
    }


}