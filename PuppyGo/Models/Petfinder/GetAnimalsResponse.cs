using System.Collections.Generic;

namespace PuppyGo.Models.Petfinder
{

    public class GetAnimalsResponse
    {

        public List<Animal> Animals { get; set; }

        public Pagination pagination { get; set; }

    }

    public class Pagination
    {
        public int count_per_page { get; set; }
        public int total_count { get; set; }
        public int current_page { get; set; }
        public int total_pages { get; set; }
        public NextPrevLinks _links { get; set; }
    }

    public class NextPrevLinks
    {
        public HrefLink previous { get; set; }
        public HrefLink next { get; set; }
    }

}
