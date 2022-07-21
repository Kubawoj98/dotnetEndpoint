namespace dotNetEndpoint.Utilities
{
    public static class RevDeBugCaller
    {
        public static void RecordSnapshot(string name = null)
        {
            RevDeBugAPI.Snapshot.RecordSnapshot(name);
        }
    }
}
