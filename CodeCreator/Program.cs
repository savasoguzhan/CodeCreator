

using System.Security.Cryptography;
using System.Text;

const string CharSet = "ACDEFGHKLMNPRTXYZ234579";
const int Length = 8;

//Faster Than Random Class and Secure
RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

string BuilderCode()
{
    byte[] randomBytes = new byte[Length];
    rng.GetBytes(randomBytes);

    StringBuilder code = new StringBuilder();
    foreach (byte b in randomBytes)
    {
        int index = b % CharSet.Length;
        code.Append(CharSet[index]);
    }

    return code.ToString();
}

bool CheckCode(string code)
{
    return !string.IsNullOrEmpty(code) && code.Length == Length && IsCodeValid(code);
}

bool IsCodeValid(string code)
{
    return code.All(c => CharSet.Contains(c)) ? true : false;
}
string generatedCode = BuilderCode();

Console.WriteLine($"Code: {generatedCode}\r\n {(CheckCode(generatedCode) ? "Valid code" : "Not Valid code")}");
Console.ReadLine();