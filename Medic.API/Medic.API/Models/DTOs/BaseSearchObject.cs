namespace Medic.API.Models.DTOs
{
    public class BaseSearchObject
    {
        private int page = 1; 
        private int pageSize = 10; 

        public int Page
        {
            get => page;
            set => page = value < 1 ? 1 : value;
        }

        public int PageSize
        {
            get => pageSize;
            set => pageSize = value < 1 ? 5 : value;
        }
    }

}
