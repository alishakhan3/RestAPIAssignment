namespace APIAssignment.Models
{
    public static class IInterestRepository
    {
        public static List<Interests> Interest {  get; set; } = new List<Interests>() 
        {
                new Interests
                {
                    Id = 1,
                    Name = "Alisha",
                    Interest = "Reading"
                }
        };
    }
}
