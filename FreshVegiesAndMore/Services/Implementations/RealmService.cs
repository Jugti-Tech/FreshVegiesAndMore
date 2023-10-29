



using Realms.Sync.ErrorHandling;
using Realms.Sync.Exceptions;

namespace FreshVegiesAndMore.Services.Implementations
{
   public class RealmService : IRealmService
    {

        private string appId;
        private string baseUrl;

        Realms.Sync.App RealmApp { get; set; }

        Realms.Sync.User RealmUser { get; set; }

        FlexibleSyncConfiguration SyncConfiguration { get; set; }

        public RealmService()
        {
            try
            {

            }
            catch (Exception ex)
            {

                
            }
        }


       async Task LoadAppConfiguration()
        {
            try
            {
                using (Stream stream = this.GetType().Assembly.GetManifestResourceStream("FreshVegiesAndMore.realm.json"))
                {
                    using(StreamReader reader= new StreamReader(stream))
                    {
                        var json = reader.ReadToEnd();
                        Dictionary<string, string> parsedJson = JsonSerializer.Deserialize<Dictionary<string,string>>(json);
                        appId = parsedJson["appId"];
                        baseUrl = parsedJson["baseUrl"];
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public async Task LoadSyncConfiguration()
        {
            try
            {
                SyncConfiguration = new FlexibleSyncConfiguration(RealmUser)
                {
                    CancelAsyncOperationsOnNonFatalErrors = true,
                    PopulateInitialSubscriptions = (realm)=>
                    {

                    },

                };

                SyncConfiguration.OnSessionError = (session, sessionException) =>
                {
                    switch (sessionException.ErrorCode)
                    {
                        case ErrorCode.RuntimeError:
                            break;
                        case ErrorCode.ClientReset:
                            break;
                        case ErrorCode.BadChangeset:
                            break;
                        case ErrorCode.ProtocolInvariantFailed:
                            break;
                        case ErrorCode.BadQuery:
                            break;
                        case ErrorCode.CompensatingWrite:
                            break;
                        case ErrorCode.BadPartitionValue:
                            break;
                        case ErrorCode.InvalidSchemaChange:
                            break;
                        case ErrorCode.PermissionDenied:
                            break;
                        case ErrorCode.ServerPermissionsChanged:
                            break;
                        case ErrorCode.UserMismatch:
                            break;
                        case ErrorCode.WriteNotAllowed:
                            break;

                            // See https://www.mongodb.com/docs/realm-sdks/dotnet/latest/reference/Realms.Sync.Exceptions.ErrorCode.html for all of the error codes
                    }
                };
                
                SyncConfiguration.ClientResetHandler = new RecoverOrDiscardUnsyncedChangesHandler
                {
                    // handle client reset
                    ManualResetFallback=(err)=>
                    {
                        if(err!=null)
                        {
                            // handle error
                            new ManualRecoveryHandler(HandleClientResetError);
                        }
                       
                    }
                };
            }
            catch ( Exception ex)
            {

              
            }
        }

        private void HandleClientResetError(ClientResetException clientResetException)
        {
            try
            {
                Console.WriteLine($"Client Reset requested: {clientResetException.Message}");
                // Prompt user to perform a client reset immediately. If they don't,
                // they won't receive any data from the server until they restart the app
                // and all changes they make will be discarded when the app restarts.
                // var didUserConfirmReset = ShowUserAConfirmationDialog();
                //if (didUserConfirmReset)
                //{
                // Close the Realm before doing the reset. It must be 
                // deleted as part of the reset.
                // fsRealm.Dispose();
                // perform the client reset
                var didReset = clientResetException.InitiateClientReset();
                if (didReset)
                {
                    // Navigate the user back to the main page or reopen the
                    // the Realm and reinitialize the current page
                }
                else
                {
                    // Reset failed - notify user that they'll need to
                    // update the app
                }
            }
            catch (Exception ex)
            {

               
            }
        }
    }
}
