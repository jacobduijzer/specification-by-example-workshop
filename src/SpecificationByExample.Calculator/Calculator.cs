namespace SpecificationByExample.Calculator;

public class Calculator
{
   private int _value;

    public Calculator Number(int n)
    {
        _value = n;
        return this;
    }

    public Calculator Add(int n)
    {
        _value += n;
        return this;
    }

    public Calculator Subtract(int n)
    {
        _value -= n;
        return this;
    }

    public Calculator MultiplyBy(int n)
    {
        _value *= n;
        return this;
    }

    public Calculator DivideBy(int n)
    {
        if (n == 0) throw new DivideByZeroException();
        _value /= n;
        return this;
    }

    public int Equals() => _value; 
}