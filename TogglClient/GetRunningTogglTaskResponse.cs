using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace TogglButtn.TogglClient
{
    public class GetRunningTogglTaskResponse
    {
        public readonly DateTime StartedAt;
        public readonly string EntryName;
        public readonly Guid Id;

        protected GetRunningTogglTaskResponse(DateTime startedAt, string entryName, Guid id) {
            StartedAt = startedAt;
            EntryName = entryName;
            Id = id;
        }

        public static GetRunningTogglTaskResponse Build(JToken json) {
            var dataObject = json["data"];

            if(!dataObject.HasValues) {
                return null;
            }

            var entryID = (Guid)dataObject.SelectToken("guid", true);
            var entryName = (string)dataObject.SelectToken("description", false);
            var entryStart = ((DateTime)dataObject.SelectToken("start", true)).ToUniversalTime();
            return new GetRunningTogglTaskResponse(entryStart, entryName, entryID);
        }
    }
}
