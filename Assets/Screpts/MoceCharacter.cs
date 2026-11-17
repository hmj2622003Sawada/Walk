using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class MoceCharacter : MonoBehaviour
{
	// アニメーション
	Animator animator;
	Vector2 startScale;
	int direction;

	// 移動
	public float moveSpeed = 5.0f;
	private CharacterController controller;
	bool walkflag = false; // 歩いているか

	// カメラ
	[Tooltip("MaineCamera")]
	public Transform cameraTransform;
	[Tooltip("体の回転の滑らかさ")]
	public float turnSpeed = 15f;
	enum PlayerState
	{
		Idle,
		Walk,
		Run,
		Attack
	}

	void Start()
	{
		animator = GetComponent<Animator>(); // Animatorコンポーネントを取得
		startScale = transform.localScale;   // 最初のスケール値を取得

		if(cameraTransform == null && Camera.main != null)
		{
			cameraTransform = Camera.main.transform;
		}
	}

	void Update()
	{
		if (cameraTransform == null) return;

		// カメラの正面方向を取得する
		Vector3 cameraForward = cameraTransform.forward;

		// 水平方向が有効な場合のみ回転を行う
		if(cameraForward.sqrMagnitude > 0.001f)
		{
			Quaternion targetRotation = Quaternion.LookRotation(cameraForward);
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
		}
		// 移動
		if(Keyboard.current.wKey.isPressed && walkflag == false)
		{
			walkflag = true;
			animator.SetBool("IsWalk", true); // 歩く状態への移行
		}
		else if(Keyboard.current.wKey.wasReleasedThisFrame && walkflag == true)
		{
			walkflag = false;
			animator.SetBool("IsWalk", false); // アイドル状態への移行
		}

		if (walkflag == true)
		{
			transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
			
		}

		// 攻撃
		if(Mouse.current.leftButton.wasPressedThisFrame)
		{
			animator.SetTrigger("IsAttack");
		}
	}
}
