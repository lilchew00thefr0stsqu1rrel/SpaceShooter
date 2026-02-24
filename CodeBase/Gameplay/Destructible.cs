using UnityEngine;
using Common;

namespace SpaceShooter
{
    public class Destructible : DestructibleBase
    {
        [SerializeField] private int m_ScoreValue;
        public int ScoreValue => m_ScoreValue;


    }
}

