using MongoDB.Driver;
using Nina.DTO;
using Nina.Queries;
using SyncSoft.App.Components;
using SyncSoft.ECP.DTOs;
using System;
using System.Threading.Tasks;

namespace Nina.DataAccess.ContactMessage
{
    public class ContactMessageDAL : IContactMessageDAL
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

        public Task<string> InsertMessageAsync(ContactMessageDTO dto) => DB.ContactMessages.TryInsertOneAsync(dto);

        public Task<string> DeleteMessageAsync(Guid id) => DB.ContactMessages.TryDeleteOneAsync(x => x.ID == id);

        public Task<ContactMessageDTO> GetMessageAsync(Guid id) => DB.ContactMessages.TryFindAndGetOneAsync(x => x.ID == id);

        public async Task<PagedList<ContactMessageDTO>> GetMessagesAsync(GetContactMessageQuery query)
        {
            // 搜索
            var filter = Builders<ContactMessageDTO>.Filter.Empty;
            if (query.Name.IsPresent())
            {
                var nameFilter = Builders<ContactMessageDTO>.Filter.Regex(x => x.Name, query.Name);
                filter = Builders<ContactMessageDTO>.Filter.And(filter, nameFilter);
            }
            if (query.Email.IsPresent())
            {
                var emailFilter = Builders<ContactMessageDTO>.Filter.Regex(x => x.Email, query.Email);
                filter = Builders<ContactMessageDTO>.Filter.And(filter, emailFilter);
            }

            //// 排序
            //if (query.OrderBy == 0)
            //{
            //    if (query.SortDirection == "asc")
            //    {
            //        fluent.SortBy(x => x.Name);
            //    }
            //    else if (query.SortDirection == "desc")
            //    {
            //        fluent.SortByDescending(x => x.Name);
            //    }
            //}
            //else if (query.OrderBy == 2)
            //{
            //    if (query.SortDirection == "asc")
            //    {
            //        fluent.SortBy(x => x.CreatedOnUtc);
            //    }
            //    else if (query.SortDirection == "desc")
            //    {
            //        fluent.SortByDescending(x => x.CreatedOnUtc);
            //    }
            //}

            // 输出数据
            var fluent = DB.ContactMessages.Find(filter);
            var total = await fluent.CountDocumentsAsync().ConfigureAwait(false);
            var list = await fluent
                .SortByDescending(x => x.Name)
                .Skip((query.PageIndex - 1) * query.PageSize)
                .Limit(query.PageSize)
                .TryToListAsync<ContactMessageDTO>().ConfigureAwait(false);

            return new PagedList<ContactMessageDTO>(total, query.PageSize, list);
        }

        #endregion
    }
}
