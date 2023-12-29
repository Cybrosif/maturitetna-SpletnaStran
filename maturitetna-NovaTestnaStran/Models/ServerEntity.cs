using System.ComponentModel.DataAnnotations.Schema;

namespace maturitetna_NovaTestnaStran.Models
{
    public class ServerEntity
    {
        public Guid Id { get; set; }


        [ForeignKey("Domain")]
        public  int DomainId { get; set; }
        public DomainEntity? Domain { get; set; }


        public  string ServerName { get; set; }
    }
}
