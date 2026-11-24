using UnityEngine;

[CreateAssetMenu(fileName = "NewSkinData", menuName = "SkinSystem/SkinData")]
public class SkinData : ScriptableObject
{
	public int skinId; // セーブに使うID
	public string skinName; // スキンの名前
	public GameObject skinPrefab; // スキンのプレハブ
}
