namespace StorageApi.DTOs
{
    public record ProductStatsDto
    (
        int TotaltAmountOfProducts,
        int TotaltStorageValue,
        decimal AveragePrice
    );
}
