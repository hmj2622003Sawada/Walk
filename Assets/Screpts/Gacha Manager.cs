using UnityEngine;
using TMPro;

public class GachaManager : MonoBehaviour
{
	[SerializeField] private TMP_Text resultText;
	[SerializeField] private GachaCapsuleAnimation capsuleAnimation;

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
			capsuleAnimation.SetGlowColor(Color.white);
		}
		else if (random < 85)
		{
			resultText.text = "R：レアスキン！";
			capsuleAnimation.SetGlowColor(Color.blue);
		}
		else if (random < 97)
		{
			resultText.text = "SR：スーパーレアスキン！";
			capsuleAnimation.SetGlowColor(new Color(0.6f, 0.1f, 1f));
		}
		else
		{
			resultText.text = "HR：ハイパーレアスキン！！";
			capsuleAnimation.SetGlowColor(Color.yellow);
		}

		// カプセル演出を開始
		capsuleAnimation.PlayAnimation();
	}
}