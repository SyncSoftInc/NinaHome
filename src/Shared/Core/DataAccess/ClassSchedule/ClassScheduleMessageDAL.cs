using MongoDB.Driver;
using Nina.DTO;
using Nina.Queries;
using SyncSoft.App.Components;
using SyncSoft.ECP.DTOs;
using System;
using System.Threading.Tasks;

namespace Nina.DataAccess.ContactMessage
{
    public class ClassScheduleMessageDAL : IClassScheduleMessageDAL
    {
        // *******************************************************************************************************************************
        #region -  Property(ies)  -

        private IHomeDB DB => HomeDBProvider.Get();

        #endregion
        // *******************************************************************************************************************************
        #region -  Lazy Object(s)  -

        private static readonly Lazy<HomeDBProvider> _lazyHomeDBProvider = ObjectContainer.LazyResolve<HomeDBProvider>();
        private HomeDBProvider HomeDBProvider => _lazyHomeDBProvider.Value;

        #endregion
        // *******************************************************************************************************************************
        #region -  CRUD  -

        public Task<string> InsertMessageAsync(ClassScheduleMessageDTO dto)
            => DB.ClassScheduleMessages.TryInsertOneAsync(dto);

        public Task<string> DeleteMessageAsync(Guid id)
            => DB.ClassScheduleMessages.TryDeleteOneAsync(x => x.ID == id);

        public Task<ClassScheduleMessageDTO> GetMessageAsync(Guid id)
            => DB.ClassScheduleMessages.TryFindAndGetOneAsync(x => x.ID == id);

        public async Task<PagedList<ClassScheduleMessageDTO>> GetMessagesAsync(GetClassScheduleMessageQuery query)
        {
            // 搜索
            var filter = Builders<ClassScheduleMessageDTO>.Filter.Empty;
            if (query.Name.IsPresent())
            {
                var nameFilter = Builders<ClassScheduleMessageDTO>.Filter.Regex(x => x.Name, query.Name);
                filter = Builders<ClassScheduleMessageDTO>.Filter.And(filter, nameFilter);
            }
            if (query.Email.IsPresent())
            {
                var emailFilter = Builders<ClassScheduleMessageDTO>.Filter.Regex(x => x.Email, query.Email);
                filter = Builders<ClassScheduleMessageDTO>.Filter.And(filter, emailFilter);
            }

            // 输出数据
            var fluent = DB.ClassScheduleMessages.Find(filter);
            var total = await fluent.CountDocumentsAsync().ConfigureAwait(false);
            var list = await fluent
                .SortByDescending(x => x.Name)
                .Skip((query.PageIndex - 1) * query.PageSize)
                .Limit(query.PageSize)
                .TryToListAsync<ClassScheduleMessageDTO>().ConfigureAwait(false);

            return new PagedList<ClassScheduleMessageDTO>(total, query.PageSize, list);
        }

        #endregion
    }
}
