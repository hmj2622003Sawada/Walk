using UnityEngine;

public class GachaGlowEffect : MonoBehaviour
{
	[SerializeField] private ParticleSystem glowEffect;

	public void PlayGlow(Color glowColor)
	{
		ParticleSystem.MainModule main = glowEffect.main;
		main.startColor = glowColor;

		glowEffect.Play();
	}
}