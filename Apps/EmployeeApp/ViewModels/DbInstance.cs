using Entities;

namespace EmployeeApp.ViewModels;

public static class DbInstance
{
    private static Db? _instance;
    
    public static Db GetInstance()
    {
        return _instance ??= new Db();
    }
}