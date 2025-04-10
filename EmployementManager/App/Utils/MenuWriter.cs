namespace EmployementManager.App.Utils;

public class MenuWriter
{
    public static void Show(string[] menuItems)
    {
        menuItems.ToList().ForEach(Console.WriteLine);
    }
}