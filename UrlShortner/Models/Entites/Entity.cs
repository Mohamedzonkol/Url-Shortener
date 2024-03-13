namespace UrlShortner.Models.Entites
{
    public class Entity
    {
        public Guid Id { get; set; } =  Guid.NewGuid();
        public DateTime CreateDateTime { get; set; }=DateTime.Now;
        public DateTime ModifiedDateTime { get; set; }=DateTime.Now;
        public bool Deactivated { get; set; }
    }
}
