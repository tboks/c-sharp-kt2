namespace App.Topics.Operators.T2_1_Money;

public struct Money : IEquatable<Money>
{
    public string Currency { get; }
    public long Amount { get; }

    public Money(string currency, long amount)
    {
        if (string.IsNullOrWhiteSpace(currency))
            throw new ArgumentException("валюта не может быть 0, пробелом или null", nameof(currency));
        Currency = currency.ToUpperInvariant();
        Amount = amount;
    }

    public static bool operator ==(Money m1, Money m2)
    {
        return m1.Currency == m2.Currency && m1.Amount == m2.Amount;
    }

    public static bool operator !=(Money m1, Money m2) => !(m1 == m2);

    public override bool Equals(object obj)
    {
        if (obj is Money m) return this == m;
        return false;
    }

    public bool Equals(Money other) => this == other;

    public override int GetHashCode() => HashCode.Combine(Currency, Amount);

    public static Money operator +(Money m1, Money m2)
    {
        if (m1.Currency != m2.Currency)
            throw new ArgumentException("Невльзя складывать суммы в разных валютах.");
        return new Money(m1.Currency, m1.Amount + m2.Amount);
    }

    public static Money operator -(Money m1, Money m2)
    {
        if (m1.Currency != m2.Currency)
            throw new ArgumentException("нельзя вычитать суммы в разных валютах.");
        return new Money(m1.Currency, m1.Amount - m2.Amount);
    }

    public static Money operator ++(Money m)
    {
        return new Money(m.Currency, m.Amount + 1);
    }

    public static Money operator --(Money m)
    {
        return new Money(m.Currency, m.Amount - 1);
    }

    public static Money operator /(Money m, int divisor)
    {
        if (divisor == 0)
            throw new DivideByZeroException();
        return new Money(m.Currency, m.Amount / divisor);
    }

    public static Money operator %(Money m, int divisor)
    {
        if (divisor == 0)
            throw new DivideByZeroException();
        return new Money(m.Currency, m.Amount % divisor);
    }

    public static Money operator *(Money m, int scalar)
    {
        return new Money(m.Currency, m.Amount * scalar);
    }

    public static Money operator *(int scalar, Money m)
    {
        return new Money(m.Currency, m.Amount * scalar);
    }

    public override string ToString() => $"{Amount} {Currency}";
}