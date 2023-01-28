using BackEnd_LatvianMap.LatvianPlaces.Model;

namespace BackEnd_LatvianMap.LatvianPlaces.Application.Cardinals;

public class LatvianCardinalPlacesService
{
    private readonly ILatvianCardinalPlacesRepository _latvianCardinalPlacesRepository;

    public LatvianCardinalPlacesService(ILatvianCardinalPlacesRepository latvianCardinalPlacesRepository)
    {
        _latvianCardinalPlacesRepository = latvianCardinalPlacesRepository;
    }
    
    public Dictionary<string, City> Invoke()
    {
        List<City> cardinalPoints = this._latvianCardinalPlacesRepository.GetLatvianPlaces();
     
        Dictionary<string, City> cardinalPointList = new Dictionary<string, City>();

        cardinalPointList.Add("furthestNorth", cardinalPoints.MaxBy(c => c.DD_N));
        cardinalPointList.Add("furthestSouth", cardinalPoints.MinBy(c => c.DD_N));
        cardinalPointList.Add("furthestEast", cardinalPoints.MaxBy(c => c.DD_E));
        cardinalPointList.Add("furthestWest", cardinalPoints.MinBy(c => c.DD_E));
        
        return cardinalPointList;
    }
}