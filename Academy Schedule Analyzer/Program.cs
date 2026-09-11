using System;
using System.Text;

string[] sessionNames =
{
    "C# Basics",
    "Arrays",
    "Functions",
    "Date and Time",
    "Exception Handling"
};

DateTime[] sessionDates =
{
    new DateTime(2026, 9, 10, 18, 0, 0),
    new DateTime(2026, 9, 13, 18, 0, 0),
    new DateTime(2026, 9, 17, 18, 0, 0),
    new DateTime(2026, 9, 20, 18, 0, 0),
    new DateTime(2026, 9, 24, 18, 0, 0)
};

int[] sessionDurations =
{
    180,
    240,
    180,
    240,
    180
};

RunApplicationMenu(
    sessionNames,
    sessionDates,
    sessionDurations
);

void RunApplicationMenu(string[] names , DateTime[] dates , int[] durations)
{
    int option;

    do
    {
        DisplayMenu();

        option = ReadMenuOption();

        Console.WriteLine();

        switch (option)
        {
            case 1:
                DisplaySessions(names , dates , durations);
                break;

            case 2:
                SearchSession(names , dates , durations);
                break;

            case 3:
                SortSessionNames(names);
                break;

            case 4:
                ReverseSessionNames(names);
                break;

            case 5:
                FindSessionIndex(names);
                break;

            case 6:
                CheckSessionExists(names);
                break;

            case 7:
                DisplayDurationStatistics(durations);
                break;

            case 8:
                ShowSessionDateDetails(names , dates , durations);
                break;

            case 9:
                DisplayPastAndUpcomingSessions(names , dates);
                break;

            case 10:
                FindNextSession(names , dates , durations);
                break;

            case 11:
                CompareTwoSessionDates(names , dates);
                break;

            case 12:
                ReadSessionDate();
                break;

            case 13:
                SelectSessionByIndex(names , dates , durations);
                break;

            case 14:
                ValidateSessionDuration();
                break;

            case 15:
                Console.WriteLine(BuildReportUsingString(names , dates , durations));
                break;

            case 16:
                Console.WriteLine(BuildReportUsingStringBuilder(names , dates , durations));
                break;

            case 17:
                RunRefDemo();
                break;

            case 18:
                RunOutDemo(names , durations);
                break;

            case 19:
                RunReferenceTypeDemo(names);
                break;

            case 20:
                RunParamsDemo();
                break;

            case 21:
                RunArrayCopyDemo(names);
                break;
            case 22:
                FindSessionUsingFind(names);
                break;

            case 23:
                FindSessionIndexUsingCondition(names);
                break;

            case 0:
                Console.WriteLine("Goodbye!");
                break;

            default:
                Console.WriteLine("Invalid option.");
                break;
        }

        if (option != 0)
        {
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

    } while (option != 0);
}


# region DISPLAY SESSIONS
    void DisplaySessions(string[] names , DateTime[] dates , int[] durations)
    {
        for (int i = 0; i < names.Length; i++)
        {
            DisplaySessionDetails(names[i] , dates[i] , durations[i]);
        }
    }
    // DISPLAY SESSION DETAILS
    void DisplaySessionDetails(string name , DateTime date , int duration)
    {
        Console.WriteLine($"{Array.IndexOf(sessionNames,name) + 1}. {name}");

        Console.WriteLine($"Date: {date:dd MMMM yyyy}");

        Console.WriteLine($"Start Time: {date:hh:mm tt}");

        Console.WriteLine($"Duration: {duration} minutes\n");
    }
#endregion


#region SEARCH SESSION
    void SearchSession(string[] names , DateTime[] dates , int[] durations)
    {
        Console.Write("Enter session name: ");
        string searchName = Console.ReadLine() ?? "";

        int index = Array.IndexOf(names, searchName);

        if (index >= 0)
        {
            Console.WriteLine($"Name: {names[index]}");
            Console.WriteLine($"Date: {dates[index]:dd MMMM yyyy}");
            Console.WriteLine($"Start Time: {dates[index]:hh:mm tt}");
            Console.WriteLine($"Duration: {durations[index]} minutes");
        }
        else
        {
            Console.WriteLine("Session not found.");
        }
    }
#endregion

#region Array Methods Practice

    #region PART 4.1 - SORT
        void SortSessionNames(string[] names)
        {
            string[] copy = new string[names.Length];

            Array.Copy(names, copy, names.Length);

            Array.Sort(copy);

            Console.WriteLine("Sorted session names:");

            foreach (string name in copy)
            {
                Console.WriteLine(name);
            }
        }
    #endregion

    #region PART 4.2 - REVERSE
        void ReverseSessionNames(string[] names)
        {
            string[] copy = new string[names.Length];

            Array.Copy(names, copy, names.Length);

            Array.Reverse(copy);

            Console.WriteLine("Reversed session names:");

            foreach (string name in copy)
            {
                Console.WriteLine(name);
            }
        }
    #endregion

    #region PART 4.3 - FIND INDEX
        void FindSessionIndex(string[] names)
        {
            Console.Write("Enter session name: ");
            string searchName = Console.ReadLine() ?? "";

            int index = Array.IndexOf(names, searchName);

            Console.WriteLine($"Index: {index}");
        }
    #endregion

    #region PART 4.4 - EXISTS
        void CheckSessionExists(string[] names)
        {
            Console.Write("Enter session name: ");
            string searchName = Console.ReadLine() ?? "";

            bool exists = Array.Exists(names , name => name.Equals(searchName , StringComparison.OrdinalIgnoreCase));

            if (exists)
            {
                Console.WriteLine("Session exists.");
            }
            else
            {
                Console.WriteLine("Session does not exist.");
            }
        }
    #endregion

    #region PART 4.5 - FIND
        void FindSessionUsingFind(string[] names)
        {
            string result = Array.Find(names , name => name.Contains("Date"));

            Console.WriteLine($"Found session: {result}");
        }
    #endregion

    #region PART 4.6 - FIND INDEX
        void FindSessionIndexUsingCondition(string[] names)
        {
            int index = Array.FindIndex(names , name => name.Contains("Exception"));

            Console.WriteLine($"Index using condition: {index}");
        }
    #endregion

    #region PART 4.7 - ARRAY COPY
        void RunArrayCopyDemo(string[] names)
        {
            string[] copy = new string[names.Length];

            Array.Copy(names , copy , names.Length);

            Console.WriteLine("Original array:");

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }

            copy[0] = "Changed Session";

            Console.WriteLine();
            Console.WriteLine("Copied array after modification:");

            foreach (string name in copy)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine();
            Console.WriteLine("Original array remains:");

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
    #endregion

#endregion

#region DURATION STATISTICS
    int GetTotalDuration(int[] durations)
    {
        int total = 0;

        for (int i = 0; i < durations.Length; i++)
        {
            total += durations[i];
        }

        return total;
    }

    double GetAverageDuration(int[] durations)
    {
        int total = GetTotalDuration(durations);

        return (double)total / durations.Length;
    }

    int GetShortestDuration(int[] durations)
    {
        int shortest = durations[0];

        for (int i = 1; i < durations.Length; i++)
        {
            if (durations[i] < shortest)
            {
                shortest = durations[i];
            }
        }

        return shortest;
    }

    int GetLongestDuration(int[] durations)
    {
        int longest = durations[0];

        for (int i = 1; i < durations.Length; i++)
        {
            if (durations[i] > longest)
            {
                longest = durations[i];
            }
        }

        return longest;
    }

    void DisplayDurationStatistics(int[] durations)
    {
        Console.WriteLine($"Total Duration: {GetTotalDuration(durations)} minutes");

        Console.WriteLine($"Average Duration: {GetAverageDuration(durations)} minutes");

        Console.WriteLine($"Shortest Duration: {GetShortestDuration(durations)} minutes");

        Console.WriteLine($"Longest Duration: {GetLongestDuration(durations)} minutes");

        int[] sorted = new int[durations.Length];

        Array.Copy(durations, sorted, durations.Length);

        Array.Sort(sorted);

        Console.WriteLine();
        Console.WriteLine("Sorted durations:");

        foreach (int duration in sorted)
        {
            Console.WriteLine(duration);
        }
    }
#endregion

#region GET SESSION END TIME
    DateTime GetSessionEndTime(
        DateTime startTime,
        int duration)
    {
        return startTime.AddMinutes(duration);
    }
#endregion

#region ref, out, and Reference-Type Parameters

    #region  PART 7.1 - REF
        void AddMinutesUsingRef(ref int minutes)
        {
            minutes += 30;
        }

        void RunRefDemo()
        {
            int duration = 180;

            Console.WriteLine(
                $"Before: {duration}");

            AddMinutesUsingRef(ref duration);

            Console.WriteLine(
                $"After: {duration}");
        }
    #endregion

    #region  PART 7.2 - OUT
        bool TryGetSessionInfo(string name , string[] names , int[] durations , out int index , out int duration)
        {
            index = Array.IndexOf(names, name);

            if (index >= 0)
            {
                duration = durations[index];
                return true;
            }

            duration = 0;
            return false;
        }

        void RunOutDemo(string[] names , int[] durations)
        {
            Console.Write("Enter session: ");

            string name = Console.ReadLine() ?? "";

            if (TryGetSessionInfo(name , names , durations , out int index , out int duration))
            {
                Console.WriteLine($"Index: {index}");
                Console.WriteLine($"Duration: {duration} minutes");
            }
            else
            {
                Console.WriteLine("Session not found.");
            }
        }
    #endregion

    #region  PART 7.3 - REFERENCE TYPE WITHOUT REF
        void ChangeFirstSession(string[] names)
        {
            names[0] = "Modified Session";
        }


        void RunReferenceTypeDemo(string[] names)
        {
            Console.WriteLine($"Before: {names[0]}");

            ChangeFirstSession(names);

            Console.WriteLine($"After: {names[0]}");
        }
    #endregion

#endregion

#region PARAMS
    int CalculateTotalDuration(params int[] durations)
    {
        int total = 0;

        foreach (int duration in durations)
        {
            total += duration;
        }

        return total;
    }

    void RunParamsDemo()
    {
        Console.WriteLine($"2 values: {CalculateTotalDuration(120 , 180)}");

        Console.WriteLine($"3 values: {CalculateTotalDuration(120 , 180 , 240)}");

        Console.WriteLine($"5 values: {CalculateTotalDuration(60 , 90 , 120 , 180 , 240)}");
    }
#endregion

#region DATE DETAILS
    void ShowSessionDateDetails(string[] names , DateTime[] dates , int[] durations)
    {
        Console.Write("Enter session name: ");

        string name = Console.ReadLine() ?? "";

        int index = Array.IndexOf(names, name);

        if (index == -1)
        {
            Console.WriteLine("Session not found.");
            return;
        }

        DateTime date = dates[index];

        DateTime endTime = GetSessionEndTime(date , durations[index]);

        Console.WriteLine($"Session: {names[index]}");
        Console.WriteLine($"Date: {date:dd MMMM yyyy}");
        Console.WriteLine($"Day: {date.DayOfWeek}");
        Console.WriteLine($"Year: {date.Year}");
        Console.WriteLine($"Month: {date.Month}");
        Console.WriteLine($"Day Number: {date.Day}");
        Console.WriteLine($"Start Time: {date:hh:mm tt}");
        Console.WriteLine($"Duration: {durations[index]} minutes");
        Console.WriteLine($"End Time: {endTime:hh:mm tt}");
    }
#endregion

#region DATE DIFFERENCE
    void CompareTwoSessionDates(string[] names , DateTime[] dates)
    {
        Console.Write("First session: ");
        string firstName = Console.ReadLine() ?? "";

        Console.Write("Second session: ");
        string secondName = Console.ReadLine() ?? "";

        int firstIndex = Array.IndexOf(names, firstName);
        int secondIndex = Array.IndexOf(names, secondName);

        if (firstIndex == -1 || secondIndex == -1)
        {
            Console.WriteLine("One or both sessions were not found.");
            return;
        }

        TimeSpan difference =dates[secondIndex] - dates[firstIndex];

        Console.WriteLine($"Total days: {difference.TotalDays}");

        Console.WriteLine($"Total hours: {difference.TotalHours}");
    }
#endregion

#region  PAST / UPCOMING
    void DisplayPastAndUpcomingSessions(string[] names , DateTime[] dates)
    {
        DateTime now = DateTime.Now;

        for (int i = 0; i < names.Length; i++)
        {
            if (dates[i] < now)
            {
                Console.WriteLine($"{names[i]} - Past");
            }
            else
            {
                Console.WriteLine($"{names[i]} - Upcoming");
            }
        }
    }
#endregion

#region NEXT SESSION
    void FindNextSession(string[] names , DateTime[] dates , int[] durations)
    {
        DateTime now = DateTime.Now;

        int nextIndex = -1;
        DateTime nearestDate = DateTime.MaxValue;

        for (int i = 0; i < dates.Length; i++)
        {
            if (dates[i] > now && dates[i] < nearestDate)
            {
                nearestDate = dates[i];
                nextIndex = i;
            }
        }

        if (nextIndex == -1)
        {
            Console.WriteLine("No upcoming sessions.");
            return;
        }

        TimeSpan remaining = dates[nextIndex] - now;

        Console.WriteLine("Next Session:");
        Console.WriteLine(names[nextIndex]);
        Console.WriteLine($"{dates[nextIndex]:dd MMMM yyyy}");
        Console.WriteLine($"{dates[nextIndex]:hh:mm tt}");

        Console.WriteLine($"Remaining days: {remaining.Days}");

        Console.WriteLine($"Remaining hours: {remaining.Hours}");
    }
#endregion

#region DATE FORMATTING
    void DisplayDateFormats(DateTime date)
    {
        Console.WriteLine(date.ToString("yyyy-MM-dd"));

        Console.WriteLine(date.ToString("dd/MM/yyyy"));

        Console.WriteLine(date.ToString("dd MMMM yyyy"));

        Console.WriteLine(date.ToString("dddd, dd MMMM yyyy"));

        Console.WriteLine(date.ToString("hh:mm tt"));
    }
#endregion

#region READ AND VALIDATE DATE
    DateTime ReadSessionDate()
    {
        while (true)
        {
            Console.Write("Enter date (yyyy-MM-dd HH:mm): ");

            string input = Console.ReadLine() ?? "";

            if (DateTime.TryParseExact(input , "yyyy-MM-dd HH:mm" , null , System.Globalization.DateTimeStyles.None , out DateTime result))
            {
                Console.WriteLine($"Valid date: {result}");
                return result;
            }

            Console.WriteLine("Invalid date. Please try again.");
        }
    }
#endregion

#region MENU INPUT USING PARSE
    int ReadMenuOption()
    {
        while (true)
        {
            Console.Write("Choose an option: ");

            try
            {
                string input = Console.ReadLine() ?? "";

                int option = int.Parse(input);

                return option;
            }
            catch (FormatException)
            {
                Console.WriteLine(
                    "Invalid menu option. Enter a number.");
            }
        }
    }
#endregion

#region INVALID ARRAY INDEX
    void SelectSessionByIndex(string[] names , DateTime[] dates , int[] durations)
    {
        Console.Write("Enter session index: ");

        int index = int.Parse(Console.ReadLine() ?? "");

        try
        {
            Console.WriteLine($"Session: {names[index]}");

            Console.WriteLine($"Date: {dates[index]:dd MMMM yyyy}");

            Console.WriteLine($"Duration: {durations[index]} minutes");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("The selected session index is out of range.");
        }
    }
#endregion

#region THROW _ Finally
    void ValidateDuration(int duration)
    {
        if (duration <= 0)
        {
            throw new ArgumentException("Duration must be greater than zero.");
        }

        Console.WriteLine("Duration accepted.");
    }

    void ValidateSessionDuration()
    {
        Console.Write("Enter duration: ");

        try
        {
            int duration = int.Parse(Console.ReadLine() ?? "");

            ValidateDuration(duration);
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter a valid number.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("Input operation finished.");
        }
    }
#endregion

#region STRING CONCATENATION
    string BuildReportUsingString(string[] names , DateTime[] dates , int[] durations)
    {
        string result = "";

        for (int i = 0; i < names.Length; i++)
        {
            result +=$"{names[i]} - " + $"{dates[i]:dd/MM/yyyy hh:mm tt} - " + $"{durations[i]} minutes";
            result += Environment.NewLine;
        }

        return result;
    }
#endregion

#region STRINGBUILDER
    string BuildReportUsingStringBuilder(string[] names , DateTime[] dates , int[] durations)
    {
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < names.Length; i++)
        {
            result.Append(names[i]);
            result.Append(" - ");
            result.Append(dates[i].ToString("dd/MM/yyyy hh:mm tt"));
            result.Append(" - ");
            result.Append(durations[i]);
            result.Append(" minutes");
            result.AppendLine();
        }

        return result.ToString();
    }
#endregion

#region MENU
void DisplayMenu()
{
    Console.WriteLine("===================================");
    Console.WriteLine("     Academy Schedule Analyzer");
    Console.WriteLine("===================================");

    Console.WriteLine("1. Display all sessions");
    Console.WriteLine("2. Search for a session");
    Console.WriteLine("3. Sort session names");
    Console.WriteLine("4. Reverse session names");
    Console.WriteLine("5. Find session index");
    Console.WriteLine("6. Check if session exists");
    Console.WriteLine("7. Show duration statistics");
    Console.WriteLine("8. Show session date details");
    Console.WriteLine("9. Show past and upcoming sessions");
    Console.WriteLine("10. Find next session");
    Console.WriteLine("11. Compare two session dates");
    Console.WriteLine("12. Read and validate a custom date");
    Console.WriteLine("13. Select session by index");
    Console.WriteLine("14. Validate session duration");
    Console.WriteLine("15. Generate report using string");
    Console.WriteLine("16. Generate report using StringBuilder");
    Console.WriteLine("17. ref demonstration");
    Console.WriteLine("18. out demonstration");
    Console.WriteLine("19. Reference type without ref");
    Console.WriteLine("20. params demonstration");
    Console.WriteLine("21. Array.Copy demonstration");
    Console.WriteLine("22. Find session using Array.Find");
    Console.WriteLine("23. Find session index using Array.FindIndex");
    Console.WriteLine("0. Exit");
}
#endregion
