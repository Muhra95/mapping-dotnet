using MHP.CodingChallenge.Backend.Mapping.Data.DB;
using System;

namespace MHP.CodingChallenge.Backend.Mapping.Data.DTO
{
    public class ImageDto : DbEntity
    {
        public String Url { get; set; }
        public ImageSize ImageSize { get; set; }
    }
}