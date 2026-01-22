namespace Ordering.Application.Dtos
{
    public record AddressDto(
        string EmailAddress,
        string FirstName,
        string LastName,
        string AddressLine,
        string Country,
        string State,
        string ZipCode
    );
}