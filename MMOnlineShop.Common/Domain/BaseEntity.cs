namespace MMOnlineShop.Common.Domain
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? ModificationDate { get; set; }
    }
}
