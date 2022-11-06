namespace URIParams.Model
{
    public class DeciduousNativeTree
    {
        public string Id { get; set; }
        public string LatinName { get; set; }
        public string Family { get; set; }
        public List<string> CommonNames { get; set; }
        public string Native { get; set; }
        public List<string> Images { get; set; }
    }

    public class DeciduousNonnativeTree
    {
        public string Id { get; set; }
        public string LatinName { get; set; }
        public string Family { get; set; }
        public List<string> CommonNames { get; set; }
        public string Native { get; set; }
        public List<string> Images { get; set; }
    }

    public class Trees
    {
        public List<DeciduousNativeTree> deciduous_native { get; set; }
        public List<DeciduousNonnativeTree> deciduous_nonnative { get; set; }
    }
}
