using Nina.Api.ContactMessage;
using Nina.DTO;
using NUnit.Framework;
using SyncSoft.App.Components;
using System;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class ContactMessageTests
    {
        private static readonly Lazy<IContactMessageApi> _lazyContactMessageApi = ObjectContainer.LazyResolve<IContactMessageApi>();
        private IContactMessageApi ContactMessageApi => _lazyContactMessageApi.Value;

        internal static ContactMessageDTO newCmd = new ContactMessageDTO
        {
            ID = new Guid("00000000-0000-0000-0000-000000000001"),
            Name = "test_contact_name",
            Phone = "111-222-3333",
            Email = "test_email@sync.co",
            Message = "test_message",
        };

        [Test, Order(1)]
        public async Task Api_ContactMessage_Create()
        {
            var hr = await ContactMessageApi.CreateMessageAsync(newCmd).ConfigureAwait(false);
            var rs = await hr.GetResultAsync().ConfigureAwait(false);

            Assert.IsTrue(hr.IsSuccess);
            Assert.IsNotNull(rs);
        }

        [Test, Order(10)]
        public async Task Api_ContactMessage_Get()
        {
            var hr = await ContactMessageApi.GetMessageAsync(newCmd.ID).ConfigureAwait(false);
            var rs = await hr.GetResultAsync().ConfigureAwait(false);

            Assert.IsTrue(hr.IsSuccess);
            Assert.IsNotNull(rs);
        }

        [Test, Order(100)]
        public async Task Api_ContactMessage_GetPaged()
        {
            var hr = await ContactMessageApi.GetMessagesAsync(new { Name = newCmd.Name }).ConfigureAwait(false);
            var rs = await hr.GetResultAsync().ConfigureAwait(false);

            Assert.IsTrue(hr.IsSuccess);
            Assert.IsTrue(rs.Items.Count > 0);
        }

        [Test, Order(1000)]
        public async Task Api_ContactMessage_Delete()
        {
            var hr = await ContactMessageApi.DeleteMessageAsync(newCmd.ID).ConfigureAwait(false);
            var rs = await hr.GetResultAsync().ConfigureAwait(false);

            Assert.IsTrue(hr.IsSuccess);
            Assert.IsNotNull(rs);
        }
    }
}