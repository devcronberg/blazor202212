namespace MyBogus
{
    using Bogus;

    public class Person
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserLevel { get; set; }
        public string EMail { get; set; }
        public string Username { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool VipUser { get; set; }

        public static List<Person> GetBokusPeople(int count = 10, int? seed = null)
        {
            var l = new List<Person>();
            for (int i = 0; i < count; i++)
                l.Add(Person.GetBokusPerson(seed));
            return l;
        }

        public static Person GetBokusPerson(int? seed = null)
        {
            if (seed != null)
                Randomizer.Seed = new Random(seed.Value);

            var person = new Faker<Person>()
                .RuleFor(i => i.FirstName, f => f.Person.FirstName)
                .RuleFor(i => i.LastName, f => f.Person.LastName)
                .RuleFor(i => i.Id, f => Guid.NewGuid().ToString())
                .RuleFor(i => i.UserLevel, f => f.Random.Int(1, 1000))
                .RuleFor(i => i.EMail, f => f.Person.Email)
                .RuleFor(i => i.Username, f => f.Person.UserName)
                .RuleFor(i => i.DateOfBirth, f => f.Person.DateOfBirth)
                .RuleFor(i => i.VipUser, f => f.Random.Bool());
            return person;
        }
    }
}