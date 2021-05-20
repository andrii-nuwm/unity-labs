using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private int count;
    private int countCubes;
    public Text countText;
    public Text nonCountText;
    public Text winText;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        winText.text = "";

        countCubes = GameObject.FindGameObjectsWithTag("cubes").Length;
        setCount();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "cubes")
        {
            Destroy(other.gameObject);
            count++;
            setCount();
        }
    }

    private void setCount(){
        countText.text = "Кількість: " + count;
        nonCountText.text = "Залишилось: " + (countCubes - count);
        if(count >= countCubes)
            winText.text = "Перемога";
    }
}
