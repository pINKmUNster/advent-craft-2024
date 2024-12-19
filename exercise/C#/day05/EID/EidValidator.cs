namespace EID;

public class EidValidator
{
    private const int ValidLength = 8;

    public static bool Validate(string eid)
    {
        return ValidateLength(eid)
               && ValidateSex(eid)
               && ValidateYear(eid)
               && ValidateSerialNumber(eid)
               && ValidateControlKey(eid);
    }

    private static bool ValidateControlKey(string eid)
    {
        var key = eid[6..8];
        if (key.All(char.IsDigit))
        {
            var inte= int.Parse(key);
            var validKey = 97 - int.Parse(eid[0..6]) % 97;
            return inte == validKey;
        }

        return false;
    }

    private static bool ValidateSerialNumber(string eid)
    {
        var serialNumber = eid[3..6];
        return serialNumber.All(char.IsDigit);
    }

    private static bool ValidateLength(string eid)
    {
        return !string.IsNullOrEmpty(eid) && eid.Length == ValidLength;
    }

    private static bool ValidateYear(string eid)
    {
        var year = eid[1..3];
        return year.All(char.IsDigit);
    }

    private static bool ValidateSex(string eid)
    {
        var allowedSex = new List<int> {1, 2, 3};
        var sex = eid[0];
        return allowedSex.Contains(sex);
    }
}