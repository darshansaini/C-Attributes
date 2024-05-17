using System;

// Define a custom attribute
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
public class MyCustomAttribute : Attribute
{
    public string Description { get; }

    public MyCustomAttribute(string description)
    {
        Description = description;
    }
}

// Apply the custom attribute to a class
[MyCustom("This is a sample class.")]
public class MyClass
{
    // Apply the custom attribute to a method
    [MyCustom("This is a sample method.")]
    public void MyMethod()
    {
        Console.WriteLine("Executing MyMethod");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Get the custom attribute applied to MyClass
        var classAttribute = (MyCustomAttribute)Attribute.GetCustomAttribute(typeof(MyClass), typeof(MyCustomAttribute));
        if (classAttribute != null)
        {
            Console.WriteLine($"Description of MyClass: {classAttribute.Description}");
        }

        // Get the custom attribute applied to MyMethod
        var methodInfo = typeof(MyClass).GetMethod("MyMethod");
        var methodAttribute = (MyCustomAttribute)Attribute.GetCustomAttribute(methodInfo, typeof(MyCustomAttribute));
        if (methodAttribute != null)
        {
            Console.WriteLine($"Description of MyMethod: {methodAttribute.Description}");
        }
    }
}
