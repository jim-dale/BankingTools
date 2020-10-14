
namespace OfxNet
{
    public class SgmlHeader
    {
        public OfxVersion HeaderVersion { get; set; }
        public string Data { get; set; }
        public OfxVersion Version { get; set; }
        public string Security { get; set; }
        public string Encoding { get; set; }
        public string Charset { get; set; }
        public string Compression { get; set; }
        public string OldFileUid { get; set; }
        public string NewFileUid { get; set; }
    }
}
