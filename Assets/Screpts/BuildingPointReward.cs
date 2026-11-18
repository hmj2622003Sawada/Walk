using UnityEngine;

public class BuildingPointReward : MonoBehaviour
{
	[Header("建物破壊時の獲得ポイント")]
	[SerializeField] private int rewardPoints = 500;

	private bool rewarded = false;

	// 建物が完全に壊れたときに呼び出す
	public void GivePoints()
	{
		if (rewarded) return;

		if (PointsManager.Instance == null)
		{
			Debug.LogError("PointsManagerが見つかりません！");
			return;
		}

		PointsManager.Instance.AddPoints(rewardPoints);
		rewarded = true;

		Debug.Log($"{gameObject.name}を破壊！ {rewardPoints}ポイント獲得！");
	}
}