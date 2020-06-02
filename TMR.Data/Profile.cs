using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMR.Data
{
    public enum Pictures {  Angler ,  Arms_Dealer ,  Clothier ,  Cyborg , Demolitionist ,  Dryad , Dye_Trader , Goblin_Tinkerer , Golfer , Guide , Mechanic , Merchant , Nurse , Old_Man , Painter , Party_Girl , Pirate , Skeleton_Merchant , Steampunker , Stylist , Tavernkeep , Tax_Collector ,  Traveling_Merchant , Truffle , Witch_Doctor , Wizard , Zoologist }

    public class Profile
    {

        [Key] public Guid UserID { get; set; }
        public Pictures Picture { get; set; }
        public string UserName { get; set; }
        public string BIO { get; set; }

        //could have, due to foreign key relationship:
        // ICollection of Posts
        // ICollection of Replies
    }
}
