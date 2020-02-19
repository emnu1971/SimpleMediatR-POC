namespace MediatR.Domain.Entities
{
    public class  Student : Entity
    {
        public virtual string Name { get; protected set; }
        public virtual string Email { get; protected set; }

        protected Student()
        {
        }

        public Student(string name, string email)
            : this()
        {
            Name = name;
            Email = email;
        }
    }
}
