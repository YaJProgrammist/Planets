using System.Collections.Generic;

namespace Gameplay
{
    public interface IPlanetsListController
    {
        IReadOnlyCollection<Planet> GetPlanetsList();
        Sun GetSun();
        Planet GetPlayerPlanet();
    }
}
