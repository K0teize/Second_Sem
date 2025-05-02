namespace AIP_Lab7
{
    public class Dot
    {
        public double x { get; set; }
        public double y { get; set; }
        public Dot(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public delegate void EventDelegate();
    public class EventComplition
    {
        public event EventDelegate Event;

        public void OnEvent()
        {
            if (Event != null)
            {
                Event();
            }
        }

    }
    class Program
    {
        static void Handler()
        {
            Console.WriteLine("Точка вышла за границы заданной области.");
            return;
        }
        static void Main(string[] args)
        {
            int MaxX = 5;
            int MinX = -5;
            int MaxY = 6;
            int MinY = -6;
            Random randomMove = new Random();
            Dot dot = new Dot(0, 0);
            EventComplition eventComplition = new EventComplition();
            eventComplition.Event += Handler;
            for (int i = 0; i < 10; i++)
            {
                dot.x += randomMove.Next(-2, 2);
                dot.y += randomMove.Next(-2, 2);
                Console.WriteLine($"Шаг {i}: {dot.x}, {dot.y}");
                if (dot.x < MinX || dot.x > MaxX || dot.y < MinY || dot.y > MaxY)
                {
                    eventComplition.OnEvent();
                    break;
                }
            }
        }
    }

    class Participant
    {
        public int Pos { get; set; }
        public int Number { get; set; }
        public Participant(int number) 
        {
            Pos = 0;
            Number = number;
        }
    }
    public delegate void EventDelegate2(List<int> winners);

    class EventComplition2
    {
        public event EventDelegate2 Event;
        public void OnEvent1(List<int> winners)
        {
            Event?.Invoke(winners);
        }
    }
    class Program2
    {
        static void Handler2(List<int> winners )
        {
            if(winners.Count == 1)
            {
                Console.WriteLine($"Участник {winners[0]} победил!");
            }
            else
            {
                Console.WriteLine($"Участники {string.Join(", ",winners)} победили!");
            }
            
            Environment.Exit(0);
        }
        static void Main(string[] args)
        {
            EventComplition2 eventComplition2 = new EventComplition2();
            eventComplition2.Event += Handler2;

            int finish = 2000;
            List<Participant> participants = new List<Participant>();
            
            int ParticipantCount = 3;

            for(int i = 1; i <= ParticipantCount; i++)
            {
                participants.Add(new Participant(i));
            }

            Random randomSpeed = new Random();

            while(true)
            {
                List<int> winners = new List<int>();
                for(int i = 0; i < participants.Count; i++)
                {
                    int speed = randomSpeed.Next(30,100);
                    participants[i].Pos += speed;

                    if(participants[i].Pos >= finish)
                    {
                        winners.Add(participants[i].Number);
                    }
                }
                if(winners.Count > 0)
                {
                    eventComplition2.OnEvent1(winners);
                    break;
                }
            }
        }
    }
}