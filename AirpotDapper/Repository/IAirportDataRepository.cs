using System.Collections.Generic;
using Model.Model;

namespace AirportDapper.Repository
{
    public interface IAirportDataRepository
    {
        bool Add(AirportData airportData);

        List<AirportData> GetAll();
    }
}
