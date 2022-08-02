using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace dotNetEndpoint.Controllers;

[Route("[controller]")]
public class RegexController : Controller
{
    [Route("find_word")]
    public string findWord()
    {
        string test = "";
        string pattern = @"\b\w+es\b";
        Regex rgx = new Regex(pattern);
        string sentence = "Who writes these notes?";

        foreach (Match match in rgx.Matches(sentence))
            test += string.Format("Found '{0}' at position {1} \n",
                               match.Value, match.Index);
        RevDeBugAPI.Snapshot.RecordSnapshot("find_word");
        return test;
    }
    [Route("email_verification")]
    public string EmailVerification()
    {
        string test = "";
        string emailString = "jack@gmail.com";
        bool isEmail = Regex.IsMatch(emailString, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        if (isEmail == true)
        {
            test = emailString + " is a correct email format";
        }
        else
        {
            test += emailString + " is not a correct email format";
        }
        RevDeBugAPI.Snapshot.RecordSnapshot("email_verification");
        return test;
    }
}
