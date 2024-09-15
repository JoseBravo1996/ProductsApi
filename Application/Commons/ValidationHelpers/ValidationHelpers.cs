namespace Application.Commons.ValidationHelpers;

public static class ValidationHelpers
{
    public static bool BeGuid(string id) => Guid.TryParse(id, out _);
}