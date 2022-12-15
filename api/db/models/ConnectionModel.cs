using System;

namespace api.db.models;

internal record ConnectionModel(string id, string title, DateTime lastRequestTime);

