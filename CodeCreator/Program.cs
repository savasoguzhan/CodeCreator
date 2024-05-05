

using System.Security.Cryptography;
using System.Text;

const string CharSet = "ACDEFGHKLMNPRTXYZ234579";
const int Length = 8;

//Faster Than Random Class and Secure
RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();


/// <summary>
/// Generates a random code using a secure and fast method.
/// </summary>
/// <returns>A randomly generated code string.</returns>
string BuilderCode()
{
    // Generate an array of random bytes.
    byte[] randomBytes = new byte[Length];
    rng.GetBytes(randomBytes);

    // Build the code string using characters from the CharSet.
    StringBuilder code = new StringBuilder();
    foreach (byte b in randomBytes)
    {
        int index = b % CharSet.Length;
        code.Append(CharSet[index]);
    }

    return code.ToString();
}


/// <summary>
/// Checks if a given code string is valid.
/// </summary>
/// <param name="code">The code string to be checked.</param>
/// <returns>True if the code is valid, otherwise false.</returns>
bool CheckCode(string code)
{
    return !string.IsNullOrEmpty(code) && code.Length == Length && IsCodeValid(code);
}


/// <summary>
/// Checks if a given code string consists only of characters from the CharSet.
/// </summary>
/// <param name="code">The code string to be checked.</param>
/// <returns>True if all characters in the code are valid, otherwise false.</returns>
bool IsCodeValid(string code)
{
    return code.All(c => CharSet.Contains(c)) ? true : false;
}
string generatedCode = BuilderCode();

Console.WriteLine($"Code: {generatedCode}\r\n {(CheckCode(generatedCode) ? "Valid code" : "Not Valid code")}");
Console.ReadLine();