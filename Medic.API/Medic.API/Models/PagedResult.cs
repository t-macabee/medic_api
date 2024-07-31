namespace Medic.API.Models
{
    public class PagedResult<T>
    {
        public int Count { get; set; }
        public int CurrentPage { get; set; } = 1;
        public List<T> ResultList { get; set; } = new List<T>();
    }
}
