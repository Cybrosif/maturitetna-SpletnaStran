using System.Reflection.Metadata;

namespace maturitetna_NovaTestnaStran.Models
{
    public class DomainEntity
    {
        public int Id { get; set; }
        public string Domain { get; set; }

        public List<ServerEntity>? Servers { get; set; }
    }
}
