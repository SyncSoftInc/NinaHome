using MongoDB.Driver;
using Nina.DTO;
using SyncSoft.App.MongoDB;

namespace Nina.DataAccess
{
    public class HomeDB : MongoDatabase, IHomeDB
    {
        // *******************************************************************************************************************************
        #region -  Property(ies)  -

        public IMongoCollection<ContactMessageDTO> ContactMessages { get; private set; }
        public IMongoCollection<TestimonialMessageDTO> TestimonialMessages { get; private set; }
        public IMongoCollection<ClassScheduleMessageDTO> ClassScheduleMessages { get; private set; }

        #endregion
        // *******************************************************************************************************************************
        #region -  Constructor(s)  -

        public HomeDB(string connStrOrName) : base(connStrOrName)
        {
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  Init  -

        protected override void Init()
        {
            if (null != DB)
            {
                // Contact Messages
                ContactMessages = DB.GetCollection<ContactMessageDTO>(nameof(ContactMessages));
                // 索引
                ContactMessages.Indexes.CreateOne(new CreateIndexModel<ContactMessageDTO>(Builders<ContactMessageDTO>.IndexKeys.Descending(x => x.CreatedOnUtc)));
                // 唯一键
                ContactMessages.Indexes.CreateOne(new CreateIndexModel<ContactMessageDTO>(Builders<ContactMessageDTO>.IndexKeys.Ascending(x => x.ID), new CreateIndexOptions
                {
                    Unique = true
                }));

                // Testimonial Messages
                TestimonialMessages = DB.GetCollection<TestimonialMessageDTO>(nameof(TestimonialMessages));
                // 索引
                TestimonialMessages.Indexes.CreateOne(new CreateIndexModel<TestimonialMessageDTO>(Builders<TestimonialMessageDTO>.IndexKeys.Descending(x => x.CreatedOnUtc)));
                // 唯一键
                TestimonialMessages.Indexes.CreateOne(new CreateIndexModel<TestimonialMessageDTO>(Builders<TestimonialMessageDTO>.IndexKeys.Ascending(x => x.ID), new CreateIndexOptions
                {
                    Unique = true
                }));

                // Class Schedule Messages
                ClassScheduleMessages = DB.GetCollection<ClassScheduleMessageDTO>(nameof(ClassScheduleMessages));
                // 索引
                ClassScheduleMessages.Indexes.CreateOne(new CreateIndexModel<ClassScheduleMessageDTO>(Builders<ClassScheduleMessageDTO>.IndexKeys.Descending(x => x.CreatedOnUtc)));
                // 唯一键
                ClassScheduleMessages.Indexes.CreateOne(new CreateIndexModel<ClassScheduleMessageDTO>(Builders<ClassScheduleMessageDTO>.IndexKeys.Ascending(x => x.ID), new CreateIndexOptions
                {
                    Unique = true
                }));
            }
        }

        #endregion
    }
}
