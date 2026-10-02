namespace Backend;

public static class ExpressionEvaluator
{
    public static double Evalute(string infix) => EvalutePostfix(ToPostfix(infix));

    private static string ToPostfix(string infix)
    {
        var posfix = string.Empty;
        var stack = new Stack<char>();

        // CAMBIO:
        // Variable para guardar números de varios dígitos y decimales.
        // Ejemplo: en vez de procesar 12,5 como '1', '2', ',', '5',
        // ahora se guarda completo como "12,5".
        var numero = string.Empty;

        foreach (var item in infix)
        {
            if (IsOperator(item))
            {
                // CAMBIO:
                // Si antes del operador encontramos un número,
                // agregamos el número completo al postfijo.
                if (numero.Length > 0)
                {
                    posfix += numero + " ";
                    numero = string.Empty;
                }

                if (item == ')')
                {
                    // CAMBIO:
                    // Se verifica que la pila tenga elementos
                    // para evitar errores con paréntesis incorrectos.
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
                            // CAMBIO:
                            // Se agrega un espacio después del operador
                            // para separar correctamente los elementos
                            // de la expresión postfija.
                            posfix += stack.Pop() + " ";
                            stack.Push(item);
                        }
                    }
                }
            }
            else
            {
                // CAMBIO:
                // Ahora los caracteres numéricos se acumulan.
                // Esto permite números como:
                // 2
                // 25
                // 125
                // 12,5
                // 100,75

                // También permitimos punto o coma decimal.
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

        // CAMBIO:
        // Si la expresión termina en un número,
        // debemos agregarlo al postfijo antes de vaciar la pila.
        if (numero.Length > 0)
        {
            posfix += numero + " ";
        }

        // CAMBIO:
        // Se reemplaza el do-while original por while.
        // El do-while hacía Pop() incluso cuando la pila estaba vacía.
        while (stack.Count != 0)
        {
            var operador = stack.Pop();

            // Si queda un "(" significa que los paréntesis
            // de la expresión estaban incorrectos.
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

        // CAMBIO:
        // Antes se recorría:
        //
        // foreach (var item in postfix)
        //
        // Eso procesa carácter por carácter.
        //
        // Ahora utilizamos Split(' ') para procesar cada número
        // completo.
        //
        // Por ejemplo:
        // "12 5 +" produce:
        // "12"
        // "5"
        // "+"
        var elementos = postfix.Split(
            ' ',
            StringSplitOptions.RemoveEmptyEntries
        );

        foreach (var elemento in elementos)
        {
            // Si solamente tenemos un carácter y ese carácter
            // es un operador, realizamos la operación.
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
            {
                // CAMBIO IMPORTANTE:
                // Reemplazamos la coma por punto antes de convertir.
                //
                // Ejemplo:
                // "12,5" -> "12.5"
                string numero = elemento.Replace(',', '.');

                // CAMBIO:
                // Ya no utilizamos:
                //
                // char.GetNumericValue(item)
                //
                // porque solamente puede trabajar con un carácter.
                //
                // Ahora convertimos el número completo a double.
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

        // Al finalizar solamente debe existir
        // un resultado en la pila.
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