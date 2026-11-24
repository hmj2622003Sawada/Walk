using UnityEngine;
using UnityEngine.InputSystem;

public class SkinManager : MonoBehaviour
{
	public CharacterSkinController skinController;

	public SkinData Skin1;
	public SkinData Skin2;
	public SkinData Skin3;
	public SkinData Skin4;
	public SkinData Skin5;
	public SkinData Skin6;
	public SkinData Skin7;
	public SkinData Skin8;

	private void Start()
	{
		skinController.ChangeSkin(Skin1);
	}

	private void Update()
	{
		var keyboard = Keyboard.current;

		if (keyboard == null) return;

		if (Keyboard.current.digit0Key.wasPressedThisFrame)
		{
			skinController.ChangeSkin(Skin1);
		}
		if (Keyboard.current.digit1Key.wasPressedThisFrame)
		{
			skinController.ChangeSkin(Skin2);
		}
		if (Keyboard.current.digit2Key.wasPressedThisFrame)
		{
			skinController.ChangeSkin(Skin3);
		}
		if (Keyboard.current.digit3Key.wasPressedThisFrame)
		{
			skinController.ChangeSkin(Skin4);
		}
		if (Keyboard.current.digit4Key.wasPressedThisFrame)
		{
			skinController.ChangeSkin(Skin5);
		}
		if (Keyboard.current.digit5Key.wasPressedThisFrame)
		{
			skinController.ChangeSkin(Skin6);
		}
		if (Keyboard.current.digit6Key.wasPressedThisFrame)
		{
			skinController.ChangeSkin(Skin7);
		}
		if (Keyboard.current.digit7Key.wasPressedThisFrame)
		{
			skinController.ChangeSkin(Skin8);
		}
	}
}
