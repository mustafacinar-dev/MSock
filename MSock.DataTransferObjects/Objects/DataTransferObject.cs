using System;

namespace MSock.DataTransferObjects.Objects
{
    [Serializable]
    public class DataTransferObject
    {
        public string Message { get; set; }
        public string Status { get; set; }
    }
}
