using System;
using FluentValidation.Results;

namespace TestXUnit.Business.Model
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
        public ValidationResult ValidationResult { get; protected set; }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
