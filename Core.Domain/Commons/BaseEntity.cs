namespace Core.Domain.Commons
{
    public abstract class BaseEntity
    {
        public virtual DateTime DateCreated { get; set; } 
        public virtual Guid? CreatedBy { get; set; }

        public virtual DateTime? DateUpdated { get; set; }
        public virtual Guid? UpdatedBy { get; set; }

        public virtual DateTime? DateDeleted { get; set; }
        public virtual Guid? DeletedBy { get; set; }

        public BaseEntity()
        {
            DateCreated = DateTime.Now;
        }

    }
}
