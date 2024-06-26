﻿using Newtonsoft.Json.Linq;
using System;

namespace Migration.Jira_Export.Tests
{
    /// <summary>
    /// Represents an item in the changelog.histories[*] field of an issue
    /// </summary>
    public class HistoryItem
    {
        public long Id { get; set; } = 0;
        public DateTime Created { get; set; } = DateTime.Now;
        public string Field { get; set; } = string.Empty;
        public string FieldType { get; set; } = string.Empty;
        public string From { get; set; } = string.Empty;
        public string FromString { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public new string ToString { get; set; } = string.Empty;

        public JObject ToJObject()
        {
            return JObject.Parse($@"
            {{
                'id': {Id},
                'author': 'unittest',
                'created': '{Created:yyyy - MM - ddTHH:mm: ss.fffZ}',
                'items': [
                {{
                  'field': {FormatJsonValue(Field)},
                  'fieldtype': {FormatJsonValue(FieldType)},
                  'from': {FormatJsonValue(From)},
                  'fromString': {FormatJsonValue(FromString)},
                  'to': {FormatJsonValue(To)},
                  'toString': {FormatJsonValue(ToString)},
                }}
              ]
            }}");
        }

        private string FormatJsonValue(string value)
        {
            if (value == null)
                return "null";
            else
                return $"'{value}'";
        }
    }
}
