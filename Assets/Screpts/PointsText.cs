using UnityEngine;
using TMPro;

public class PointText : MonoBehaviour
{
	[SerializeField] private TMP_Text pointText;

	void Update()
	{
		if (PointsManager.Instance != null)
		{
			pointText.text = "所持ポイント： "
				+ PointsManager.Instance.Points;
		}
	}
}