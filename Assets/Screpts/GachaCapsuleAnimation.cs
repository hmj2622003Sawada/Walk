using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GachaCapsuleAnimation : MonoBehaviour
{
	[Header("カプセル")]
	[SerializeField] private Image capsuleImage;
	[SerializeField] private RectTransform capsuleTop;
	[SerializeField] private RectTransform capsuleBottom;

	[Header("演出設定")]
	[SerializeField] private float appearDuration = 0.4f;
	[SerializeField] private float shakeDuration = 1.0f;
	[SerializeField] private float shakeAngle = 12f;
	[SerializeField] private float openDistance = 180f;
	[SerializeField] private float openDuration = 0.5f;

	private Vector3 originalScale;
	private Vector2 topStartPosition;
	private Vector2 bottomStartPosition;
	private Quaternion topStartRotation;
	private Quaternion bottomStartRotation;

	private bool isPlaying;

	private void Awake()
	{
		originalScale = transform.localScale;

		topStartPosition = capsuleTop.anchoredPosition;
		bottomStartPosition = capsuleBottom.anchoredPosition;

		topStartRotation = capsuleTop.localRotation;
		bottomStartRotation = capsuleBottom.localRotation;

		// 親の画像は使わず、上下の画像を使う
		capsuleImage.enabled = false;

		capsuleTop.gameObject.SetActive(false);
		capsuleBottom.gameObject.SetActive(false);
	}

	public void PlayAnimation()
	{
		if (isPlaying) return;

		StartCoroutine(PlayAnimationCoroutine());
	}

	private IEnumerator PlayAnimationCoroutine()
	{
		isPlaying = true;

		capsuleTop.gameObject.SetActive(true);
		capsuleBottom.gameObject.SetActive(true);

		transform.localScale = Vector3.zero;

		// 登場
		float timer = 0f;

		while (timer < appearDuration)
		{
			timer += Time.deltaTime;
			float t = Mathf.Clamp01(timer / appearDuration);

			transform.localScale = originalScale * t;

			yield return null;
		}

		transform.localScale = originalScale;

		// 揺れる
		timer = 0f;

		while (timer < shakeDuration)
		{
			timer += Time.deltaTime;

			float angle = Mathf.Sin(timer * 25f) * shakeAngle;
			transform.localRotation = Quaternion.Euler(0, 0, angle);

			yield return null;
		}

		transform.localRotation = Quaternion.identity;

		// カプセルが開く
		timer = 0f;

		while (timer < openDuration)
		{
			timer += Time.deltaTime;
			float t = Mathf.Clamp01(timer / openDuration);

			capsuleTop.anchoredPosition =
				topStartPosition + Vector2.up * openDistance * t;

			capsuleBottom.anchoredPosition =
				bottomStartPosition + Vector2.down * openDistance * t;

			capsuleTop.localRotation =
				topStartRotation * Quaternion.Euler(0, 0, -45f * t);

			capsuleBottom.localRotation =
				bottomStartRotation * Quaternion.Euler(0, 0, 45f * t);

			yield return null;
		}

		isPlaying = false;
	}
}