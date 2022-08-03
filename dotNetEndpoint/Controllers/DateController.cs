using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;

namespace dotNetEndpoint.Controllers;

[Route("[controller]")]
public class DateController : Controller
{
    [Route("current_time")]
    public string CurrentTime()
    {
        string test = "";
        DateTime dateTime = DateTime.Now;
        test += dateTime;
        RevDeBugAPI.Snapshot.RecordSnapshot("current_time");
        return test;
    }
    [Route("cultural_info_date_us")]
    public string DateTimeParse()
    {
        var utcDate = DateTime.UtcNow;
        var usCulture = new CultureInfo("en-US");
        string dateString;
        var gmt1Date = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(utcDate, "W. Europe Standard Time");
        dateString = gmt1Date.ToString("ddd, dd MMM yyyy HH:mm:ss z", usCulture);

        RevDeBugAPI.Snapshot.RecordSnapshot("cultural_info_date_us");
        return dateString;
    }
    [Route("cultural_info_date_fiji")]
    public string CulturalInfoDateFiji()
    {
        var utcDate = DateTime.UtcNow;
        var fijiCulture = new CultureInfo("FJ-FJ");
        string dateString;
        var gmt1Date = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(utcDate, "India Standard Time");
        dateString = gmt1Date.ToString("ddd, dd MMM yyyy HH:mm:ss z", fijiCulture);

        RevDeBugAPI.Snapshot.RecordSnapshot("cultural_info_date_fiji");
        return dateString;
    }
    [Route("add_hours")]
    public string addHours()
    {
        string test = "";
        DateTime dateTime = DateTime.Now;
        dateTime = dateTime.AddHours(12);
        test = dateTime.ToString();

        RevDeBugAPI.Snapshot.RecordSnapshot("add_hours");
        return test;
    }
    [Route("add_minutes")]
    public string addMinutes()
    {
        string test = "";
        DateTime dateTime = DateTime.Now;
        dateTime = dateTime.AddMinutes(1200);
        test = dateTime.ToString();

        RevDeBugAPI.Snapshot.RecordSnapshot("add_minutes");
        return test;
    }
    [Route("add_days")]
    public string addDays()
    {
        string test = "";
        DateTime dateTime = DateTime.Now;
        dateTime = dateTime.AddDays(12);
        test = dateTime.ToString();

        RevDeBugAPI.Snapshot.RecordSnapshot("add_days");
        return test;
    }
    [Route("format")]
    public string format()
    {
        string test = "";
        test += DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
        test += "\n";
        test += DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
        test += "\n";
        test += DateTime.Now.ToString("MMMM dd");

        RevDeBugAPI.Snapshot.RecordSnapshot("format");
        return test;
    }
    [Route("compare")]
    public string compare()
    {
        string test = "";
        DateTime dateTimeToday = DateTime.Now;
        DateTime dateTimeTommorow = DateTime.Now.AddDays(1);
        if (dateTimeToday < dateTimeTommorow)
        {
            test += "Tommorow is after today";
        }
        RevDeBugAPI.Snapshot.RecordSnapshot("compare");
        return test;
    }
}
