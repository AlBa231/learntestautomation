using System.Runtime.Serialization;
using System.Text;
using FlyObject.Lib.Restrictions;

namespace FlyObject;

[Serializable]
public class FlyableRestrictionException : Exception
{
    public IReadOnlyCollection<IRestriction> FailedRestrictions { get; } = new List<IRestriction>();

    public FlyableRestrictionException()
    {
    }

    public FlyableRestrictionException(IList<IRestriction> failedRestrictions): this(GetRestrictionMessage(failedRestrictions))
    {
        FailedRestrictions = failedRestrictions.ToList();
    }

    public FlyableRestrictionException(string? message) : base(message)
    {
    }

    public FlyableRestrictionException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected FlyableRestrictionException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    private static string GetRestrictionMessage(IList<IRestriction> failedRestrictions)
    {
        var sbResult = new StringBuilder();
        foreach (var restriction in failedRestrictions)
        {
            sbResult.AppendLine($"Failed restriction {restriction.GetType().Name}. {restriction.ErrorMessage}.");
        }

        return sbResult.ToString();
    }
}