

using Realms.Sync;

namespace FreshVegiesAndMore.Services.Interfaces
{
   public interface IRealmService
    {
       public Realms.Sync.App RealmApp { get; set; }

        Realms.Sync.User RealmUser { get; set; }

        FlexibleSyncConfiguration SyncConfiguration { get; set; }

        Task LoadSyncConfiguration();

        Task LoginAsync();
    }
}
