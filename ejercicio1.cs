Console.Write("Ingrese un número: ");
int numero1, numero2;
if(!Int32.TryParse(Console.ReadLine(), out numero1))
{
    Console.WriteLine("Error, debe ingresar un número correcto");
}
else
{
    Console.Write("Ingrese otro número: ");
    if (!Int32.TryParse(Console.ReadLine(), out numero2))
    {
        Console.WriteLine("Error, debe ingresar un número correcto");
    }
    else
    {
        Console.WriteLine("La suma de los números es: " + (numero1 + numero2));
    }
    
}