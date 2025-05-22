using Domain.Common;

namespace Domain.Promotions.ValueObjects;

public class DateRange : ValueObject
{
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }

    private DateRange() { }

    public DateRange(DateTime start, DateTime end)
    {
        if (end <= start)
            throw new ArgumentException("Bitiş tarihi, başlangıç tarihinden sonra olmalıdır.");

        StartDate = start;
        EndDate = end;
    }

    public bool IsActive(DateTime now) => now >= StartDate && now <= EndDate;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return StartDate;
        yield return EndDate;
    }
}