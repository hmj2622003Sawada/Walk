using UnityEngine;

public class PointsManager : MonoBehaviour
{
	public static PointsManager Instance;

	[Header("ポイント設定")]
	[SerializeField] private int initialPoints = 5000;

	[Header("現在の所持ポイント")]
	[SerializeField] private int points;

	public int Points => points;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);

			points = PlayerPrefs.GetInt("Points", initialPoints);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void AddPoints(int amount)
	{
		points += amount;
		SavePoints();
	}

	public bool SpendPoints(int amount)
	{
		if (points < amount)
			return false;

		points -= amount;
		SavePoints();
		return true;
	}

	private void SavePoints()
	{
		PlayerPrefs.SetInt("Points", points);
		PlayerPrefs.Save();
	}
	[ContextMenu("ポイントを初期値にリセット")]
	private void ResetPoints()
	{
		points = initialPoints;
		SavePoints();
	}
}