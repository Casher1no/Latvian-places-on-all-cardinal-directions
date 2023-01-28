using BackEnd_LatvianMap.LatvianPlaces.Infrastructure.Persistence.csv;
using BackEnd_LatvianMap.LatvianPlaces.Model;

namespace BackEnd_LatvianMap.DI;

public class DataAccessFactory
{
    public static ILatvianCardinalPlacesRepository LatvianCardinalPlacesRepository()
    {
        return new CsvLatvianCardinalPlacesRepository();
    }
}