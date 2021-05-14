namespace Monopoly.Models
{
    internal class PlayerInfo
    {
        public static PlayerInfo EmptyPlayer = new PlayerInfo(string.Empty, 0);

        public PlayerInfo(string name, int cash)
        {
            Name = name;
            Cash = cash;
        }

        public string Name { get; }

        public int Cash { get; private set; }

        public void AddCash(int summ) => Cash += summ;

        public void SubtractCash(int sum) => Cash -= sum;

        public override bool Equals(object obj)
        {
            return obj is PlayerInfo other && Equals(other);
        }

        private bool Equals(PlayerInfo other)
        {
            return Name.Equals(other.Name)
                && Cash.Equals(other.Cash);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Cash.GetHashCode();
        }
    }
}
