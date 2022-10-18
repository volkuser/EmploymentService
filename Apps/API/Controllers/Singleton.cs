using API.Models;

namespace API.Controllers;

public class Singleton
{
    private static ApplicationContext? _instance;
    
    public static ApplicationContext GetInstance() 
        => _instance ??= new ApplicationContext();
}