using System;

namespace Softplan.Domain.Entities
{
    public abstract class BaseEntity : IEquatable<BaseEntity>
    {
        public BaseEntity()
        {
        }

        public int Id { get; protected set; }
      
        public bool Equals(BaseEntity other)
        {
            return Id == other.Id;
        }
    }
}