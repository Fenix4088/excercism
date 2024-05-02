namespace Exercism.ObjectInitializers;

public class Authenticator
{
    public Identity Admin {
        get
        {
            var admin = new Identity();
            var facialFeature = new FacialFeatures();
            (facialFeature.EyeColor, facialFeature.PhiltrumWidth) = ("green", 0.9m); 
            (admin.Email, admin.FacialFeatures, admin.NameAndAddress) = ("admin@ex.ism", facialFeature, new List<string>{"Chanakya", "Mumbai", "India"});

            return admin;
        }
    }

    public IDictionary<string, Identity> Developers {
        get
        {
            var devOne = new Identity();
            var devTwo = new Identity();
            var facialFeatureDevOne = new FacialFeatures();
            var facialFeatureDevTwo = new FacialFeatures();
            (facialFeatureDevOne.EyeColor, facialFeatureDevOne.PhiltrumWidth) = ("blue", 0.8m); 
            (facialFeatureDevTwo.EyeColor, facialFeatureDevTwo.PhiltrumWidth) = ("brown", 0.85m); 
            (devOne.Email, devOne.FacialFeatures, devOne.NameAndAddress) = ("bert@ex.ism", facialFeatureDevOne, new List<string>{"Bertrand", "Paris", "France"});
            (devTwo.Email, devTwo.FacialFeatures, devTwo.NameAndAddress) = ("anders@ex.ism", facialFeatureDevTwo, new List<string>{"Anders", "Redmond", "USA"});

            return new Dictionary<string, Identity>{{devOne.NameAndAddress[0], devOne}, {devTwo.NameAndAddress[0], devTwo}};
        }
    }
}

//**** please do not modify the FacialFeatures class ****
public class FacialFeatures
{
    public string EyeColor { get; set; }
    public decimal PhiltrumWidth { get; set; }
}

//**** please do not modify the Identity class ****
public class Identity
{
    public string Email { get; set; }
    public FacialFeatures FacialFeatures { get; set; }
    public IList<string> NameAndAddress { get; set; }
}