using UnityEngine;

namespace Common
{
    [CreateAssetMenu]
    public class ProjectileProperties : ScriptableObject
    {
        [SerializeField] private float m_Velocity;

        public float Velocity => m_Velocity;

        [SerializeField] private float m_Lifetime;

        public float Lifetime => m_Lifetime;

        [SerializeField] private int m_Damage;

        public int Damage => m_Damage;

        [SerializeField] private ImpactEffect m_ImpactEffectPrefab;

        public ImpactEffect ImpactEffectPrefab => m_ImpactEffectPrefab;


    }

}
