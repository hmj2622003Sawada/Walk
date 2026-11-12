using UnityEngine;
using UnityEngine.InputSystem;

public class MoveController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
	}

	float speed = 5.0f; // ˆÚ“®‘¬“x
    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.wKey.wasPressedThisFrame)
		{
			transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
		}
    }
}
