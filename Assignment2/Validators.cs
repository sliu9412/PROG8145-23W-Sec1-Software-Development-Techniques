using System.Text.RegularExpressions;

namespace assignment2;

public static class Validors
{
    public static (bool valid, string value) InputValidator(string? str)
    {
        if (String.IsNullOrEmpty(str) || String.IsNullOrEmpty(str))
        {
            return (false, "Invalid input");
        }
        return (true, str);
    }

    public static string YesNoValidator(string? str)
    {
        var validor = InputValidator(str);
        if (validor.Item1 && validor.Item2.ToLower() == "y" || validor.Item2.ToLower() == "yes")
        {
            return "Y";
        }
        else if (validor.Item1 && validor.Item2.ToLower() == "n" || validor.Item2.ToLower() == "no")
        {
            return "N";
        }
        return "";
    }

    public static (bool valid, int value) IntegerValidator(string? str, string? operators)
    {
        var validator = InputValidator(str);
        int tem_int;
        if (validator.valid && int.TryParse(validator.value, out tem_int))
        {
            if (
                (operators == "==" && tem_int == 0) ||
                (operators == ">" && tem_int > 0) ||
                (operators == ">=" && tem_int >= 0) ||
                (operators == "<" && tem_int < 0) ||
                (operators == "<=" && tem_int <= 0)
                )
            {
                return (true, tem_int);
            } else if (operators == "null") {
                return (true, tem_int);
            }
            else
            {
                return (false, tem_int);
            }
        }
        return (false, 0);
    }

    public static (bool valid, double value) DoubleValidator(string? str, string? operators)
    {
        var validator = InputValidator(str);
        double tem_double;
        if (validator.valid && double.TryParse(validator.value, out tem_double))
        {
            if (
                (operators == "==" && tem_double == 0) ||
                (operators == ">" && tem_double > 0) ||
                (operators == ">=" && tem_double >= 0) ||
                (operators == "<" && tem_double < 0) ||
                (operators == "<=" && tem_double <= 0)
                )
            {
                return (true, tem_double);
            }
            else
            {
                return (false, tem_double);
            }
        }
        return (false, 0);
    }

    public static (bool valid, string value) PhoneNumberValidator(string? str) {
        var validator = InputValidator(str);
        var phone_numer_pattern = new Regex(@"^\d{3}-\d{3}-\d{4}$");
        if (validator.valid && phone_numer_pattern.IsMatch(validator.value)) {
            return (true, validator.value);
        }
        return (false, validator.value);
    }

    public static (bool valid, int value) IntegerRangeValidator(string? str, List<int> range) {
        var validator = IntegerValidator(str, "null");
        if (validator.valid && range.IndexOf(validator.value) >= 0) {
            return (true, validator.value);
        }
        return (false, validator.value);
    }
}