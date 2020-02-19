using MediatR.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediatR.Logic.Commands
{
    public class RegisterCommand : ICommand
    {
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        
        public RegisterCommand(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Email:{Email}";
        }
    }
}
