using NUnit.Framework;
using System;

namespace HumanReadableTime
{
    [TestFixture]
    public class Tests
    {
        [TestCase(0, "now")]
        [TestCase(1, "1 second")]
        [TestCase(62, "1 minute and 2 seconds")]
        [TestCase(120, "2 minutes")]
        [TestCase(3662, "1 hour, 1 minute and 2 seconds")]
        [TestCase(15731080, "182 days, 1 hour, 44 minutes and 40 seconds")]
        [TestCase(132030240, "4 years, 68 days, 3 hours and 4 minutes")]
        [TestCase(205851834, "6 years, 192 days, 13 hours, 3 minutes and 54 seconds")]
        [TestCase(253374061, "8 years, 12 days, 13 hours, 41 minutes and 1 second")]
        [TestCase(242062374, "7 years, 246 days, 15 hours, 32 minutes and 54 seconds")]
        [TestCase(101956166, "3 years, 85 days, 1 hour, 9 minutes and 26 seconds")]
        [TestCase(33243586, "1 year, 19 days, 18 hours, 19 minutes and 46 seconds")]
        [TestCase(8036174, "93 days, 16 minutes and 14 seconds")]
        public void CalculateTime_GivenSeconds_ShouldReturnReadableFormat(int seconds, string expected)
        {
            //Act
            string actual = Get_Readable_Time(seconds);

            //Assert
            Assert.AreEqual(actual, expected);
        }

        private string Get_Readable_Time(int seconds)
        {
            if (seconds == 0)
                return "now";

            var time = TimeSpan.FromSeconds(seconds);
            var years = time.Days / 365;
            var day = time.Days % 365;

            string year = years == 0 ? "" : $"{years} {(years > 1 ? "years" : "year")}";
            string days = day == 0 ? "" : $", {day} {(day > 1 ? "days" : "day")}";
            string hour = time.Hours == 0 ? "" : $", {time.Hours} {(time.Hours > 1 ? "hours" : "hour")}";
            string minute = time.Minutes == 0 ? "" : $", {time.Minutes} {(time.Minutes > 1 ? "minutes" : "minute")}";
            string second = time.Seconds == 0 ? "" : $",{time.Seconds} {(time.Seconds> 1 ? "seconds" : "second")}";

            string result = $"{year}{days}{hour}{minute}{second}";

            if (result.Split(',', StringSplitOptions.RemoveEmptyEntries).Length > 1)
            {
                var indexOfLastComma = result.LastIndexOf(',');
                result = result.Remove(indexOfLastComma, 1).Insert(indexOfLastComma, " and ").Replace("  ", " ");
            }
            
            return result.StartsWith(",") ? result.Remove(0, 1).TrimStart() : result;

            //if (seconds == 1)
            //    return "1 second";

            //if (seconds == 62)
            //    return "1 minute and 2 seconds";

            //return "now";

            //var time = TimeSpan.FromSeconds(seconds);
            //var test = $"{(int)time.TotalHours} Hour, {time.Minutes} minute, {time.Seconds} seconds";
        }

        #region Commented out code
        //[Test]
        //public void CalculateTime_Given1Second_ShouldReturnText()
        //{
        //    //Arrange
        //    int seconds = 1;

        //    //Act
        //    string actual = Get_Readable_Time(seconds);
        //    string expected = "1 second";

        //    //Assert
        //    Assert.AreEqual(actual, expected);
        //}

        //[Test]
        //public void CalculateTime_Given62Seconds_ShouldReturnText()
        //{
        //    //Arrange
        //    int seconds = 62;

        //    //Act
        //    string actual = Get_Readable_Time(seconds);
        //    string expected = "1 minute and 2 seconds";

        //    //Assert
        //    Assert.AreEqual(actual, expected);
        //}

        //[Test]
        //public void CalculateTime_Given120Seconds_ShouldReturnText()
        //{
        //    //Arrange
        //    int seconds = 120;

        //    //Act
        //    string actual = Get_Readable_Time(seconds);
        //    string expected = "2 minutes";

        //    //Assert
        //    Assert.AreEqual(actual, expected);
        //}

        //[Test]
        //public void CalculateTime_Given3662Seconds_ShouldReturnText()
        //{
        //    //Arrange
        //    int seconds = 3662;

        //    //Act
        //    string actual = Get_Readable_Time(seconds);
        //    string expected = "1 hour, 1 minute and 2 seconds";

        //    //Assert
        //    Assert.AreEqual(actual, expected);
        //}

        //[Test]
        //public void CalculateTime_Given15731080Second_ShouldReturnText()
        //{
        //    //Arrange
        //    int seconds = 15731080;

        //    //Act
        //    string actual = Get_Readable_Time(seconds);
        //    string expected = "182 days, 1 hour, 44 minutes and 40 seconds";

        //    //Assert
        //    Assert.AreEqual(actual, expected);
        //} 
        #endregion
    }
}