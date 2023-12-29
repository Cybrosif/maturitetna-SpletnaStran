using System.ComponentModel.DataAnnotations.Schema;

namespace maturitetna_NovaTestnaStran.Models
{
    public class UserDomainEntity
    {
        public int Id { get; set; }


        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }


        [ForeignKey("Domain")]
        public int DomainId { get; set; }
        public DomainEntity Domain { get; set; }
    }
}
