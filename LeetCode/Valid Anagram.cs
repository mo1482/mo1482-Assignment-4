public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }

        int[] counts = new int[26];

        for (int i = 0; i < s.Length; i++)
        {
            counts[s[i] - 'a']++;
            counts[t[i] - 'a']--;
        }

        for (int i = 0; i < counts.Length; i++)
        {
            if (counts[i] != 0)
            {
                return false;
            }
        }

        return true;
    }
}
