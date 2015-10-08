using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class SomeCommandBus
    {
        public void Publish<T>(T command)
            where T :ICommand
        {
            new CommandHandler().Execute(command);
            
        }
    }
}