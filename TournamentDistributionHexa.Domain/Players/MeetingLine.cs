using System.Diagnostics;

namespace TournamentDistributionHexa.Domain.Players
{
    [DebuggerDisplay("{DebugText}")]
    public class MeetingLine
    {
        private int[] _meetingsValue;
        public MeetingLine(int playerCount)
        {
            _meetingsValue = new int[playerCount];
        }
        public int GetMeetingsNumber(int playerB)
        {
            return _meetingsValue[playerB];
        }
        public void IncrementMeetingsNumber(int playerB)
        {
            _meetingsValue[playerB]++;
        }
        public int GetMeetingsMaximumNumber(int currentPlayer, List<int> teamMembers)
        {
            int currentMaximumValue = int.MinValue;
            for (int i = 0; i < _meetingsValue.Count(); i++)
            {
                if (teamMembers.Contains(i))
                {
                    int maximum = _meetingsValue[i];
                    if (currentMaximumValue < maximum && currentPlayer != i)
                    {
                        currentMaximumValue = maximum;
                    }
                }
            }
            return currentMaximumValue;
        }
        private string DebugText
        {
            get
            {
                string result = string.Empty;
                for (int j = 0; j < _meetingsValue.Length; j++)
                {
                    result += $"{j}  [{_meetingsValue[j],2}]  ";
                }

                return result;
            }
        }
    }
}
