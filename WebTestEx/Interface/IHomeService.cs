using WebTestEx.Models.Data;

namespace WebTestEx.Interface
{
    public interface IHomeService
    {
        Task<List<Student>> Student();
    }
}
