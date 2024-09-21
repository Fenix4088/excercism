using Exercism.BethanyShop.Enteties;

namespace Exercism.BethanyShop;

public class BethanyMain
{
    public void Init()
    {

        Employee bethany = new ("Bethany", "Smith", "bethany@snowball.be", new DateTime(1979, 1, 16), 25);
        Manager marry = new("Marry", "O'Connolly", "marry@snowball.be", new DateTime(1990, 1, 16), 30);Researcher carl = new ("Carl", "Spencer", "bob@snowball.be", new DateTime(1988, 7, 16), 17);
        JuniorResearcher bobJunior = new ("Bob", "Spencer", "bob@snowball.be", new DateTime(1988, 7, 16), 17);
        
        Employee jake = new ("Bob", "Spencer", "bob@snowball.be", new DateTime(1988, 7, 16), 17, "New street", "123", "123456", "Pie Ville");
        
        bethany.GiveBonus();
        marry.GiveBonus();

    }
    
}
