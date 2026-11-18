using UnityEngine;
using TMPro;

public class GachaManager : MonoBehaviour
{
	[SerializeField] private TMP_Text resultText;

	private const int GachaCost = 1000;

	public void DrawGacha()
	{
		// ポイントが足りるか確認
		if (!PointsManager.Instance.SpendPoints(GachaCost))
		{
			resultText.text = "ポイントが足りません！";
			return;
		}

		// 0～99のランダム抽選
		int random = Random.Range(0, 100);

		if (random < 60)
		{
			resultText.text = "N：ノーマルスキン！";
		}
		else if (random < 85)
		{
			resultText.text = "R：レアスキン！";
		}
		else if (random < 97)
		{
			resultText.text = "SR：スーパーレアスキン！";
		}
		else
		{
			resultText.text = "HR：ハイパーレアスキン！！";
		}
	}
}