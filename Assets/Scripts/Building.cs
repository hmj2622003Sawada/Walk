using UnityEngine;

public class Building : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Attack"))
        {
            // 見た目と当たり判定を無効化する
            MeshRenderer ren = GetComponent<MeshRenderer>();
            Collider col = GetComponent<Collider>();

            if (ren != null){ ren.enabled = false; }
            if (col != null){ col.enabled = false; }
            // パーティクルを再生する
            if (ren != null && col != null)
            {
                ParticleSystem ps = GetComponent<ParticleSystem>();
                ps.Play();
                // パーティクルの再生時間と最大寿命を足した時間後にオブジェクトを破壊する
                Destroy(gameObject, ps.main.duration + ps.main.startLifetime.constantMax);
            }
        }
    }
}