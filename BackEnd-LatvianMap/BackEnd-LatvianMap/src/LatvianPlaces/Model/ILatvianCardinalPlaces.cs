namespace BackEnd_LatvianMap.LatvianPlaces.Model;

public interface ILatvianCardinalPlacesRepository
{
    public List<Centroids> GetLatvianPlaces();
}