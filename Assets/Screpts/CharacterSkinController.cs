using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSkinController : MonoBehaviour
{
	GameObject currentSkinObject; // 現在表示中のスキンモデル

	// スキンの切り替え
	public void ChangeSkin(SkinData newSkinData)
	{
		// 古いスキンがある場合、消去する
		if(currentSkinObject != null)
		{
			Destroy(currentSkinObject);
		}

		// 新しいスキンのプレハブを自分の子要素として生成
		currentSkinObject = Instantiate(newSkinData.skinPrefab, this.transform);

		// 位置や向きのリセット
		currentSkinObject.transform.localPosition = Vector3.zero;
		currentSkinObject.transform.localRotation = Quaternion.identity;
	}

	
}
