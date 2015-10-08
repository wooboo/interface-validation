using System;

namespace WebApplication4.Models
{
    public interface ICommand
    {
        
    }
    public class CreateCommand : INameModel, IValueModel, ICommand
    {
        public CreateCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
        public string Name { get; set; }
        public int? Value { get; set; }
    }
    public class EditCommand : INameModel, IValueModel, ICommand
    {
        public EditCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
        public string Name { get; set; }
        public int? Value { get; set; }
    }
}