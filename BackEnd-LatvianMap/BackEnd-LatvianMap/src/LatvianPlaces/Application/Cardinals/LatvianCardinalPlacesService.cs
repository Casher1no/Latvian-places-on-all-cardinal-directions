using BackEnd_LatvianMap.LatvianPlaces.Model;

namespace BackEnd_LatvianMap.LatvianPlaces.Application.Cardinals;

public class LatvianCardinalPlacesService
{
    private readonly ILatvianCardinalPlacesRepository _latvianCardinalPlacesRepository;

    public LatvianCardinalPlacesService(ILatvianCardinalPlacesRepository latvianCardinalPlacesRepository)
    {
        _latvianCardinalPlacesRepository = latvianCardinalPlacesRepository;
    }
    
    public Dictionary<string, Centroids> Invoke()
    {
        List<Centroids> cardinalPoints = this._latvianCardinalPlacesRepository.GetLatvianPlaces();
            
        Dictionary<string, Centroids> cardinalPointList = new Dictionary<string, Centroids>();

        cardinalPointList.Add("furthestNorth", cardinalPoints.MaxBy(c => c.DD_N));
        cardinalPointList.Add("furthestSouth", cardinalPoints.MinBy(c => c.DD_N));
        cardinalPointList.Add("furthestEast", cardinalPoints.MaxBy(c => c.DD_E));
        cardinalPointList.Add("furthestWest", cardinalPoints.MinBy(c => c.DD_E));
        
        return cardinalPointList;
    }
}