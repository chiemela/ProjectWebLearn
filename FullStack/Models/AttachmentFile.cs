﻿using System;

namespace FullStack.Models
{
    public class AttachmentFile : EntityBase
    {
        public Int64 Id { get; set; }
        public string FilePath { get; set; } = "/upload/blank-doc.txt";
        public string? ContentType { get; set; }
        public string? FileName { get; set; }
        public int Grade { get; set; }
        public Int64 Length { get; set; }
    }
}
