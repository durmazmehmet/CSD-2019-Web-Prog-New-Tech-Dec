namespace CSD.Util.Repository
{
    public interface IEntity<ID>
    {
        public ID Id { get; set; }
    }
}