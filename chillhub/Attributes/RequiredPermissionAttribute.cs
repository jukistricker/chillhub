namespace chillhub.Attributes;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public class RequiredPermissionAttribute(string permission) : Attribute
{
    public string Permission { get; } = permission;
}

