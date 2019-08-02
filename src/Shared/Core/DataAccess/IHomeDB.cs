using MongoDB.Driver;
using Nina.DTO;

namespace Nina.DataAccess
{
    public interface IHomeDB
    {
        IMongoCollection<ContactMessageDTO> ContactMessages { get; }
        IMongoCollection<TestimonialMessageDTO> TestimonialMessages { get; }
        IMongoCollection<ClassScheduleMessageDTO> ClassScheduleMessages { get; }
    }
}
