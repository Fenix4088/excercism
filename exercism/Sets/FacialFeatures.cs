namespace Exercism.Sets;

public class FacialFeatures: IEquatable<FacialFeatures>
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    public bool Equals(FacialFeatures comarable) {
        
        if(Object.ReferenceEquals(this, comarable)) {
            return true;
        }
        
        if (this.GetType() != comarable.GetType())
        {
            return false;
        }
        
        return this.EyeColor.Equals(comarable.EyeColor) && this.PhiltrumWidth.Equals(comarable.PhiltrumWidth);
    }

    public override int GetHashCode()
    {
        return (EyeColor, PhiltrumWidth).GetHashCode();
    }
}

public class Identity: IEquatable<Identity>
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }
    
    public bool Equals(Identity comarable) {
        if(Object.ReferenceEquals(this, comarable)) {
            return true;
        }
        
        if (this.GetType() != comarable.GetType())
        {
            return false;
        }
        
        return this.Email.Equals(comarable.Email) && this.FacialFeatures.Equals(comarable.FacialFeatures);
    }
    
    public override int GetHashCode()
    {
        return (Email, FacialFeatures).GetHashCode();
    }
}

public class Authenticator
{
    private FacialFeatures AdminFacialFeatures = new FacialFeatures("green", 0.9m);
    private string AdminEmail = "admin@exerc.ism";
    private HashSet<Identity> IdentityStorage = new HashSet<Identity>();
    
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) => faceA.Equals(faceB);

    public bool IsAdmin(Identity identity) => identity.Equals(new Identity(AdminEmail, AdminFacialFeatures));

    public bool Register(Identity identity)
    {
        return IdentityStorage.Add(identity);
    }

    public bool IsRegistered(Identity identity)
    {
        return IdentityStorage.Contains(identity);
    }

    public static bool AreSameObject(Identity identityA, Identity identityB)
    {
        return Object.ReferenceEquals(identityA, identityB);
    }
}