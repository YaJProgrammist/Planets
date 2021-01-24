using System;

namespace Gameplay
{
    [Serializable]
    public class PlanetMoveData
    {
        public Planet Planet;
        public float InitialAngle;
        public float AnglePerSecond;
        public float OrbitalRadius;
    }
}