using System.Collections.Generic;

namespace blogsa
{
    public class DataService {
        private  static DataService _instance;
        public static DataService Instance{
            get {
                if(_instance == null)
                {
                    _instance = new DataService();
                }
                return _instance;
            }
        }

        public List<PostModel> Posts {get;set;}
        public List<PageModel> Pages {get;set;}
        
        public DataService()
        {
            Pages = new List<PageModel>();
            Posts = new List<PostModel>();
        }
    }
}