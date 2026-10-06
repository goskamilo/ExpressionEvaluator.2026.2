namespace Backend;

public static class ExpressionEvaluator
{
    public static double Evalute(string infix) => EvalutePostfix(ToPostfix(infix));

    private static string ToPostfix(string infix)
    {
        var posfix = string.Empty;
        var stack = new Stack<char>();

        //se utiliza para acumular los números que se van encontrando en la expresión infija y almacena el número completo antes de agregarlo a la expresión postfija.
        var numero = string.Empty;

        foreach (var item in infix)
        {
            if (IsOperator(item))
            {//Ayuda a separar los números de los operadores, por ejemplo: 2+3*4 se convierte en 2 + 3 * 4
                if (numero.Length > 0)
                {
                    posfix += numero + " ";
                    numero = string.Empty;
                }

                if (item == ')')
                {                   
                    if (stack.Count == 0)
                        throw new Exception("Paréntesis incorrectos.");

                    var ope = stack.Pop();

                    while (ope != '(')
                    {
                        posfix += ope + " ";

                        if (stack.Count == 0)
                            throw new Exception("Paréntesis incorrectos.");

                        ope = stack.Pop();
                    }
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        stack.Push(item);
                    }
                    else
                    {
                        if (PriorityInfix(item) > PriorityStack(stack.Peek()))
                        {
                            stack.Push(item);
                        }
                        else
                        {
                            //se vacía la pila hasta que se encuentre un operador con menor prioridad o hasta que la pila esté vacía, y se agregan los operadores a la expresión postfija.
                            posfix += stack.Pop() + " ";
                            stack.Push(item);
                        }
                    }
                }
            }
            else
            {
                //se toma en cuenta que los números pueden tener más de un dígito y pueden incluir comas o puntos decimales, por lo que se acumulan en la variable "numero" hasta que se encuentra un operador o un espacio.
                if (char.IsDigit(item) || item == ',' || item == '.')
                {
                    numero += item;
                }
                else if (item != ' ')
                {
                    throw new Exception("Carácter no válido.");
                }
            }
        }     
        if (numero.Length > 0)
        {
            posfix += numero + " ";
        }
        while (stack.Count != 0)
        {
            var operador = stack.Pop();
            //si se encuentra un paréntesis de apertura en la pila, significa que hay un error en la expresión infija, por lo que se lanza una excepción.
            if (operador == '(')
                throw new Exception("Paréntesis incorrectos.");

            posfix += operador + " ";
        }

        return posfix.Trim();
    }

    private static int PriorityStack(char op) => op switch
    {
        '^' => 3,
        '*' => 2,
        '/' => 2,
        '+' => 1,
        '-' => 1,
        '(' => 0,
        _ => throw new Exception("Invalid expression."),
    };

    private static int PriorityInfix(char op) => op switch
    {
        '^' => 4,
        '*' => 2,
        '/' => 2,
        '+' => 1,
        '-' => 1,
        '(' => 5,
        _ => throw new Exception("Invalid expression."),
    };

    private static bool IsOperator(char item) =>
        item == '^' ||
        item == '*' ||
        item == '/' ||
        item == '+' ||
        item == '-' ||
        item == '(' ||
        item == ')';

    private static double EvalutePostfix(string postfix)
    {
        var stack = new Stack<double>();
        //separa los valores y operadores en la expresión postfija utilizando el espacio como delimitador, y elimina cualquier entrada vacía que pueda haber quedado después de la división.
        var elementos = postfix.Split(
            ' ',
            StringSplitOptions.RemoveEmptyEntries
        );

        foreach (var elemento in elementos)
        {// se verifica si el elemento es un operador o un número. Si es un operador, se realizan las operaciones correspondientes utilizando los dos últimos números en la pila. Si es un número, se convierte a double y se agrega a la pila.
            if (elemento.Length == 1 && IsOperator(elemento[0]))
            {
                // Se requieren dos números para realizar una operación.
                if (stack.Count < 2)
                    throw new Exception("Expresión incorrecta.");

                var ope2 = stack.Pop();
                var ope1 = stack.Pop();

                stack.Push(Calculate(ope1, ope2, elemento[0]));
            }
            else
            {   //se reemplaza la coma por un punto para que el número pueda ser convertido a double correctamente, ya que en algunos países se utiliza la coma como separador decimal.
                string numero = elemento.Replace(',', '.');
                //se pasa directamente a un double sin usar el char.IsDigit, ya que el número puede contener un punto decimal y no se consideraría un dígito. Además, se utiliza la cultura invariante para que el punto decimal sea reconocido correctamente.
                if (double.TryParse(
                    numero,
                    System.Globalization.NumberStyles.Float,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out double valor))
                {
                    stack.Push(valor);
                }
                else
                {
                    throw new Exception("Número no válido.");
                }
            }
        }

        if (stack.Count != 1)
            throw new Exception("Expresión incorrecta.");

        return stack.Pop();
    }

    private static double Calculate(
        double ope1,
        double ope2,
        char item) => item switch
        {
            '*' => ope1 * ope2,
            '/' => ope1 / ope2,
            '+' => ope1 + ope2,
            '-' => ope1 - ope2,
            '^' => Math.Pow(ope1, ope2),

            _ => throw new Exception("Invalid expression."),
        };
}