using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// Îãðàíè÷èòåëü ïîçèöèè. Ðàáîòàåò â ñâÿçêå ñî ñêðèïòîì LevelBoundary åñëè òàêîâîé èìååòñÿ íà ñöåíå.
    /// Êèäàåòñÿ íà îáúåêò êîòîðûé íàäî îãðàíè÷èòü.
    /// </summary>
    public class LevelBoundaryLimiter : MonoBehaviour
    {
        private void Update()
        {
            if (LevelBoundary.Instance == null) return;

            var lb = LevelBoundary.Instance;
            var r = LevelBoundary.Instance.Radius;

            if (transform.position.magnitude > r)
            {
                if (lb.LimitMode == LevelBoundary.Mode.Limit)
                {
                    transform.position = transform.position.normalized * r; 
                }

                if (lb.LimitMode == LevelBoundary.Mode.Teleport)
                {
                    transform.position = -transform.position.normalized * r;
                }
            }

        }
    }
}

